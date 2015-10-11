using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// ProtoLink contains the information needed to recreate an ElementLink in any Store.
    /// </summary>
    /// <remarks>
    /// Source: DSL-Tools framework for the most part.
    /// </remarks>
    [System.Serializable]
    public class ModelProtoLink : ModelProtoElement, ISerializable, IDeserializationCallback
    {
        private List<ModelProtoRolePlayer> rolePlayers;
        private SerializationInfo serializationInfo;
        private bool isTargetIncludedSubmodel;
        private string domainFilePath;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="link">Element link.</param>
        public ModelProtoLink(ElementLink link)
            : base(link)
        {
            if (link == null)
                throw new System.ArgumentNullException("link");

            IList<Microsoft.VisualStudio.Modeling.DomainRoleInfo> ilist = link.GetDomainRelationship().DomainRoles;
            rolePlayers = new System.Collections.Generic.List<ModelProtoRolePlayer>(2);
            for (int i = 0; i < 2; i++)
            {
                Microsoft.VisualStudio.Modeling.DomainRoleInfo domainRoleInfo = ilist[i];
                Microsoft.VisualStudio.Modeling.ModelElement modelElement = domainRoleInfo.GetRolePlayer(link);
                System.Guid guid = modelElement != null ? modelElement.Id : System.Guid.Empty;

                string name = "";
                if (modelElement is IDomainModelOwnable)
                {
                    if ((modelElement as IDomainModelOwnable).DomainElementHasName)
                        name = (modelElement as IDomainModelOwnable).DomainElementName;
                }

                rolePlayers.Add(new ModelProtoRolePlayer(domainRoleInfo.Id, guid, name));
            }

            this.isTargetIncludedSubmodel = false;
            this.domainFilePath = "";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">The SerializationInfo to get the data from.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        protected ModelProtoLink(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            serializationInfo = info;
        }

        /// <summary>
        /// Gets or sets whether the target is an included submodel.
        /// </summary>
        public bool IsTargetIncludedSubmodel
        {
            get
            {
                return this.isTargetIncludedSubmodel;
            }
            set
            {
                this.isTargetIncludedSubmodel = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the domainFilePath of the included submodel.
        /// </summary>
        public string DomainFilePath
        {
            get
            {
                return this.domainFilePath;
            }
            set
            {
                this.domainFilePath = value;
            }
        }

        /// <summary>
        /// Deserialize.
        /// </summary>
        public new void OnDeserialization(object sender)
        {
            rolePlayers = new List<ModelProtoRolePlayer>((ModelProtoRolePlayer[])serializationInfo.GetValue("rolePlayers", typeof(ModelProtoRolePlayer[])));

            isTargetIncludedSubmodel = (bool)serializationInfo.GetValue("isTargetIncludedSubmodel", typeof(bool));
            domainFilePath = (string)serializationInfo.GetValue("domainFilePath", typeof(string));

            base.OnDeserialization(sender);
        }

        /// <summary>
        /// Gets the source proto role player.
        /// </summary>
        /// <param name="partition">Partition.</param>
        /// <returns>Source proto role player.</returns>
        public ModelProtoRolePlayer GetSourceRolePlayer(Partition partition)
        {
            DomainDataDirectory domainDataDirectory = partition.Store.DomainDataDirectory;
            ModelProtoRolePlayer protoRolePlayer = rolePlayers[0];
            DomainRoleInfo domainRoleInfo = domainDataDirectory.GetDomainRole(protoRolePlayer.DomainRoleId);
            if (!domainRoleInfo.IsSource)
                protoRolePlayer = rolePlayers[1];
            return protoRolePlayer;
        }

        /// <summary>
        /// Gets the target proto role player.
        /// </summary>
        /// <param name="partition">Partition.</param>
        /// <returns>Target proto role player.</returns>
        public ModelProtoRolePlayer GetTargetRolePlayer(Partition partition)
        {
            DomainDataDirectory domainDataDirectory = partition.Store.DomainDataDirectory;
            ModelProtoRolePlayer protoRolePlayer = rolePlayers[1];
            DomainRoleInfo domainRoleInfo = domainDataDirectory.GetDomainRole(protoRolePlayer.DomainRoleId);
            if (domainRoleInfo.IsSource)
                protoRolePlayer = rolePlayers[0];
            return protoRolePlayer;
        }

        /// <summary>
        /// Populates a System.Runtime.Serialization.SerializationInfo with the data
        /// needed to serialize the target object.
        /// </summary>
        /// <param name="info">The SerializationInfo to populate with data.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            base.GetObjectData(info, context);

            info.AddValue("rolePlayers", rolePlayers.ToArray(), typeof(ModelProtoRolePlayer[]));
            info.AddValue("isTargetIncludedSubmodel", IsTargetIncludedSubmodel, typeof(bool));
            info.AddValue("domainFilePath", DomainFilePath, typeof(string));
        }
    }
}
