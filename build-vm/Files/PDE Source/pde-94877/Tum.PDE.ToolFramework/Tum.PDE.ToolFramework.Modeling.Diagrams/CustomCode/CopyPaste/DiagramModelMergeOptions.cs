using System;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [Serializable]
    public class DiagramModelMergeOptions : IModelMergeCustomArguments
    {
        public string LayoutInfoString
        {
            get;
            private set;
        }
        public Guid ElementId
        {
            get;
            private set;
        }
        public Guid DomainClassId
        {
            get;
            private set;
        }
        public Guid ShapeDomainClassId
        {
            get;
            private set;
        }        
        public PointD RelativeLocation = PointD.Empty;

        public DiagramModelMergeOptions(LayoutInfo info, Guid elementId, Guid domainClassId, Guid shapeDomainClassId)
        {
            // save layout info as string
            this.LayoutInfoString = DiagramsDSLSerializationHelper.Instance.ConvertLayoutInfoToString(info);
            info.Delete();

            this.ElementId = elementId;
            this.DomainClassId = domainClassId;
            this.ShapeDomainClassId = shapeDomainClassId;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">The SerializationInfo to get the data from.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        protected DiagramModelMergeOptions(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            this.LayoutInfoString = (string)info.GetValue("layoutInfo", typeof(string));
            this.ElementId = (Guid)info.GetValue("elementId", typeof(Guid));
            this.DomainClassId = (Guid)info.GetValue("domainClassId", typeof(Guid));
            this.ShapeDomainClassId = (Guid)info.GetValue("shapeDomainClassId", typeof(Guid));
            this.RelativeLocation = (PointD)info.GetValue("relativeLocation", typeof(PointD));
        }

        public LayoutInfo GetLayoutInfo(Store store)
        {
            return DiagramsDSLSerializationHelper.Instance.ConvertStringToLayoutInfo(this.LayoutInfoString, store);
        }
        public Type GetSerializerType()
        {
            return typeof(DiagramModelMergeOptions);
        }
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("layoutInfo", this.LayoutInfoString, typeof(string));
            info.AddValue("elementId", this.ElementId, typeof(Guid));
            info.AddValue("domainClassId", this.DomainClassId, typeof(Guid));
            info.AddValue("shapeDomainClassId", this.ShapeDomainClassId, typeof(Guid));
            info.AddValue("relativeLocation", this.RelativeLocation, typeof(PointD));
        }
    }
}
