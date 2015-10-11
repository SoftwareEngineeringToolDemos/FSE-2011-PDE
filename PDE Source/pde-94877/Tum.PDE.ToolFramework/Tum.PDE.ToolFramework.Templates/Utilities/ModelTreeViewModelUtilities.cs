using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Tum.PDE.LanguageDSL;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Templates
{
    public static partial class CodeGenerationUtilities
    {
        /// <summary>
        /// Returns a collection of ModelTreeChildElementCreationInfo for the given domain class.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Collection<ModelTreeChildElementCreationInfo> GetModelTreeChildElementCreationInfo(DomainClass d)
        {
            DomainClass domainClass = d;
            SortedDictionary<string, ModelTreeChildElementCreationInfo> connections = new SortedDictionary<string, ModelTreeChildElementCreationInfo>();
            Collection<ModelTreeChildElementCreationInfo> connectionsRet = new Collection<ModelTreeChildElementCreationInfo>();

            foreach (DomainRole r in domainClass.RolesPlayed)
            {
                if (r.Relationship is EmbeddingRelationship && r.Relationship.Source == r && r.Relationship.InheritanceModifier != InheritanceModifier.Abstract)
                {
                    EmbeddingRelationship emb = r.Relationship as EmbeddingRelationship;

                    ModelTreeChildElementCreationInfo info = new ModelTreeChildElementCreationInfo();
                    List<AttributedDomainElement> classes = new List<AttributedDomainElement>();
                    info.Role = r.Opposite;
                    info.TargetElements = new List<AttributedDomainElement>();

                    if (emb.Target.RolePlayer.InheritanceModifier != InheritanceModifier.Abstract)
                        classes.Add(emb.Target.RolePlayer);

                    connections.Add(emb.Target.Name, info);

                    // include derived classes o the child side
                    AttributedDomainElement child = emb.Target.RolePlayer;
                    classes.AddRange(GetNonAbstractDerivedElements(child));

                    // sort by inheritance
                    info.TargetElements.AddRange(SortDomainClassesByInheritance(classes));
                }
            }

            foreach (string key in connections.Keys)
                connectionsRet.Add(connections[key]);

            return connectionsRet;
        }

        /// <summary>
        /// Returns all non abstract derived classes of the given elements.
        /// </summary>
        private static List<AttributedDomainElement> GetNonAbstractDerivedElements(AttributedDomainElement child)
        {
            List<AttributedDomainElement> derivedClassesCollection = new List<AttributedDomainElement>();

            if (child is DomainClass)
            {
                ReadOnlyCollection<DomainClassReferencesBaseClass> derivedClasses =
                    DomainRoleInfo.GetElementLinks<DomainClassReferencesBaseClass>(child, DomainClassReferencesBaseClass.BaseClassDomainRoleId);
                foreach (DomainClassReferencesBaseClass c in derivedClasses)
                {
                    if (c.DerivedClass.InheritanceModifier != InheritanceModifier.Abstract)
                        derivedClassesCollection.Add(c.DerivedClass);

                    derivedClassesCollection.AddRange(GetNonAbstractDerivedElements(c.DerivedClass));
                }
            }
            else if (child is DomainRelationship)
            {
                ReadOnlyCollection<DomainRelationshipReferencesBaseRelationship> derivedClasses =
                    DomainRoleInfo.GetElementLinks<DomainRelationshipReferencesBaseRelationship>(child, DomainRelationshipReferencesBaseRelationship.BaseRelationshipDomainRoleId);
                foreach (DomainRelationshipReferencesBaseRelationship c in derivedClasses)
                {
                    if (c.DerivedRelationship.InheritanceModifier != InheritanceModifier.Abstract)
                        derivedClassesCollection.Add(c.DerivedRelationship);

                    derivedClassesCollection.AddRange(GetNonAbstractDerivedElements(c.DerivedRelationship));
                }
            }

            return derivedClassesCollection;
        }

        /*
        /// <summary>
        /// Returns a collection of ModelTreeChildElementCreationInfo for the given domain class.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Collection<ModelTreeChildElementCreationInfo> GetModelTreeChildElementCreationInfo(DomainClass d)
        {
            DomainClass domainClass = d;
            SortedDictionary<string, ModelTreeChildElementCreationInfo> connections = new SortedDictionary<string, ModelTreeChildElementCreationInfo>();
            Collection<ModelTreeChildElementCreationInfo> connectionsRet = new Collection<ModelTreeChildElementCreationInfo>();

            // include base classes
            while (domainClass != null)
            {
                foreach (DomainRole r in domainClass.RolesPlayed)
                {
                    if (r.Relationship is EmbeddingRelationship && r.Relationship.Source == r && r.Relationship.InheritanceModifier != InheritanceModifier.Abstract)
                    {
                        EmbeddingRelationship emb = r.Relationship as EmbeddingRelationship;
                        ModelTreeChildElementCreationInfo info = new ModelTreeChildElementCreationInfo();
                        info.Role = r.Opposite;
                        info.TargetElements = new List<AttributedDomainElement>();

                        if (emb.Target.RolePlayer.InheritanceModifier != InheritanceModifier.Abstract)
                            info.TargetElements.Add(emb.Target.RolePlayer);

                        connections.Add(emb.Target.Name, info);

                        // include derived classes o the child side
                        AttributedDomainElement child = emb.Target.RolePlayer;
                        info.TargetElements.AddRange(GetNonAbstractDerivedElements(child));
                    }
                }

                if (domainClass is DomainClass)
                    domainClass = (domainClass as DomainClass).BaseClass;
                else
                    break;
            }

            foreach (string key in connections.Keys)
                connectionsRet.Add(connections[key]);
            return connectionsRet;

        }

        /// <summary>
        /// Returns a collection of ModelTreeChildElementCreationInfo for the given diagram class.
        /// </summary>
        /// <returns></returns>
        public static Collection<ModelTreeChildElementCreationInfo> GetModelTreeChildElementCreationInfo(DiagramClass diagramClass)
        {
            SortedDictionary<string, ModelTreeChildElementCreationInfo> connections = new SortedDictionary<string, ModelTreeChildElementCreationInfo>();
            Collection<ModelTreeChildElementCreationInfo> connectionsRet = new Collection<ModelTreeChildElementCreationInfo>();

            foreach (PresentationElementClass element in diagramClass.PresentationElements)
                if (element is ShapeClass &&
                    !(element is MappingRelationshipShapeClass))
                {

                }


            foreach (string key in connections.Keys)
                connectionsRet.Add(connections[key]);
            return connectionsRet;

        }

        /// <summary>
        /// Returns a collection of ModelTreeChildElementCreationInfo for the given list of shape classes.
        /// </summary>
        /// <returns></returns>
        public static Collection<ModelTreeChildElementCreationInfo> GetModelTreeChildElementCreationInfo(List<ShapeClass> shapeClasses)
        {
            SortedDictionary<string, ModelTreeChildElementCreationInfo> connections = new SortedDictionary<string, ModelTreeChildElementCreationInfo>();
            Collection<ModelTreeChildElementCreationInfo> connectionsRet = new Collection<ModelTreeChildElementCreationInfo>();

            List<DomainClass> domainClasses = new List<DomainClass>();
            foreach (PresentationElementClass element in shapeClasses)
                if (element is ShapeClass &&
                    !(element is MappingRelationshipShapeClass))
                {
                    ShapeClass shapeClass = element as ShapeClass;
                    domainClasses.Add(shapeClass.DomainClass);
                }

            // TODO


            foreach (string key in connections.Keys)
                connectionsRet.Add(connections[key]);
            return connectionsRet;

        }
        */
    }
}
