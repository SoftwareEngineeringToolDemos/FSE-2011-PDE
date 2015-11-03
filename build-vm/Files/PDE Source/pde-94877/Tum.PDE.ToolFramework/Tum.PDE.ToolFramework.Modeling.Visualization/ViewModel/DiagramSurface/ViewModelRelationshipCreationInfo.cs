using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface
{
    /// <summary>
    /// Class hosting information about a relationship, that should be created.
    /// </summary>
    public class ViewModelRelationshipCreationInfo
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">View model holding the source element.</param>
        /// <param name="target">View model holding the target element.</param>
        public ViewModelRelationshipCreationInfo(BaseDiagramItemElementViewModel source, BaseDiagramItemElementViewModel target)
        {
            this.Source = source;
            this.Target = target;

            this.ProposedSourcePoint = null;
            this.ProposedTargetPoint = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">View model holding the source element.</param>
        /// <param name="target">View model holding the target element.</param>
        public ViewModelRelationshipCreationInfo(object source, object target)
        {
            if (!(source is BaseDiagramItemElementViewModel))
                this.Source = null;
            else
                this.Source = source as BaseDiagramItemElementViewModel;

            if (!(target is BaseDiagramItemElementViewModel))
                this.Target = null;
            else
                this.Target = target as BaseDiagramItemElementViewModel;

            this.ProposedSourcePoint = null;
            this.ProposedTargetPoint = null;
        }

        /// <summary>
        /// Gets the view model that holds the source of the relationship, that is to be created.
        /// </summary>
        public BaseDiagramItemElementViewModel Source
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the view model that holds the target of the relationship, that is to be created.
        /// </summary>
        public BaseDiagramItemElementViewModel Target
        {
            get;
            private set;
        }

        /// <summary>
        /// Proposed source point for the link.
        /// </summary>
        public PointD? ProposedSourcePoint
        {
            get;
            set;
        }

        /// <summary>
        /// Proposed target point for the link.
        /// </summary>
        public PointD? ProposedTargetPoint
        {
            get;
            set;
        }
    }
}
