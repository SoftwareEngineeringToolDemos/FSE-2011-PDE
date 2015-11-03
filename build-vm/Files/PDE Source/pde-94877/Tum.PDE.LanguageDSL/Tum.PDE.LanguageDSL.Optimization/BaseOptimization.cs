using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Optimization
{
    public abstract class BaseOptimization
    {
        private List<DomainClass> involvedClasses;
        private List<DomainRelationship> involvedRelationships;
        private List<DomainClassReferencesBaseClass> involvedInheritancesRelationships;
        private Dictionary<Guid, Guid> involvedClassesMapping;
        private Dictionary<Guid, Guid> involvedRelationshipsMapping;
        private Dictionary<Guid, Guid> involvedInheritancesRelationshipsMapping;
        private Dictionary<Guid, Guid> involvedClassesTargetMapping;
        private Dictionary<Guid, Guid> involvedRelationshipsTargetMapping;
        private Dictionary<Guid, Guid> involvedInheritancesRelationshipsTargetMapping;

        /// <summary>
        /// Gets the metamodel.
        /// </summary>
        public MetaModel MetaModel
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the model context.
        /// </summary>
        public LibraryModelContext ModelContext
        {
            get;
            private set;
        }

        private MetaModel sourceTempModel = null;
        private MetaModel targetTempModel = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="metaModel"></param>
        /// <param name="modelContext"></param>
        protected BaseOptimization(MetaModel metaModel, LibraryModelContext modelContext)
        {
            this.involvedClasses = new List<DomainClass>();
            this.involvedInheritancesRelationships = new List<DomainClassReferencesBaseClass>();
            this.involvedRelationships = new List<DomainRelationship>();

            this.involvedClassesMapping = new Dictionary<Guid, Guid>();
            this.involvedInheritancesRelationshipsMapping = new Dictionary<Guid, Guid>();
            this.involvedRelationshipsMapping = new Dictionary<Guid, Guid>();

            this.involvedClassesTargetMapping = new Dictionary<Guid, Guid>();
            this.involvedInheritancesRelationshipsTargetMapping = new Dictionary<Guid, Guid>();
            this.involvedRelationshipsTargetMapping = new Dictionary<Guid, Guid>();

            this.MetaModel = metaModel;
            this.ModelContext = modelContext;
        }

        /// <summary>
        /// Gets the involved classes.
        /// </summary>
        public List<DomainClass> InvolvedClasses
        {
            get
            {
                return this.involvedClasses;
            }
        }

        /// <summary>
        /// Gets the involved relationships.
        /// </summary>
        public List<DomainRelationship> InvolvedRelationships
        {
            get
            {
                return this.involvedRelationships;
            }
        }

        /// <summary>
        /// Gets the involved inh. relationships.
        /// </summary>
        public List<DomainClassReferencesBaseClass> InvolvedInheritancesRelationships
        {
            get
            {
                return this.involvedInheritancesRelationships;
            }
        }

        /// <summary>
        /// Gets the involved class mapping.
        /// </summary>
        public Dictionary<Guid, Guid> InvolvedClassesMapping
        {
            get
            {
                return this.involvedClassesMapping;
            }
        }

        /// <summary>
        /// Gets the involved rs mapping.
        /// </summary>
        public Dictionary<Guid, Guid> InvolvedRelationshipsMapping
        {
            get
            {
                return this.involvedRelationshipsMapping;
            }
        }

        /// <summary>
        /// Gets the involved inh class mapping.
        /// </summary>
        public Dictionary<Guid, Guid> InvolvedInheritancesRelationshipsMapping
        {
            get
            {
                return this.involvedInheritancesRelationshipsMapping;
            }
        }

        /// <summary>
        /// Gets the involved class target mapping.
        /// </summary>
        public Dictionary<Guid, Guid> InvolvedClassesTargetMapping
        {
            get
            {
                return this.involvedClassesTargetMapping;
            }
        }

        /// <summary>
        /// Gets the involved rs target mapping.
        /// </summary>
        public Dictionary<Guid, Guid> InvolvedRelationshipsTargetMapping
        {
            get
            {
                return this.involvedRelationshipsTargetMapping;
            }
        }

        /// <summary>
        /// Gets the involved inh class target mapping.
        /// </summary>
        public Dictionary<Guid, Guid> InvolvedInheritancesRelationshipsTargetMapping
        {
            get
            {
                return this.involvedInheritancesRelationshipsTargetMapping;
            }
        }

        /// <summary>
        /// Gets the source model.
        /// </summary>
        public MetaModel SourceModel
        {
            get
            {
                if (this.sourceTempModel == null)
                    this.CreateSourceModel();

                return this.sourceTempModel;
            }
        }

        /// <summary>
        /// Gets the target model.
        /// </summary>
        public MetaModel TargetModel
        {
            get
            {
                if (this.targetTempModel == null)
                    this.CreateTargetModel();

                return this.targetTempModel;
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Creates the source model.
        /// </summary>
        public virtual void CreateSourceModel()
        {
            this.sourceTempModel = CreateTempModel(false);
        }

        /// <summary>
        /// Creates the target model.
        /// </summary>
        public virtual void CreateTargetModel()
        {
            this.targetTempModel = CreateTempModel(true);

            // disable undo/redo
            this.MetaModel.Store.UndoManager.UndoState = Microsoft.VisualStudio.Modeling.UndoState.DisabledNoFlush;

            this.ApplyOptimization(true);


            // enable undo/redo
            this.MetaModel.Store.UndoManager.UndoState = Microsoft.VisualStudio.Modeling.UndoState.Enabled;
        }

        /// <summary>
        /// Creates the temp model.
        /// </summary>
        /// <returns></returns>
        public MetaModel CreateTempModel(bool bIsTarget)
        {
            // disable undo/redo
            this.MetaModel.Store.UndoManager.UndoState = Microsoft.VisualStudio.Modeling.UndoState.DisabledNoFlush;

            MetaModel m = null;
            LibraryModelContext context = null;
            using (Transaction t = this.MetaModel.Store.TransactionManager.BeginTransaction())
            {
                m = new MetaModel(this.MetaModel.Store);
                context = new LibraryModelContext(this.MetaModel.Store);
                m.ModelContexts.Add(context);

                // post process
                SerializationPostProcessor.PostProcessModelLoad(m);

                t.Commit();
            }
            
            // create copies of domain classes
            using (Transaction t = this.MetaModel.Store.TransactionManager.BeginTransaction())
            {
                foreach (DomainClass d in this.InvolvedClasses)
                {
                    DomainClass domainClass = new DomainClass(this.MetaModel.Store);
                    domainClass.Name = d.Name;
                    context.Classes.Add(domainClass);

                    if( !bIsTarget )
                        this.InvolvedClassesMapping.Add(d.Id, domainClass.Id);
                    else
                        this.InvolvedClassesTargetMapping.Add(d.Id, domainClass.Id);
                }
                    
                t.Commit();
            }

            // create inheritance relationships
            using (Transaction t = this.MetaModel.Store.TransactionManager.BeginTransaction())
            {
                foreach (DomainClassReferencesBaseClass con in this.InvolvedInheritancesRelationships)
                {
                    DomainClass source;
                    DomainClass target;
                    if (!bIsTarget)
                    {
                        source = m.Store.ElementDirectory.GetElement(this.InvolvedClassesMapping[con.DerivedClass.Id]) as DomainClass;
                        target = m.Store.ElementDirectory.GetElement(this.InvolvedClassesMapping[con.BaseClass.Id]) as DomainClass;
                    }
                    else
                    {
                        source = m.Store.ElementDirectory.GetElement(this.InvolvedClassesTargetMapping[con.DerivedClass.Id]) as DomainClass;
                        target = m.Store.ElementDirectory.GetElement(this.InvolvedClassesTargetMapping[con.BaseClass.Id]) as DomainClass;
                    }

                    DomainClassReferencesBaseClass conCreated = new DomainClassReferencesBaseClass(source, target);
                    if( !bIsTarget )
                        this.InvolvedInheritancesRelationshipsMapping.Add(con.Id, conCreated.Id);
                    else
                        this.InvolvedInheritancesRelationshipsTargetMapping.Add(con.Id, conCreated.Id);
                }

                t.Commit();
            }

            // create relationships
            using (Transaction t = this.MetaModel.Store.TransactionManager.BeginTransaction())
            {
                foreach (DomainRelationship rel in this.InvolvedRelationships)
                {
                    DomainClass source;
                    DomainClass target;
                    if (!bIsTarget)
                    {
                        source = m.Store.ElementDirectory.GetElement(this.InvolvedClassesMapping[rel.Source.RolePlayer.Id]) as DomainClass;
                        target = m.Store.ElementDirectory.GetElement(this.InvolvedClassesMapping[rel.Target.RolePlayer.Id]) as DomainClass;
                    }
                    else
                    {
                        source = m.Store.ElementDirectory.GetElement(this.InvolvedClassesTargetMapping[rel.Source.RolePlayer.Id]) as DomainClass;
                        target = m.Store.ElementDirectory.GetElement(this.InvolvedClassesTargetMapping[rel.Target.RolePlayer.Id]) as DomainClass;
                    }

                    DomainRelationship relCreated;
                    if( rel is ReferenceRelationship)
                        relCreated = Tum.PDE.LanguageDSL.ModelTreeHelper.AddNewReferenceRelationship(source, target);
                    else
                        relCreated = Tum.PDE.LanguageDSL.ModelTreeHelper.AddNewEmbeddingRS(source, target, false);

                    if (!bIsTarget)
                        this.InvolvedRelationshipsMapping.Add(rel.Id, relCreated.Id);
                    else
                        this.InvolvedRelationshipsTargetMapping.Add(rel.Id, relCreated.Id);
                }

                t.Commit();
            }

            this.CreateTempModel(m, bIsTarget);


            // enable undo/redo
            this.MetaModel.Store.UndoManager.UndoState = Microsoft.VisualStudio.Modeling.UndoState.Enabled;

            return m;
        }

        /// <summary>
        /// Creates a temp model. Called during the creation of the temp model.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual void CreateTempModel(MetaModel m, bool bIsTarget)
        {
        }

        /// <summary>
        /// Apply the optimization.
        /// </summary>
        public void ApplyOptimization()
        {
            this.ApplyOptimization(false);
        }

        /// <summary>
        /// Applies the optimization.
        /// </summary>
        /// <param name="bApplyForTempModel"></param>
        public abstract void ApplyOptimization(bool bApplyForTempModel);

        /// <summary>
        /// Clean up.
        /// </summary>
        public virtual void Dispose()
        {
            // delete temp model if they have been created.

            // disable undo/redo
            this.MetaModel.Store.UndoManager.UndoState = Microsoft.VisualStudio.Modeling.UndoState.DisabledNoFlush;

            using (Transaction t = this.MetaModel.Store.TransactionManager.BeginTransaction())
            {
                if (this.sourceTempModel != null)
                    this.sourceTempModel.Delete();

                if (this.targetTempModel != null)
                    this.targetTempModel.Delete();

                t.Commit();
            }

            // enable undo/redo
            this.MetaModel.Store.UndoManager.UndoState = Microsoft.VisualStudio.Modeling.UndoState.Enabled;
        }
    }
}
