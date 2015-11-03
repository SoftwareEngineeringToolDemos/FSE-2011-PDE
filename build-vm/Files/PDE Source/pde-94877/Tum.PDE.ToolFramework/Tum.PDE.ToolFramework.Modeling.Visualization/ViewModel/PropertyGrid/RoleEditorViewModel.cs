using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// This is the base abstract class for a role editor. An role editor as such is expected to have some sort
    /// of a default list to choose the elements as well as currently selected element(s).
    /// 
    /// A role editor view model requires the following properties:
    /// - DomainRelationshipInfo: This is the domain relationship type we are modifying.
    /// - SourceRoleId: Source role Id relative to what role we are actually editing. (In some cases this will be the
    ///   target role Id of the actual relationship).
    ///   
    /// Filtering: The default filter function takes the multiplicity of a relationship into account:
    /// (This is always from the view of the SourceRole):
    /// - 'n:m': nothing needs to be filtered.
    /// - '0..1:n' or '1:n': All target role players, that are already in a relationship needs to be removed. 
    /// - 'n:1' or 'n:0..1': Nothing needs to be removed.
    /// - '0..1:1' or '1:0..1' or '0..1:0..1': All target role players, that are already in a relationship needs to be removed.
    /// Further, the filtering considers already existent relationships and the AllowsDuplicates property: This
    /// removes target role players if they are already in relation (relatinoship of the type we are editing here) 
    /// with the source element.
    /// 
    /// Subscribe to changes: 
    /// We are subscribing to property changes by default via: 
    /// - ModelElementAddedEvent
    /// - ModelElementDeletedEvent
    /// - ModelRolePlayerChangedEvent
    /// </summary>
    public abstract class RoleEditorViewModel : LookupListEditorViewModel
    {  
        private DomainRelationshipInfo domainRelationshipInfo;
        private DomainRoleInfo sourceDomainRoleInfo;
        private DomainRoleInfo targetDomainRoleInfo;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="domainRelationshipInfo">Relationship domain class info.</param>
        /// <param name="sourceRoleId">RoleId of the source role player. </param>
        protected RoleEditorViewModel(ViewModelStore viewModelStore, DomainRelationshipInfo domainRelationshipInfo, Guid sourceRoleId)
            : base(viewModelStore)
        {
            this.domainRelationshipInfo = domainRelationshipInfo;
            if (domainRelationshipInfo.DomainRoles[0].Id == sourceRoleId)
            {
                sourceDomainRoleInfo = domainRelationshipInfo.DomainRoles[0];
                targetDomainRoleInfo = domainRelationshipInfo.DomainRoles[1];
            }
            else
            {
                sourceDomainRoleInfo = domainRelationshipInfo.DomainRoles[1];
                targetDomainRoleInfo = domainRelationshipInfo.DomainRoles[0];
            }

            this.isDefaultValuesSourceDynamic = true;

            this.Sort = SortByName;
        }

        /// <summary>
        /// Gets the source role ID. 
        /// </summary>
        public Guid SourceRoleId
        {
            get { return this.sourceDomainRoleInfo.Id; }
        }

        /// <summary>
        /// Gets the target role ID. 
        /// </summary>
        public Guid TargetRoleId
        {
            get { return this.targetDomainRoleInfo.Id; }
        }

        /// <summary>
        /// Gets the target role player domain class ID. This is used to get the default items list.
        /// </summary>
        public Guid TargetDomainClassID
        {
            get { return this.TargetDomainRoleInfo.RolePlayer.Id; }
        }

        /// <summary>
        /// Gets the relationship domain class ID. This is used to get the default items list.
        /// </summary>
        public Guid RelationshipDomainClassId
        {
            get { return this.domainRelationshipInfo.Id; }
        }

        /// <summary>
        /// Gets the domain relationship info.
        /// </summary>
        public DomainRelationshipInfo RelationshipInfo
        {
            get { return this.domainRelationshipInfo; }
        }

        /// <summary>
        /// Gets the source domain role info.
        /// </summary>
        public DomainRoleInfo SourceDomainRoleInfo
        {
            get { return this.sourceDomainRoleInfo; }
        }

        /// <summary>
        /// Gets the target domain role info.
        /// </summary>
        public DomainRoleInfo TargetDomainRoleInfo
        {
            get { return this.targetDomainRoleInfo; }
        }

        /// <summary>
        /// Subscribe to model changes.
        /// </summary>
        public override void SubscribeToModelChanges()
        {
            base.SubscribeToModelChanges();

            this.ViewModelStore.EventManager.GetEvent<ModelElementAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainClass(this.RelationshipDomainClassId), new Action<ElementAddedEventArgs>(OnRolePlayerAdded));
            this.ViewModelStore.EventManager.GetEvent<ModelElementDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainClass(this.RelationshipDomainClassId), new Action<ElementDeletedEventArgs>(OnRolePlayerDeleted));
            this.ViewModelStore.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(this.RelationshipDomainClassId), new Action<RolePlayerChangedEventArgs>(OnRolePlayerChanged)); 
        }
        private void OnRolePlayerAdded(ElementAddedEventArgs args)
        {
            OnPropertyChanged("PropertyValue");
        }
        private void OnRolePlayerDeleted(ElementDeletedEventArgs args)
        {
            OnPropertyChanged("PropertyValue");
        }
        private void OnRolePlayerChanged(RolePlayerChangedEventArgs args)
        {
            OnPropertyChanged("PropertyValue");
        }

        /// <summary>
        /// Gets the default values list. Override this method, if the default list can be acquired in a more specific way.
        /// 
        /// Hint: we return the actual elements of type ModelElement that are of the TargetRolePlayerDomainClassID type.
        /// </summary>
        /// <returns>Returns the default values list.</returns>
        protected override List<object> GetDefaultValues()
        {
            // if user supplied a custom way to get the default list, use that
            if (DefaultValuesProvider != null)
                return DefaultValuesProvider(this);

            // default
            ReadOnlyCollection<ModelElement> rolePlayersRD = this.Store.ElementDirectory.FindElements(this.TargetDomainClassID);
            List<object> rolePlayers = new List<object>();

            // return the model element as is;
            foreach (ModelElement m in rolePlayersRD)
            {
                rolePlayers.Add(m);
            }

            return rolePlayers;
        }

        /// <summary>
        /// Filter default values list.
        /// </summary>
        protected override void FilterDefaultValues(List<object> dValues)
        {
            foreach (ModelElement currentElement in this.Elements)
            {
                // '0..1:n' or '1:n': All target role players, that are already in a relationship needs to be removed. 
                if ((TargetDomainRoleInfo.Multiplicity == Multiplicity.One || TargetDomainRoleInfo.Multiplicity == Multiplicity.ZeroOne) &&
                    (SourceDomainRoleInfo.Multiplicity == Multiplicity.ZeroMany || SourceDomainRoleInfo.Multiplicity == Multiplicity.OneMany))
                {
                    ReadOnlyCollection<ModelElement> elements = this.Store.ElementDirectory.FindElements(RelationshipDomainClassId, true);
                    foreach (ElementLink link in elements)
                    {
                        for (var i = dValues.Count - 1; i >= 0; i--)
                        {
                            ModelElement m = dValues[i] as ModelElement;
                            if (m == DomainRoleInfo.GetRolePlayer(link, this.TargetRoleId))
                                dValues.RemoveAt(i);
                        }
                    }
                }
                else if ((SourceDomainRoleInfo.Multiplicity == Multiplicity.One || SourceDomainRoleInfo.Multiplicity == Multiplicity.ZeroOne) &&
                    (TargetDomainRoleInfo.Multiplicity == Multiplicity.ZeroMany || TargetDomainRoleInfo.Multiplicity == Multiplicity.OneMany))
                {
                    // 'n:1' or 'n:0..1': Nothing needs to be removed.
                }
                else if ((SourceDomainRoleInfo.Multiplicity == Multiplicity.One || SourceDomainRoleInfo.Multiplicity == Multiplicity.ZeroOne) &&
                    (TargetDomainRoleInfo.Multiplicity == Multiplicity.One || TargetDomainRoleInfo.Multiplicity == Multiplicity.ZeroOne))
                {
                    // '0..1:1' or '1:0..1' or '0..1:0..1': All target role players, that are already in a relationship needs to be removed. 
                    ReadOnlyCollection<ModelElement> elements = this.Store.ElementDirectory.FindElements(RelationshipDomainClassId, true);
                    foreach (ElementLink link in elements)
                    {
                        for (var i = dValues.Count - 1; i >= 0; i--)
                        {
                            ModelElement m = dValues[i] as ModelElement;
                            if (m == DomainRoleInfo.GetRolePlayer(link, this.TargetRoleId))
                                dValues.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    // 'n:m': nothing needs to be filtered.
                }
                
                if (!this.RelationshipInfo.AllowsDuplicates)
                {
                    ReadOnlyCollection<ModelElement> elements = this.Store.ElementDirectory.FindElements(RelationshipDomainClassId, true);
                    foreach (ElementLink link in elements)
                    {
                        for (var i = dValues.Count - 1; i >= 0; i--)
                        {
                            ModelElement m = dValues[i] as ModelElement;
                            if (m == DomainRoleInfo.GetRolePlayer(link, this.TargetRoleId) && currentElement == DomainRoleInfo.GetRolePlayer(link, this.SourceRoleId))
                                dValues.RemoveAt(i);
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Sort the default values list.
        /// </summary>
        private int SortByName(object x, object y)
        {
            ModelElement vmX = x as ModelElement;
            ModelElement vmY = y as ModelElement;

            if (vmX != null && vmY != null && vmX is IDomainModelOwnable && vmY is IDomainModelOwnable)
            {
                string textX = (vmX as IDomainModelOwnable).DomainElementFullName;
                string textY = (vmY as IDomainModelOwnable).DomainElementFullName;

                /*
                string textX = this.ViewModelStore.GetDomainModelServices(vmX).ElementTypeProvider.GetTypeDisplayName(vmX);
                if (this.ViewModelStore.GetDomainModelServices(vmX).ElementNameProvider.HasName(vmX))
                    textX = this.ViewModelStore.GetDomainModelServices(vmX).ElementNameProvider.GetName(vmX) + "(" + textX + ")";

                string textY = this.ViewModelStore.GetDomainModelServices(vmY).ElementTypeProvider.GetTypeDisplayName(vmY);
                if (this.ViewModelStore.GetDomainModelServices(vmY).ElementNameProvider.HasName(vmY))
                    textY = this.ViewModelStore.GetDomainModelServices(vmY).ElementNameProvider.GetName(vmY) + "(" + textY + ")";
                */

                return textX.CompareTo(textY);
            }
            return 0;
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            base.OnDispose();

            this.ViewModelStore.EventManager.GetEvent<ModelElementAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainClass(this.RelationshipDomainClassId), new Action<ElementAddedEventArgs>(OnRolePlayerAdded));
            this.ViewModelStore.EventManager.GetEvent<ModelElementDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainClass(this.RelationshipDomainClassId), new Action<ElementDeletedEventArgs>(OnRolePlayerDeleted));
            this.ViewModelStore.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(this.RelationshipDomainClassId), new Action<RolePlayerChangedEventArgs>(OnRolePlayerChanged)); 
        }
    }
}
