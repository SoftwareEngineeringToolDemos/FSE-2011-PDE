using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.LanguageDSL.Optimization
{
   public class RelationshipsOptimization : BaseOptimization
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="metaModel"></param>
        /// <param name="modelContext"></param>
       public RelationshipsOptimization(MetaModel metaModel, LibraryModelContext modelContext)
           : base(metaModel, modelContext)
       {
           this.IsEmbedding = true;
       }
       
       /// <summary>
       /// Gets or sets the base class the properties should be added to.
       /// </summary>
       public DomainClass BaseClass
       {
           get;
           set;
       }

       public DomainClass ParentClass
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

       public bool IsEmbedding
       {
           get;
           set;
       }

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

           //using (Transaction t = this.MetaModel.Store.TransactionManager.BeginTransaction("Apply optimization"))
           //{
               DomainClass bClass = null;

               #region Base classes
               if (this.CreateIntermediate || this.BaseClass == null)
               {
                   // create class
                   using (Transaction tD = this.MetaModel.Store.TransactionManager.BeginTransaction("Create intermediate Base class"))
                   {
                       DomainClass intermediateBaseClass = new DomainClass(metaModel.Store);
                       modelContext.Classes.Add(intermediateBaseClass);

                       intermediateBaseClass.InheritanceModifier = InheritanceModifier.Abstract;
                       intermediateBaseClass.Name = GetUniqueNameForBaseClass();

                       bClass = intermediateBaseClass;

                       if (this.BaseClass != null)
                       {
                           // create inheritance to the current base class
                           DomainClass domainClass;
                           if (bApplyForTempModel)
                               domainClass = bClass.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[this.BaseClass.Id]) as DomainClass;
                           else
                               domainClass = this.BaseClass;
                           if (domainClass == null)
                               throw new ArgumentNullException("DomainClass not found: Target Mappping error.. ");

                           intermediateBaseClass.BaseClass = domainClass;
                       }
                       tD.Commit();
                   }
               }
               else
               {
                   if (this.BaseClass != null)
                   {
                       if (bApplyForTempModel)
                           bClass = metaModel.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[this.BaseClass.Id]) as DomainClass;
                       else
                           bClass = this.BaseClass;
                   }
               }

               if (bClass == null)
                   throw new ArgumentNullException("Couldn't retrieve base class");

               // create inheritance rs to domain classes
               foreach (DomainRelationship r in this.InvolvedRelationships)
               {
                   DomainClass s = r.Target.RolePlayer as DomainClass;
                   if (s == this.BaseClass)
                       continue;

                   DomainClass domainClass;
                   if (bApplyForTempModel)
                       domainClass = bClass.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[s.Id]) as DomainClass;
                   else
                       domainClass = s;
                   if (domainClass == null)
                       throw new ArgumentNullException("DomainClass not found: Target Mappping error.. ");


                   if( domainClass.BaseClass != null )
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
               #endregion

               #region Delete Rels
               using (Transaction tD = this.MetaModel.Store.TransactionManager.BeginTransaction("Delete Rels"))
               {
                   foreach (DomainRelationship rel in this.InvolvedRelationships)
                   {
                       DomainRelationship relToDelete;
                       if (bApplyForTempModel)
                           relToDelete = bClass.Store.ElementDirectory.FindElement(this.InvolvedRelationshipsTargetMapping[rel.Id]) as DomainRelationship;
                       else
                           relToDelete = rel;

                       relToDelete.Delete();
                   }

                   tD.Commit();
               }
               #endregion

               #region Create Rel
               using (Transaction tD = this.MetaModel.Store.TransactionManager.BeginTransaction("Create Rels"))
               {
                   DomainClass parent;
                   if (bApplyForTempModel)
                       parent = bClass.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[this.ParentClass.Id]) as DomainClass;
                   else
                       parent = this.ParentClass;

                   DomainRelationship relCreated;
                   if (this.IsEmbedding)
                       relCreated = Tum.PDE.LanguageDSL.ModelTreeHelper.AddNewEmbeddingRS(parent, bClass, false);
                   else
                       relCreated = Tum.PDE.LanguageDSL.ModelTreeHelper.AddNewReferenceRelationship(parent, bClass);

                   tD.Commit();
               }
               #endregion
           //t.Commit();
           //}
       }

       protected string GetUniqueNameForBaseClass()
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

    public class RelationshipsReferencesBetweenBaseClassesOptimization : RelationshipsOptimization
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="metaModel"></param>
        /// <param name="modelContext"></param>
        public RelationshipsReferencesBetweenBaseClassesOptimization(MetaModel metaModel, LibraryModelContext modelContext)
           : base(metaModel, modelContext)
       {
       }

        public DomainClass BaseClassTarget
        {
            get;
            set;
        }

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

            DomainClass bClass = null;
            //DomainClass bClassTarget = null;

            #region Base classes: Source
            if (this.BaseClass == null)
            {
                // create class
                using (Transaction tD = this.MetaModel.Store.TransactionManager.BeginTransaction("Create intermediate Base class"))
                {
                    DomainClass intermediateBaseClass = new DomainClass(metaModel.Store);
                    modelContext.Classes.Add(intermediateBaseClass);

                    intermediateBaseClass.InheritanceModifier = InheritanceModifier.Abstract;
                    intermediateBaseClass.Name = GetUniqueNameForBaseClass();

                    bClass = intermediateBaseClass;

                    if (this.BaseClass != null)
                    {
                        // create inheritance to the current base class
                        DomainClass domainClass;
                        if (bApplyForTempModel)
                            domainClass = bClass.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[this.BaseClass.Id]) as DomainClass;
                        else
                            domainClass = this.BaseClass;
                        if (domainClass == null)
                            throw new ArgumentNullException("DomainClass not found: Target Mappping error.. ");

                        intermediateBaseClass.BaseClass = domainClass;
                    }
                    tD.Commit();
                }

                // create inheritance rs to domain classes
                foreach (DomainRelationship r in this.InvolvedRelationships)
                {
                    DomainClass s = r.Source.RolePlayer as DomainClass;
                    if (s == bClass)
                        continue;

                    DomainClass domainClass;
                    if (bApplyForTempModel)
                        domainClass = bClass.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[s.Id]) as DomainClass;
                    else
                        domainClass = s;
                    if (domainClass == null)
                        throw new ArgumentNullException("DomainClass not found: Target Mappping error.. ");


                    if (domainClass.BaseClass != null)
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
                // create inheritance rs to domain classes
                foreach (DomainRelationship r in this.InvolvedRelationships)
                {
                    DomainClass s = r.Target.RolePlayer as DomainClass;
                    if (s == bClass)
                        continue;

                    DomainClass domainClass;
                    if (bApplyForTempModel)
                        domainClass = bClass.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[s.Id]) as DomainClass;
                    else
                        domainClass = s;
                    if (domainClass == null)
                        throw new ArgumentNullException("DomainClass not found: Target Mappping error.. ");


                    if (domainClass.BaseClass != null)
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
            }
            else
            {
                if (this.BaseClass != null)
                {
                    if (bApplyForTempModel)
                        bClass = metaModel.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[this.BaseClass.Id]) as DomainClass;
                    else
                        bClass = this.BaseClass;
                }
            }

            if (bClass == null)
                throw new ArgumentNullException("Couldn't retrieve base class");

            #endregion
            /*
            #region Base classes: Target
            if (this.BaseClassTarget == null)
            {
                // create class
                using (Transaction tD = this.MetaModel.Store.TransactionManager.BeginTransaction("Create intermediate Base class"))
                {
                    DomainClass intermediateBaseClass = new DomainClass(metaModel.Store);
                    modelContext.Classes.Add(intermediateBaseClass);

                    intermediateBaseClass.InheritanceModifier = InheritanceModifier.Abstract;
                    intermediateBaseClass.Name = GetUniqueNameForBaseClass();

                    bClassTarget = intermediateBaseClass;

                    if (this.BaseClassTarget != null)
                    {
                        // create inheritance to the current base class
                        DomainClass domainClass;
                        if (bApplyForTempModel)
                            domainClass = bClass.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[this.BaseClassTarget.Id]) as DomainClass;
                        else
                            domainClass = this.BaseClass;
                        if (domainClass == null)
                            throw new ArgumentNullException("DomainClass not found: Target Mappping error.. ");

                        intermediateBaseClass.BaseClass = domainClass;
                    }
                    tD.Commit();
                }

                // create inheritance rs to domain classes
                foreach (DomainRelationship r in this.InvolvedRelationships)
                {
                    DomainClass s = r.Target.RolePlayer as DomainClass;
                    if (s == bClassTarget)
                        continue;

                    DomainClass domainClass;
                    if (bApplyForTempModel)
                        domainClass = bClass.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[s.Id]) as DomainClass;
                    else
                        domainClass = s;
                    if (domainClass == null)
                        throw new ArgumentNullException("DomainClass not found: Target Mappping error.. ");


                    if (domainClass.BaseClass != null)
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
            }
            else
            {
                if (this.BaseClassTarget != null)
                {
                    if (bApplyForTempModel)
                        bClassTarget = metaModel.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[this.BaseClass.Id]) as DomainClass;
                    else
                        bClassTarget = this.BaseClass;
                }
            }

            if (bClassTarget == null)
                throw new ArgumentNullException("Couldn't retrieve base class");

            
            #endregion
            */

            #region Delete Rels
            using (Transaction tD = this.MetaModel.Store.TransactionManager.BeginTransaction("Delete Rels"))
            {
                foreach (DomainRelationship rel in this.InvolvedRelationships)
                {
                    DomainRelationship relToDelete;
                    if (bApplyForTempModel)
                        relToDelete = bClass.Store.ElementDirectory.FindElement(this.InvolvedRelationshipsTargetMapping[rel.Id]) as DomainRelationship;
                    else
                        relToDelete = rel;

                    relToDelete.Delete();
                }

                tD.Commit();
            }
            #endregion

            #region Create Rel
            using (Transaction tD = this.MetaModel.Store.TransactionManager.BeginTransaction("Create Rels"))
            {
                DomainClass parent;
                //if (bApplyForTempModel)
                //    parent = bClass.Store.ElementDirectory.FindElement(this.InvolvedClassesTargetMapping[bClass.Id]) as DomainClass;
                //else
                    parent = bClass;

                DomainRelationship relCreated;
                relCreated = Tum.PDE.LanguageDSL.ModelTreeHelper.AddNewReferenceRelationship(parent, bClass);

                tD.Commit();
            }
            #endregion
        }
    }
}
