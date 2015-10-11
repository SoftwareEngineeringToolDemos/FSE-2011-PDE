using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This is the abstract class wrapping additional functionality for the DSL-Tools ElementLink class.
    /// </summary>
    [DomainRelationship(AllowsDuplicates=true)]
    [DomainObjectId("B63C4DC0-0D28-4244-B091-6A8D127ADD55")]
    public abstract class DomainModelLink : ElementLink, IDableElement, IDomainModelOwnable
    {
        /// <summary>
        /// Domain class id.
        /// </summary>
        public static readonly new global::System.Guid DomainClassId = new System.Guid("B63C4DC0-0D28-4244-B091-6A8D127ADD55");
        
        /// <summary>
        /// Creates a new instance of the DomainModelLink class.
        /// </summary>
        /// <param name="partition">The Partition instance containing this ElementLink</param>
        /// <param name="roleAssignments">A set of role assignments for roleplayer initialization</param>
        /// <param name="propertyAssignments">A set of attribute assignments for attribute initialization</param>
        protected DomainModelLink(Partition partition, RoleAssignment[] roleAssignments, PropertyAssignment[] propertyAssignments)
            : base(partition, roleAssignments, propertyAssignments)
        {
        }

        #region Roles
        /// <summary>
        /// VModell domain role Id.
        /// </summary>
        internal static readonly global::System.Guid SourceElementDomainRoleId = new System.Guid("46C44A54-9D40-4426-85FB-72422C243D9C");

        /// <summary>
        /// DomainRole SourceElement
        /// </summary>
        internal virtual ModelElement SourceElement
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                return (ModelElement)DomainRoleInfo.GetRolePlayer(this, SourceElementDomainRoleId);
            }
            [global::System.Diagnostics.DebuggerStepThrough]
            set
            {
                DomainRoleInfo.SetRolePlayer(this, SourceElementDomainRoleId, value);
            }
        }

        /// <summary>
        /// VModell domain role Id.
        /// </summary>
        internal static readonly global::System.Guid TargetElementDomainRoleId = new System.Guid("A30351A3-CB4A-41A3-AA98-F290EB1357DD");

        /// <summary>
        /// DomainRole TargetElement
        /// </summary>
        internal virtual ModelElement TargetElement
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                return (ModelElement)DomainRoleInfo.GetRolePlayer(this, TargetElementDomainRoleId);
            }
            [global::System.Diagnostics.DebuggerStepThrough]
            set
            {
                DomainRoleInfo.SetRolePlayer(this, TargetElementDomainRoleId, value);
            }
        }
        #endregion

        #region IDomainModelOwnable
        /*
        /// <summary>
        /// Gets the document data
        /// </summary>
        public abstract ModelData DocumentData
        {
            get;
        }*/

        /// <summary>
        /// Gets the domain model type.
        /// </summary>
        /// <returns>Domain model type.</returns>
        public abstract System.Type GetDomainModelType();

        /// <summary>
        /// Gets the domain model services.
        /// </summary>
        /// <returns>Domain model services.</returns>
        public abstract IDomainModelServices GetDomainModelServices();

        /// <summary>
        /// Gets the domain model DomainClassId.
        /// </summary>
        /// <returns></returns>
        public abstract System.Guid GetDomainModelTypeId();

        /// <summary>
        /// Gets or sets the value of the property (which is marked as element name)
        /// </summary>
        public abstract string DomainElementName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the full name of the element.
        /// </summary>
        /// <remarks>
        /// This is either: ElementName (elemenType) or just ElementType.
        /// </remarks>
        public virtual string DomainElementFullName
        {
            get
            {
                if (this.DomainElementHasName)
                    return this.DomainElementName + " (" + this.DomainElementTypeDisplayName + ")";
                else
                    return this.DomainElementTypeDisplayName;
            }
        }

        /// <summary>
        /// Gets whether the domain element has a property marked as element name.
        /// </summary>
        public abstract bool DomainElementHasName
        {
            get;
        }

        /// <summary>
        /// Gets the domain element name info if there is one; Null otherwise.
        /// </summary>
        public abstract DomainPropertyInfo DomainElementNameInfo
        {
            get;
        }

        /// <summary>
        /// Gets the type of the ModelElement as string.
        /// </summary>
        public abstract string DomainElementType
        {
            get;
        }

        /// <summary>
        /// Gets the display name of the type of the ModelElement.
        /// </summary>
        public abstract string DomainElementTypeDisplayName
        {
            get;
        }
        #endregion

        /// <summary>
        /// Gets the domain model store.
        /// </summary>
        public new DomainModelStore Store
        {
            get
            {
                return base.Store as DomainModelStore;
            }
        }

        /// <summary>
        /// Gets the domain class Id of this element.
        /// </summary>
        /// <returns>DomainClass Id.</returns>
        public abstract Guid GetDomainClassId();

        /// <summary>
        /// Gets whether this is an embedding relationship or not.
        /// </summary>
        public abstract bool IsEmbedding
        {
            get;
        }
    }
}
