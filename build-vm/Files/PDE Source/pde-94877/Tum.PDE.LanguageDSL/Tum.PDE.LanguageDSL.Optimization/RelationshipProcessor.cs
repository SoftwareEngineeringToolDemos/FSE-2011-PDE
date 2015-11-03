using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Tum.PDE.LanguageDSL.Optimization
{
    public class RelationshipProcessor : BaseProcessor
    {
        private string separatorGuid = Guid.NewGuid().ToString();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="metaModel"></param>
        /// <param name="modelContext"></param>
        public RelationshipProcessor(MetaModel metaModel, LibraryModelContext modelContext)
            : base(metaModel, modelContext)
        {
        }

        /// <summary>
        /// Gets optimizations.
        /// </summary>
        /// <returns></returns>
        public override List<BaseOptimization> GetOptimizations()
        {
            List<BaseOptimization> opt = new List<BaseOptimization>();

            DomainClass domainModel = null;
            foreach(DomainClass d in this.ModelContext.Classes)
                if( d.IsDomainModel )
                {
                    domainModel =d;
                    break;
                }
            if( domainModel != null )
                try
                {
                    opt.AddRange(GetOptimizationsRefRelationshipsSameLevel(domainModel, new List<DomainClass>()));
                }
                catch
                {
                }
            opt.AddRange(GetOptimizations(this.ModelContext.Classes, new List<DomainClass>(), false));

            return opt;
        }

        private List<RelationshipsOptimization> GetOptimizations(IEnumerable<DomainClass> classes, List<DomainClass> alreadyProcessedBaseClasses, bool isInheritance)
        {
            List<RelationshipsOptimization> opt = new List<RelationshipsOptimization>();

            // Optimization: class references multiple classes that do not have any base class or the same base class
            // --> 1. Add reference to base class
            // --> 2. Add reference to intermediate class that becomes the new base class for those classes
            foreach (DomainClass domainClass in classes)
            {
                List<ReferenceRelationship> references = new List<ReferenceRelationship>();
                List<EmbeddingRelationship> embeddings = new List<EmbeddingRelationship>();

                // gather relationship info
                foreach (DomainRole role in domainClass.RolesPlayed)
                {
                    if (role.Relationship.Source != role)
                        continue;

                    if (role.Relationship.Target.RolePlayer.Name == domainClass.Name)
                        continue;

                    if (role.Relationship.BaseRelationship != null)
                        continue;

                    if (!(role.Relationship.Target.RolePlayer is DomainClass))
                        continue;

                    if (role.Relationship.Properties.Count > 0)
                        continue;

                    if (role.Relationship.RelationshipShapeClasses.Count > 0)
                        continue;

                    // keep references and embeddings separate
                    if (role.Relationship is ReferenceRelationship)
                    {
                        references.Add(role.Relationship as ReferenceRelationship);
                    }
                    else
                    {
                        embeddings.Add(role.Relationship as EmbeddingRelationship);
                    }
                }

                // process relationship info
                if( references.Count > 1 )
                {
                    opt.AddRange(CreateOptimizations(domainClass, references));
                }

                if (embeddings.Count > 1)
                {
                    opt.AddRange(CreateOptimizations(domainClass, embeddings));
                }
            }

            return opt;
        }
        private List<RelationshipsOptimization> CreateOptimizations(DomainClass domainClass, ICollection references)
        {
            List<RelationshipsOptimization> opt = new List<RelationshipsOptimization>();
            Dictionary<object, List<DomainRelationship>> dict = GetSortedByBaseClasses(references);

            foreach (object key in dict.Keys)
            {
                List<DomainRelationship> rels = dict[key];
                if (rels.Count <= 1)
                    continue;

                Dictionary<string, List<DomainRelationship>> dict2 = GetSortedByMutliplicity(rels);
                foreach (string key2 in dict2.Keys)
                {
                    rels = dict2[key2];
                    if (rels.Count <= 1)
                        continue;

                    bool bUseIntermediate = false;
                    if (key is DomainClass)
                    {
                        if ((key as DomainClass) == domainClass)
                            continue;

                        bUseIntermediate = UseIntermediate(rels);
                        if (!bUseIntermediate)
                            if ((key as DomainClass).DerivedClasses.Count != rels.Count)
                                bUseIntermediate = true;
                    }

                    RelationshipsOptimization rOpt = new RelationshipsOptimization(this.MetaModel, this.ModelContext);
                    rOpt.Title = "Relationship Optimization";
                    rOpt.InvolvedClasses.Add(domainClass);
                    rOpt.ParentClass = domainClass;
                    rOpt.CreateIntermediate = bUseIntermediate;

                    if (rOpt.CreateIntermediate)
                        rOpt.Description = "Existing references are replaces with one reference to a new base class";
                    else
                        rOpt.Description = "Existing references are replaces with one reference to a base class";

                    if (key is DomainClass)
                    {
                        rOpt.BaseClass = (key as DomainClass);

                        if (!rOpt.InvolvedClasses.Contains(rOpt.BaseClass))
                            rOpt.InvolvedClasses.Add(rOpt.BaseClass);
                    }

                    foreach (DomainRelationship r in rels)
                    {
                        if( !rOpt.InvolvedClasses.Contains(r.Target.RolePlayer as DomainClass) )
                            rOpt.InvolvedClasses.Add(r.Target.RolePlayer as DomainClass);
                        if( !rOpt.InvolvedRelationships.Contains(r) )
                            rOpt.InvolvedRelationships.Add(r);
                    }

                    if (rels[0] is ReferenceRelationship)
                        rOpt.IsEmbedding = false;
                    else
                        rOpt.IsEmbedding = true;

                    opt.Add(rOpt);
                }
            }
           
            return opt;
        }

        private bool UseIntermediate(ICollection rels)
        {
            string bClass = null;
            bool bIntermediate = false;
            foreach (DomainRelationship r in rels)
            {
                if (bClass == null)
                {
                    if (r.Target.RolePlayer.BaseElement != null)
                        bClass = r.Target.RolePlayer.BaseElement.Name;
                    else
                        bClass = "";
                }
                else
                {
                    if (bClass == "" && r.Target.RolePlayer.BaseElement != null)
                        bIntermediate = true;
                    else if (bClass != "" && r.Target.RolePlayer.BaseElement == null)
                        bIntermediate = true;
                    else if (r.Target.RolePlayer.BaseElement != null)
                        if (r.Target.RolePlayer.BaseElement.Name != bClass)
                            bIntermediate = true;
                }

                if (bIntermediate)
                    break;
            }

            return bIntermediate;
        }
        private Dictionary<object, List<DomainRelationship>> GetSortedByBaseClasses(ICollection rels)
        {
            Dictionary<object, List<DomainRelationship>> ret = new Dictionary<object, List<DomainRelationship>>();
            ret.Add("NULL", new List<DomainRelationship>());

            foreach (DomainRelationship r in rels)
            {
                if (r.Target.RolePlayer.BaseElement != null)
                {
                    DomainClass d = r.Target.RolePlayer.BaseElement as DomainClass;
                    if (!ret.ContainsKey(d))
                        ret.Add(d, new List<DomainRelationship>());
                    ret[d].Add(r);
                }
                else
                    ret["NULL"].Add(r);
            }

            return ret;
        }
        private Dictionary<string, List<DomainRelationship>> GetSortedByMutliplicity(List<DomainRelationship> rels)
        {
            Dictionary<string, List<DomainRelationship>> ret = new Dictionary<string, List<DomainRelationship>>();
            foreach (DomainRelationship r in rels)
            {
                string key = GetCombinedMultiplicity(r);
                if (!ret.ContainsKey(key))
                    ret.Add(key, new List<DomainRelationship>());
                ret[key].Add(r);
            }

            return ret;
        }

        private string GetCombinedMultiplicity(DomainRelationship r)
        {
            string ret = r.Source.Multiplicity.ToString() + "_" + this.separatorGuid + "_" + r.Target.Multiplicity.ToString();
            return ret;
        }

        private List<RelationshipsOptimization> GetOptimizationsRefRelationshipsSameLevel(DomainClass start, List<DomainClass> alreadyProcessedBaseClasses)
        {
            List<RelationshipsOptimization> opt = new List<RelationshipsOptimization>();
            Dictionary<object, List<DomainClass>> embeddedClasses = new Dictionary<object, List<DomainClass>>();
            Dictionary<object, Dictionary<object, List<DomainRelationship>>> refClasses = new Dictionary<object, Dictionary<object, List<DomainRelationship>>>();

            // gather references for found embeddings
            foreach (DomainRole role in start.RolesPlayed)
                if (role.Relationship.Source == role && role.Relationship is Tum.PDE.LanguageDSL.EmbeddingRelationship)
                {
                    DomainClass target = role.Relationship.Target.RolePlayer as DomainClass;
                    if (target == null)
                        continue;

                    object bClass = "NULL";
                    if (target.BaseClass != null)
                        bClass = target.BaseClass;

                    if (!embeddedClasses.ContainsKey(bClass))
                        embeddedClasses.Add(bClass, new List<DomainClass>());
                    embeddedClasses[bClass].Add(target);

                    foreach(DomainClass dClass in target.DerivedClasses)
                    {
                        object bClass2 = "NULL";
                        if (dClass.BaseClass != null)
                            bClass2 = dClass.BaseClass;

                        if (!embeddedClasses.ContainsKey(bClass2))
                            embeddedClasses.Add(bClass2, new List<DomainClass>());
                        embeddedClasses[bClass2].Add(dClass);
                    }
                }

            // gather references for found embeddings
            foreach(object key in embeddedClasses.Keys)
                if( embeddedClasses[key].Count > 1 )
                {
                    refClasses.Add(key, new Dictionary<object, List<DomainRelationship>>());

                    foreach (DomainClass c in embeddedClasses[key])
                        foreach (DomainRole role in c.RolesPlayed)
                            if (role.Relationship.Source == role && role.Relationship is Tum.PDE.LanguageDSL.ReferenceRelationship)
                            {
                                DomainClass target = role.Relationship.Target.RolePlayer as DomainClass;
                                if (target == null)
                                    continue;
                                if (!embeddedClasses[key].Contains(target))
                                    continue;

                                object bClass = "NULL";
                                if (target.BaseClass != null)
                                    bClass = target.BaseClass;

                                if (!refClasses[key].ContainsKey(bClass))
                                    refClasses[key].Add(bClass, new List<DomainRelationship>());
                                refClasses[key][bClass].Add(role.Relationship);
                            }
                }

            // continue with children
            foreach (DomainRole role in start.RolesPlayed)
                if (role.Relationship.Source == role && role.Relationship is Tum.PDE.LanguageDSL.EmbeddingRelationship)
                {
                    if (!(role.Relationship.Source.RolePlayer is DomainClass))
                        continue;
                    if (!(role.Relationship.Target.RolePlayer is DomainClass))
                        continue;

                    DomainClass target = role.Relationship.Target.RolePlayer as DomainClass;
                    if (target == null)
                        continue;
                    if (!alreadyProcessedBaseClasses.Contains(target))
                    {
                        alreadyProcessedBaseClasses.Add(target);
                        opt.AddRange(GetOptimizationsRefRelationshipsSameLevel(target, alreadyProcessedBaseClasses));
                    }
                }

            // Create opt
            if(refClasses.Keys.Count >0 )
                foreach(object key in refClasses.Keys)
                    if (refClasses[key].Count > 0)
                    {
                        foreach(object key2 in refClasses[key].Keys)
                            if (refClasses[key][key2].Count > 1)
                            {
                                // create optimization 
                                RelationshipsReferencesBetweenBaseClassesOptimization rOpt = new RelationshipsReferencesBetweenBaseClassesOptimization(this.MetaModel, this.ModelContext);
                                rOpt.Title = "Reference Relationship Optimization";
                                rOpt.Description = "Existing references are replaces with one reference. WARNING: This might extend/restrict existing constraints.";

                                if (key != key2)
                                    continue;

                                if (key is DomainClass)
                                    rOpt.BaseClass = key as DomainClass;

                                if (key2 is DomainClass)
                                    rOpt.BaseClassTarget = key2 as DomainClass;

                                // add classes and relationships
                                foreach (DomainRelationship r in refClasses[key][key2])
                                {
                                    if (!rOpt.InvolvedClasses.Contains(r.Source.RolePlayer as DomainClass))
                                        rOpt.InvolvedClasses.Add(r.Source.RolePlayer as DomainClass);
                                    if (!rOpt.InvolvedClasses.Contains(r.Target.RolePlayer as DomainClass))
                                        rOpt.InvolvedClasses.Add(r.Target.RolePlayer as DomainClass);
                                    if (!rOpt.InvolvedRelationships.Contains(r))
                                        rOpt.InvolvedRelationships.Add(r);
                                }

                                if (rOpt.BaseClass is DomainClass)
                                    if (!rOpt.InvolvedClasses.Contains(rOpt.BaseClass))
                                        rOpt.InvolvedClasses.Add(rOpt.BaseClass);
                                if (rOpt.BaseClassTarget is DomainClass)
                                    if (!rOpt.InvolvedClasses.Contains(rOpt.BaseClassTarget))
                                        rOpt.InvolvedClasses.Add(rOpt.BaseClassTarget);

                                opt.Add(rOpt);
                            }
                    }

            return opt;
        }
    }
}
