using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.LanguageDSL.Optimization
{
    public class PropertiesOptimization : BaseOptimization
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="metaModel"></param>
        /// <param name="modelContext"></param>
        public PropertiesOptimization(MetaModel metaModel, LibraryModelContext modelContext)
            : base(metaModel, modelContext)
        {
            InvolvedProperties = new List<DomainProperty>();
            this.CreateIntermediate = false;
            this.IsInheritance = false;
        }

        /// <summary>
        /// Gets the involved properties.
        /// </summary>
        public List<DomainProperty> InvolvedProperties
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the base class the properties should be added to.
        /// </summary>
        public DomainClass BaseClass
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this properties optimization is based on moving properties to an alredy existing base class or not.
        /// True=move to base class. False=create new base class.
        /// </summary>
        public bool IsInheritance
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether a new base class should be created for the elements and itself be derived from the current base class of the elements.
        /// </summary>
        public bool CreateIntermediate
        {
            get;
            set;
        }

        /// <summary>
        /// Applies the optimization.
        /// </summary>
        /// <param name="metaModel"></param>
        /// <param name="modelContext"></param>
        public override void ApplyOptimization(bool bApplyForTempModel)
        {
            MetaModel metaModel;
            LibraryModelContext modelContext;
            if (bApplyForTempModel)
            {
                metaModel = this.TargetModel;
                modelContext = this.TargetModel.ModelContexts[0] as LibraryModelContext;
            }
            else
            {
                metaModel = this.MetaModel;
                modelContext = this.ModelContext;
            }

            using (Transaction t = this.MetaModel.Store.TransactionManager.BeginTransaction("Apply optimization"))
            {
                DomainClass bClass = null;
                if (!IsInheritance)
                {
                    // create new base class to host the properties
                    bClass = new DomainClass(metaModel.Store);
                    modelContext.Classes.Add(bClass);
                    bClass.InheritanceModifier = InheritanceModifier.Abstract;

                    bClass.Name = GetUniqueNameForBaseClass();

                    // create inheritance rs to domain classes
                    foreach (DomainClass s in this.InvolvedClasses)
                    {
                        DomainClass domainClass;
                        if (bApplyForTempModel)
                            domainClass = bClass.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[s.Id]) as DomainClass;
                        else
                            domainClass = s;
                        if (domainClass == null)
                            throw new ArgumentNullException("DomainClass not found: Target Mappping error.. ");

                        new DomainClassReferencesBaseClass(domainClass, bClass);
                    }
                }
                else
                {
                    if (CreateIntermediate)
                    {
                        // create class
                        using (Transaction tD = this.MetaModel.Store.TransactionManager.BeginTransaction("Create intermediate Base class"))
                        {
                            DomainClass intermediateBaseClass = new DomainClass(metaModel.Store);
                            modelContext.Classes.Add(intermediateBaseClass);

                            intermediateBaseClass.InheritanceModifier = InheritanceModifier.Abstract;
                            intermediateBaseClass.Name = GetUniqueNameForBaseClass();

                            bClass = intermediateBaseClass;
                            tD.Commit();
                        }

                        // create inheritance rs to domain classes
                        foreach (DomainClass s in this.InvolvedClasses)
                        {
                            if (s == this.BaseClass)
                                continue;

                            DomainClass domainClass;
                            if (bApplyForTempModel)
                                domainClass = bClass.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[s.Id]) as DomainClass;
                            else
                                domainClass = s;
                            if (domainClass == null)
                                throw new ArgumentNullException("DomainClass not found: Target Mappping error.. ");


                            using (Transaction t2 = this.MetaModel.Store.TransactionManager.BeginTransaction("Base class"))
                            {
                                domainClass.BaseClass = null;
                                t2.Commit();
                            }

                            using (Transaction t3 = this.MetaModel.Store.TransactionManager.BeginTransaction("Add inh class"))
                            {
                                new DomainClassReferencesBaseClass(domainClass, bClass);
                                t3.Commit();
                            }
                        }

                        // create inheritance from intermediate base class to base class
                        DomainClass curBaseClass;
                        if (bApplyForTempModel)
                            curBaseClass = metaModel.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[this.BaseClass.Id]) as DomainClass;
                        else
                            curBaseClass = this.BaseClass;
                        new DomainClassReferencesBaseClass(bClass, curBaseClass);

                        
                    }
                    else
                    {
                        // get base class
                        if (bApplyForTempModel)
                            bClass = metaModel.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[this.BaseClass.Id]) as DomainClass;
                        else
                            bClass = this.BaseClass;
                    }
                }

                if (bClass == null)
                    throw new ArgumentNullException("Couldn't retrieve base class");

                // remove properties from domain classes
                List<DomainProperty> toDelete = new List<DomainProperty>();
                foreach (DomainClass d in this.InvolvedClasses)
                {
                    if (d == this.BaseClass)
                        continue;

                    DomainClass domainClass;
                    if (bApplyForTempModel)
                        domainClass = bClass.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[d.Id]) as DomainClass;
                    else
                        domainClass = d;
                    
                    if (domainClass == null)
                        throw new ArgumentNullException("DomainClass not found: Target Mappping error.. ");

                    for (int i = domainClass.Properties.Count - 1; i >= 0; i--)
                        if (ContainsPropertyInInvolved(domainClass.Properties[i]))
                            toDelete.Add(domainClass.Properties[i]);
                }

                foreach (DomainProperty p in toDelete)
                    if( !p.IsDeleted && !p.IsDeleting )
                        p.Delete();

                // add properties on bClass
                foreach (DomainProperty p in this.InvolvedProperties)
                {
                    DomainProperty domainProperty = new DomainProperty(bClass.Store);
                    domainProperty.Name = p.Name;
                    domainProperty.Type = p.Type;
                    domainProperty.IsElementName = p.IsElementName;

                    bClass.Properties.Add(domainProperty);
                }


                t.Commit();
            }
        }

        /// <summary>
        /// Creates the temp model.
        /// </summary>
        /// <returns></returns>
        public override void CreateTempModel(MetaModel m, bool bIsTarget)
        {
            using (Transaction t = this.MetaModel.Store.TransactionManager.BeginTransaction())
            {
                // add properties to domain classes
                foreach (DomainClass key in this.InvolvedClasses)
                {
                    if (key == BaseClass)
                        continue;

                    DomainClass d;
                    if( !bIsTarget )
                        d = m.Store.ElementDirectory.FindElement(this.InvolvedClassesMapping[key.Id]) as DomainClass;
                    else
                        d = m.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[key.Id]) as DomainClass;
                    if (d == null)
                        throw new ArgumentNullException("DomainClass not found: Mappping error.. ");

                    // create properties
                    foreach (DomainProperty p in this.InvolvedProperties)
                    {
                        DomainProperty domainProperty = new DomainProperty(m.Store);
                        domainProperty.Name = p.Name;
                        domainProperty.Type = p.Type;

                        d.Properties.Add(domainProperty);
                    }
                }

                t.Commit();
            }
        }

        private DomainProperty GetProperty(DomainClass domainClass, DomainProperty referenceProperty)
        {
            foreach (DomainProperty p in domainClass.Properties)
                if (p.Name == referenceProperty.Name && p.Type == referenceProperty.Type)
                    return p;

            return null;
        }
        private bool ContainsPropertyInInvolved(DomainProperty p)
        {
            foreach (DomainProperty refP in this.InvolvedProperties)
                if (p.Name == refP.Name && p.Type.Name == refP.Type.Name && p.Type.Namespace == refP.Type.Namespace)
                    return true;

            return false;
        }

        private string GetUniqueNameForBaseClass()
        {
            string nameFree = "BaseClass";
            int counter = 1;

            List<string> usedNames = new List<string>();
            ReadOnlyCollection<ModelElement> elements = this.MetaModel.Store.ElementDirectory.FindElements(DomainClass.DomainClassId);
            foreach (ModelElement element in elements)
            {
                if (LanguageDSLElementNameProvider.Instance.HasName(element))
                {
                    string s = LanguageDSLElementNameProvider.Instance.GetName(element);
                    usedNames.Add(s);
                }
            }

            while (true)
            {
                if (usedNames.Contains(nameFree + counter.ToString()))
                    counter++;
                else
                    break;
            }

            return nameFree + counter.ToString();
        }
    }
}
