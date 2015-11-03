using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    /// <summary>
    /// This view model hosts a diagram tree node.
    /// </summary>
    public abstract class DiagramTreeNodeViewModel : BaseAttributeElementViewModel
    {
        private DiagramTreeNode diagramTreeNode;
        private Guid? presentationElementClassId = null;

        private BaseModelElementViewModel elementViewModel = null;

        /// <summary>
        /// Constructor. This view model constructed with 'bHookUpEvents=true' does react on model changes.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagramTreeNode">Element represented by this view model.</param>
        protected DiagramTreeNodeViewModel(ViewModelStore viewModelStore, DiagramTreeNode diagramTreeNode)
            : base(viewModelStore, diagramTreeNode.PresentationElementClass)
        {
            this.diagramTreeNode = diagramTreeNode;

            if (this.DiagramTreeNode != null)
                if (this.DiagramTreeNode.PresentationElementClass != null)
                {
                    presentationElementClassId = this.DiagramTreeNode.PresentationElementClass.Id;

                    this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ShapeClassReferencesDomainClass.DomainClassId),
                        true, this.DiagramTreeNode.PresentationElementClass.Id, new Action<ElementAddedEventArgs>(OnShapeElementAdded));

                    this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ShapeClassReferencesDomainClass.DomainClassId),
                        true, this.DiagramTreeNode.PresentationElementClass.Id, new Action<ElementDeletedEventArgs>(OnShapeElementRemoved));

                    this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(ShapeClassReferencesDomainClass.DomainClassDomainRoleId),
                        new Action<RolePlayerChangedEventArgs>(OnShapeElementChanged));

                    this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(RelationshipShapeClassReferencesReferenceRelationship.DomainClassId),
                        true, this.DiagramTreeNode.PresentationElementClass.Id, new Action<ElementAddedEventArgs>(OnRSShapeElementAdded));

                    this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(RelationshipShapeClassReferencesReferenceRelationship.DomainClassId),
                        true, this.DiagramTreeNode.PresentationElementClass.Id, new Action<ElementDeletedEventArgs>(OnRSShapeElementRemoved));

                    this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(RelationshipShapeClassReferencesReferenceRelationship.DomainRelationshipDomainRoleId),
                        new Action<RolePlayerChangedEventArgs>(OnRSShapeElementChanged));

                    if (this.DiagramTreeNode.PresentationElementClass is RelationshipShapeClass)
                        AddRSShapeElement((this.DiagramTreeNode.PresentationElementClass as RelationshipShapeClass).ReferenceRelationship);
                    else
                        AddShapeElement((this.DiagramTreeNode.PresentationElementClass as PresentationDomainClassElement).DomainClass);
                }     
        }

        /// <summary>
        /// Gets the diagram tree node.
        /// </summary>
        public DiagramTreeNode DiagramTreeNode
        {
            get
            {
                return this.diagramTreeNode;
            }
        }

        /// <summary>
        /// Gets the diagram element name.
        /// </summary>
        public BaseModelElementViewModel DiagramElementViewModel
        {
            get
            {
                return this.elementViewModel;
            }
        }

        #region Model Methods
        /// <summary>
        /// Adds a new view model for the given element.
        /// </summary>
        /// <param name="node">Element.</param>
        public void AddRSShapeElement(DomainRelationship element)
        {
            if (this.elementViewModel != null)
                this.elementViewModel.Dispose();

            if (element != null)
                this.elementViewModel = new BaseModelElementViewModel(this.ViewModelStore, element);

            OnPropertyChanged("DiagramElementViewModel");
        }

        /// <summary>
        /// Adds a new view model for the given element.
        /// </summary>
        /// <param name="node">Element.</param>
        public void AddShapeElement(DomainClass element)
        {
            if (this.elementViewModel != null)
                this.elementViewModel.Dispose();

            if( element != null )
                this.elementViewModel = new BaseModelElementViewModel(this.ViewModelStore, element);

            OnPropertyChanged("DiagramElementViewModel");
        }

        /// <summary>
        /// Deletes the view model that is hosting the given element.
        /// </summary>
        /// <param name="node">Element.</param>
        public void DeleteElement()
        {
            if (this.elementViewModel != null)
                this.elementViewModel.Dispose();

            this.elementViewModel = null;

            OnPropertyChanged("DiagramElementViewModel");
        }

        /// <summary>
        /// Called whenever a relationship of type ShapeClassReferencesDomainClass is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnShapeElementAdded(ElementAddedEventArgs args)
        {
            ShapeClassReferencesDomainClass con = args.ModelElement as ShapeClassReferencesDomainClass;
            if (con != null)
            {
                AddShapeElement(con.DomainClass);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type ShapeClassReferencesDomainClass is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnShapeElementRemoved(ElementDeletedEventArgs args)
        {
            ShapeClassReferencesDomainClass con = args.ModelElement as ShapeClassReferencesDomainClass;
            if (con != null)
            {
                DeleteElement();
            }
        }

        /// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args"></param>
        private void OnShapeElementChanged(RolePlayerChangedEventArgs args)
        {
            ShapeClassReferencesDomainClass con = args.ElementLink as ShapeClassReferencesDomainClass;
            if (con != null)
            {
                if (con.ShapeClass == this.DiagramTreeNode.PresentationElementClass)
                {
                    DeleteElement();

                    AddShapeElement(con.DomainClass);
                }
            }
            
        }

        /// <summary>
        /// Called whenever a relationship of type RelationshipShapeClassReferencesReferenceRelationship is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnRSShapeElementAdded(ElementAddedEventArgs args)
        {
            RelationshipShapeClassReferencesReferenceRelationship con = args.ModelElement as RelationshipShapeClassReferencesReferenceRelationship;
            if (con != null)
            {
                AddRSShapeElement(con.DomainRelationship);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type RelationshipShapeClassReferencesReferenceRelationship is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnRSShapeElementRemoved(ElementDeletedEventArgs args)
        {
            RelationshipShapeClassReferencesReferenceRelationship con = args.ModelElement as RelationshipShapeClassReferencesReferenceRelationship;
            if (con != null)
            {
                DeleteElement();
            }
        }

        /// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args"></param>
        private void OnRSShapeElementChanged(RolePlayerChangedEventArgs args)
        {
            RelationshipShapeClassReferencesReferenceRelationship con = args.ElementLink as RelationshipShapeClassReferencesReferenceRelationship;
            if (con != null)
            {
                if (con.RelationshipShapeClass == this.DiagramTreeNode.PresentationElementClass)
                {
                    DeleteElement();

                    AddRSShapeElement(con.DomainRelationship);
                }
            }

        }
        #endregion

        /// <summary>
        /// Finds out if the current tree node can be moved up or not.
        /// </summary>
        /// <returns>True if the current tree node can be moved up, false otherwise</returns>
        public abstract bool CanMoveUp();

        /// <summary>
        /// Finds out if the current tree node can be moved down or not.
        /// </summary>
        /// <returns>True if the current tree node can be moved down, false otherwise</returns>
        public abstract bool CanMoveDown();

        /// <summary>
        /// Moves this element up in the display order.
        /// </summary>
        public void MoveUp()
        {
            Move(true);
        }

        /// <summary>
        /// Moves this element down in the display order.
        /// </summary>
        public void MoveDown()
        {
            Move(false);
        }

        /// <summary>
        /// Moves this element up or down in the display order by repositioning the element in the collection.
        /// </summary>
        /// <param name="bUp"></param>
        protected abstract void Move(bool bUp);

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.elementViewModel != null)
                this.elementViewModel.Dispose();

            this.elementViewModel = null;

            if (this.DiagramTreeNode != null)
                if (this.presentationElementClassId != null)
                {
                    this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ShapeClassReferencesDomainClass.DomainClassId),
                        true, this.presentationElementClassId.Value, new Action<ElementAddedEventArgs>(OnShapeElementAdded));

                    this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ShapeClassReferencesDomainClass.DomainClassId),
                        true, this.presentationElementClassId.Value, new Action<ElementDeletedEventArgs>(OnShapeElementRemoved));

                    this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(ShapeClassReferencesDomainClass.DomainClassDomainRoleId),
                        new Action<RolePlayerChangedEventArgs>(OnShapeElementChanged));

                    this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(RelationshipShapeClassReferencesReferenceRelationship.DomainClassId),
                        true, this.presentationElementClassId.Value, new Action<ElementAddedEventArgs>(OnRSShapeElementAdded));

                    this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(RelationshipShapeClassReferencesReferenceRelationship.DomainClassId),
                        true, this.presentationElementClassId.Value, new Action<ElementDeletedEventArgs>(OnRSShapeElementRemoved));

                    this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(RelationshipShapeClassReferencesReferenceRelationship.DomainRelationshipDomainRoleId),
                        new Action<RolePlayerChangedEventArgs>(OnRSShapeElementChanged));
                }

            base.OnDispose();
        }
    }
}
