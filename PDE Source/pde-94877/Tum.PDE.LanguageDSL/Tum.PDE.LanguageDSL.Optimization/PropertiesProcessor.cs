using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Optimization
{
    public class PropertiesProcessor : BaseProcessor
    {
        private string separator;
        private string separatorAdv;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="metaModel"></param>
        /// <param name="modelContext"></param>
        public PropertiesProcessor(MetaModel metaModel, LibraryModelContext modelContext)
            : base(metaModel, modelContext)
        {
            this.separator = Guid.NewGuid().ToString();
            this.separatorAdv = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets optimizations.
        /// </summary>
        /// <returns></returns>
        public override List<BaseOptimization> GetOptimizations()
        {
            List<BaseOptimization> opt = new List<BaseOptimization>();
            opt.AddRange(GetOptimizations(this.ModelContext.Classes, new List<DomainClass>(), false));

            return opt;
        }

        private List<PropertiesOptimization> GetOptimizations(IEnumerable<DomainClass> classes, List<DomainClass> alreadyProcessedBaseClasses, bool isInheritance)
        {
            List<PropertiesOptimization> opt = new List<PropertiesOptimization>();

            Dictionary<string, SortedDictionary<Guid, DomainClass>> dict = new Dictionary<string, SortedDictionary<Guid, DomainClass>>();
            Dictionary<string, List<DomainProperty>> dictProperties = new Dictionary<string, List<DomainProperty>>();

            #region gather properties
            foreach (DomainClass domainClass in classes)
            {
                //if (alreadyProcessed.Contains(domainClass))
                //    continue;
                //alreadyProcessed.Add(domainClass);

                if (!isInheritance)
                    if (domainClass.BaseClass != null)
                    {
                        if (alreadyProcessedBaseClasses.Contains(domainClass.BaseClass))
                            continue;

                        alreadyProcessedBaseClasses.Add(domainClass.BaseClass);
                        List<DomainClass> cDer = new List<DomainClass>();
                        foreach(DomainClass cD in domainClass.BaseClass.DerivedClasses)
                            if( cD.GetMetaModel() == this.MetaModel )
                                cDer.Add(cD);
                        opt.AddRange(GetOptimizations(cDer, alreadyProcessedBaseClasses, true));
                    }

                if (domainClass.BaseClass != null && !isInheritance)
                    continue;

                foreach (DomainProperty domainProperty in domainClass.Properties)
                {
                    if (domainProperty.Type == null)
                        continue;

                    if (String.IsNullOrEmpty(domainProperty.Name))
                        continue;

                    string key = domainProperty.Name + "_" + separator + "_" + domainProperty.Type.Name;
                    if (!String.IsNullOrEmpty(domainProperty.Type.Namespace))
                        key += "_" + separator + "_" + domainProperty.Type.Namespace;

                    if (!dict.ContainsKey(key))
                        dict.Add(key, new SortedDictionary<Guid, DomainClass>());
                    if (!dictProperties.ContainsKey(key))
                    {
                        dictProperties.Add(key, new List<DomainProperty>());
                        dictProperties[key].Add(domainProperty);
                    }

                    if (!dict[key].ContainsKey(domainClass.Id))
                        dict[key].Add(domainClass.Id, domainClass);
                }
            }
            #endregion

            #region delete properties that are not required
            List<string> toDelete = new List<string>();
            foreach (string key in dict.Keys)
                if (dict[key].Count <= 1)
                    toDelete.Add(key);
            foreach (string key in toDelete)
                dict.Remove(key);
            #endregion

            #region merge properties that reference the same elements
            Dictionary<int, List<string>> dictCount = new Dictionary<int, List<string>>();
            foreach (string key in dict.Keys)
            {
                int count = dict[key].Count;
                if (!dictCount.ContainsKey(count))
                    dictCount.Add(count, new List<string>());
                dictCount[count].Add(key);
            }

            Dictionary<int, List<string>> mergerDict = new Dictionary<int, List<string>>();
            foreach (int key in dictCount.Keys)
            {
                // compare and see if there are equal entries
                for (int i = dictCount[key].Count - 1; i >= 0; i--)
                    for (int y = i - 1; y >= 0; y--)
                    {
                        string n1 = dictCount[key][i];
                        string n2 = dictCount[key][y];

                        // compare
                        if (Compare(dict[n1], dict[n2]))
                        {
                            bool bAdded = false;
                            foreach (int mergerKey in mergerDict.Keys)
                            {
                                if (mergerDict[mergerKey].Contains(n1) || mergerDict[mergerKey].Contains(n2))
                                {
                                    if (!mergerDict[mergerKey].Contains(n1))
                                        mergerDict[mergerKey].Add(n1);
                                    if (!mergerDict[mergerKey].Contains(n2))
                                        mergerDict[mergerKey].Add(n2);
                                    bAdded = true;
                                    break;
                                }
                            }

                            if (!bAdded)
                            {
                                int index = mergerDict.Count;
                                mergerDict.Add(index, new List<string>());
                                mergerDict[index].Add(n1);
                                mergerDict[index].Add(n2);
                            }
                        }
                    }
            }

            foreach (int key in mergerDict.Keys)
            {
                List<string> vals = mergerDict[key];
                string newKey = CreateNewKey(vals);

                dict.Add(newKey, new SortedDictionary<Guid, DomainClass>());
                dictProperties.Add(newKey, new List<DomainProperty>());

                bool bAdded = false;
                foreach (string k in vals)
                {
                    dictProperties[newKey].AddRange(dictProperties[k]);

                    if (!bAdded)
                        foreach (Guid id in dict[k].Keys)
                            dict[newKey].Add(id, dict[k][id]);
                    bAdded = true;
                    dict.Remove(k);
                }
            }

            #endregion

            opt.AddRange(this.GetOptimizationsAdv(dict, dictProperties, isInheritance));

            #region create optimizations based on gathered properties directly
            foreach (string key in dict.Keys)
            {
                opt.Add(CreateOptimization(key, dict, dictProperties, isInheritance));
            }

            #endregion


            return opt;
        }
        private PropertiesOptimization CreateOptimization(string key, Dictionary<string, SortedDictionary<Guid, DomainClass>> dict, Dictionary<string, List<DomainProperty>> dictProperties, bool isInheritance)
        {
            PropertiesOptimization pO = new PropertiesOptimization(this.MetaModel, this.ModelContext);
            pO.InvolvedProperties.AddRange(dictProperties[key]);
            foreach (Guid id in dict[key].Keys)
            {
                pO.InvolvedClasses.Add(dict[key][id]);
                if (isInheritance)
                {
                    // add inheritance relationship
                    ReadOnlyCollection<DomainClassReferencesBaseClass> col = DomainRoleInfo.GetElementLinks<DomainClassReferencesBaseClass>(dict[key][id], DomainClassReferencesBaseClass.DerivedClassDomainRoleId);
                    pO.InvolvedInheritancesRelationships.Add(col[0]);
                }
            }
            if (isInheritance)
                pO.Description = "Move properties from derived class to basis class:";
            else
                pO.Description = "Creates a new base class containing properties for derived classes:";
            pO.Title = "Properties Optimization";
            pO.IsInheritance = isInheritance;
            if (pO.IsInheritance)
            {
                // add base class 
                DomainClass d = dict[key][dict[key].Keys.ElementAt(0)];
                pO.BaseClass = d.BaseClass;

                bool bCreateIntermediate = false;
                if (pO.InvolvedClasses.Count != d.DerivedClasses.Count)
                    bCreateIntermediate = true;
                pO.CreateIntermediate = bCreateIntermediate;

                pO.InvolvedClasses.Add(d.BaseClass);
            }

            return pO;
        }

        private List<PropertiesOptimization> GetOptimizationsAdv(Dictionary<string, SortedDictionary<Guid, DomainClass>> dict, Dictionary<string, List<DomainProperty>> dictProperties, bool isInheritance)
        {
            List<PropertiesOptimization> opt = new List<PropertiesOptimization>();

            if (dict.Keys.Count > 0)
            {
                Dictionary<string, SortedDictionary<Guid, DomainClass>> dictAdv = new Dictionary<string, SortedDictionary<Guid, DomainClass>>();
                Dictionary<string, List<DomainProperty>> dictPropertiesAdv = new Dictionary<string, List<DomainProperty>>();

                for (int i = dict.Keys.Count - 1; i >= 0; i--)
                    for (int y = i - 1; y >= 0; y--)
                    {
                        string n = dict.Keys.ElementAt(i);
                        string m = dict.Keys.ElementAt(y);

                        SortedDictionary<Guid, DomainClass> d = GetEqualClasses(dict[n], dict[m]);
                        if (d.Count > 1)
                        {
                            string newKey = this.CreateNewKey(n, m);

                            if (!dictAdv.ContainsKey(newKey))
                            {
                                dictAdv.Add(newKey, d);
                                dictPropertiesAdv.Add(newKey, new List<DomainProperty>());

                                dictPropertiesAdv[newKey].AddRange(dictProperties[n]);
                                
                                foreach (DomainProperty p in dictProperties[m])
                                    if (!HasProperty(dictPropertiesAdv[newKey], p))
                                        dictPropertiesAdv[newKey].Add(p);
                            }
                            else
                            {
                                foreach (DomainProperty p in dictProperties[n])
                                    if (!HasProperty(dictPropertiesAdv[newKey], p))
                                        dictPropertiesAdv[newKey].Add(p);

                                foreach (DomainProperty p in dictProperties[m])
                                    if (!HasProperty(dictPropertiesAdv[newKey], p))
                                        dictPropertiesAdv[newKey].Add(p);
                            }
                        }
                    }

                // create opt
                foreach (string key in dictAdv.Keys)
                {
                    opt.Add(CreateOptimization(key, dictAdv, dictPropertiesAdv, isInheritance));
                }

                // continue
                opt.InsertRange(0, GetOptimizationsAdv(dictAdv, dictPropertiesAdv, isInheritance));
            }
            return opt;
        }

        private bool HasProperty(List<DomainProperty> properties, DomainProperty p)
        {
            foreach (DomainProperty refP in properties)
                if (p.Name == refP.Name && p.Type.Name == refP.Type.Name && p.Type.Namespace == refP.Type.Namespace)
                    return true;

            return false;
        }
        private bool Compare(SortedDictionary<Guid, DomainClass> d1, SortedDictionary<Guid, DomainClass> d2)
        {
            if (d1.Count != d2.Count)
                return false;
            foreach (Guid key in d1.Keys)
                if (!d2.ContainsKey(key))
                    return false;

            return true;
        }
        private SortedDictionary<Guid, DomainClass> GetEqualClasses(SortedDictionary<Guid, DomainClass> d1, SortedDictionary<Guid, DomainClass> d2)
        {
            SortedDictionary<Guid, DomainClass> dict = new SortedDictionary<Guid, DomainClass>();

            foreach (Guid key in d1.Keys)
                foreach (Guid key2 in d2.Keys)
                    if (key == key2 )
                        dict.Add(key, d1[key]);

            return dict;
        }
        private string CreateNewKey(List<string> vals)
        {
            vals.Sort();
            
            string key = "";
            foreach (string k in vals)
            {
                if (key != "")
                    key += this.separatorAdv;
                key += k;
            }

            return key;
        }
        private string CreateNewKey(string n, string m)
        {
            string[] s1 = n.Split(new string[] { this.separatorAdv }, StringSplitOptions.RemoveEmptyEntries);
            string[] s2 = m.Split(new string[] { this.separatorAdv }, StringSplitOptions.RemoveEmptyEntries);
            List<string> vals = new List<string>();
            vals.AddRange(s1);

            foreach (string x in s2)
                if (!vals.Contains(x))
                    vals.Add(x);

            return CreateNewKey(vals);
        }
    }
}
