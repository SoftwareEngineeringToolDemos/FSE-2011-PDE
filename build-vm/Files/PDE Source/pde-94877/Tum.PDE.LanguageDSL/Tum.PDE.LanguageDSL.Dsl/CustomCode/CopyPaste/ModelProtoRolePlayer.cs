using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tum.PDE.LanguageDSL.CopyPaste
{
    /// <summary>
    /// ProtoRolePlayer contains the data necessary to set the rolePlayer data on an ElementLink.
    /// </summary>
    /// <remarks>
    /// Source: DSL-Tools framework for the most part.
    /// </remarks>
    [System.Serializable]
    public class ModelProtoRolePlayer : ISerializable
    {
        private readonly System.Guid domainRoleId;
        private readonly System.Guid rolePlayerId;
        private string elementName;

        /// <summary>
        /// Gets the domain role Id.
        /// </summary>
        public Guid DomainRoleId
        {
            get
            {
                return domainRoleId;
            }
        }

        /// <summary>
        /// Gets the role player Id.
        /// </summary>
        public Guid RolePlayerId
        {
            get
            {
                return rolePlayerId;
            }
        }

        /// <summary>
        /// Gets the element name.
        /// </summary>
        public string ElementName
        {
            get
            {
                return elementName;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="domainRoleId">Guid of the DomainRole that this role player plays.</param>
        /// <param name="rolePlayerId">Guid of the role player itself.</param>
        /// <param name="elementName">Name of the role player.</param>
        public ModelProtoRolePlayer(Guid domainRoleId, Guid rolePlayerId, string elementName)
        {
            if (domainRoleId == System.Guid.Empty)
                throw new System.ArgumentNullException("domainRoleId");

            this.elementName = elementName;
            this.domainRoleId = domainRoleId;
            this.rolePlayerId = rolePlayerId;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">The SerializationInfo to get the data from.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        protected ModelProtoRolePlayer(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            domainRoleId = (System.Guid)info.GetValue("domainRoleId", typeof(Guid));
            
            try
            {
                rolePlayerId = (System.Guid)info.GetValue("rolePlayerId", typeof(Guid));
            }
            catch (SerializationException)
            {
                rolePlayerId = System.Guid.Empty;
            }

            elementName = (string)info.GetValue("elementName", typeof(string));            
        }

        /// <summary>
        /// Populates a System.Runtime.Serialization.SerializationInfo with the data
        /// needed to serialize the target object.
        /// </summary>
        /// <param name="info">The SerializationInfo to populate with data.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("domainRoleId", domainRoleId, typeof(Guid));
            info.AddValue("rolePlayerId", rolePlayerId, typeof(Guid));
            info.AddValue("elementName", elementName, typeof(string));
        }
    }
}
