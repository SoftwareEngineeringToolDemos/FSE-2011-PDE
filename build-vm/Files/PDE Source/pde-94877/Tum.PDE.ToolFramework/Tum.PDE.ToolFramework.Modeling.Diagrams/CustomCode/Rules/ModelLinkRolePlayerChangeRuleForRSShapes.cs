using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// This RolePlayerChangeRule is for monitoring embedding relationship changes that we need to reflect
    /// onto the diagram surface by removing and recreating its specified shape class if necessary.
    /// </summary>	
    public abstract class ModelLinkRolePlayerChangeRuleForRSShapes : RolePlayerChangeRule
    {
        private RolePlayerChangeHelper rpHelper;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rpHelper"></param>
        public ModelLinkRolePlayerChangeRuleForRSShapes(RolePlayerChangeHelper rpHelper)
        {
            this.rpHelper = rpHelper;
        }

        /// <summary>
        /// Called on role player changes.
        /// </summary>
        /// <param name="e"></param>
        public override void RolePlayerChanged(RolePlayerChangedEventArgs e)
        {
            base.RolePlayerChanged(e);

            if (e.ElementLink == null)
                return;

            if (e.ElementLink.Store.InSerializationTransaction)
                return;

            this.rpHelper.OnRolePlayerChanged(e);
        }

        /// <summary>
        /// Helper class.
        /// </summary>
        public abstract class RolePlayerChangeHelper
        {
            private ModelLinkAddRuleForRSShapes.RSShapesFactoryHelper factoryHelper;
            private ModelElementDeletingRuleForRSShapes.ShapeDeletionHelper deletionHelper;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="factoryHelper">Factory helper.</param>
            /// <param name="deletionHelper">Deletion helper.</param>
            protected RolePlayerChangeHelper(ModelLinkAddRuleForRSShapes.RSShapesFactoryHelper factoryHelper, ModelElementDeletingRuleForRSShapes.ShapeDeletionHelper deletionHelper)
            {
                this.factoryHelper = factoryHelper;
                this.deletionHelper = deletionHelper;
            }

            /// <summary>
            /// Called whenever a role player changed ever has occured.
            /// </summary>
            /// <param name="e"></param>
            public void OnRolePlayerChanged(RolePlayerChangedEventArgs e)
            {
                DomainModelLink con = e.ElementLink as DomainModelLink;
                if (con != null)
                {
                    this.deletionHelper.DeleteShapesForElement(con);
                    this.factoryHelper.AddRSShapesForElement(con);
                }
            }
        }
    }
}
