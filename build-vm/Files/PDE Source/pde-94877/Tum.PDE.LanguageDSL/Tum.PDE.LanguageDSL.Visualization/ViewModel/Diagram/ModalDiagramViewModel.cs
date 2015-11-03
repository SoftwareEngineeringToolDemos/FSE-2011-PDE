using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    public class ModalDiagramViewModel : DiagramClassViewModel
    {
        private BaseModelElementViewModel referenceVM;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagramClass">Element to be hosted by this view model.</param>
        public ModalDiagramViewModel(ViewModelStore viewModelStore, DiagramClassView diagramClassView, DiagramViewModel parent)
            : base(viewModelStore, diagramClassView, parent)
        {
            ModalDiagram diagramClass = diagramClassView.DiagramClass as ModalDiagram;
            if (diagramClass.DomainClass != null)
            {
                this.ReferenceVM = new BaseModelElementViewModel(this.ViewModelStore, diagramClass, true);
            }

            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ModalDiagramReferencesDomainClass.DomainClassId),
                true, diagramClass.Id, new Action<ElementAddedEventArgs>(OnReferenceAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ModalDiagramReferencesDomainClass.DomainClassId),
                true, diagramClass.Id, new Action<ElementDeletedEventArgs>(OnReferenceRemoved));

            this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(ModalDiagramReferencesDomainClass.DomainClassDomainRoleId),
                new Action<RolePlayerChangedEventArgs>(OnReferenceChanged));
        }

        /// <summary>
        /// Reference VM.
        /// </summary>
        public BaseModelElementViewModel ReferenceVM
        {
            get
            {
                return this.referenceVM;
            }
            private set
            {
                if (this.referenceVM != null)
                    this.referenceVM.Dispose();

                this.referenceVM = value;
                OnPropertyChanged("ReferenceVM");
            }
        }

        #region Model Events
        /// <summary>
        /// Sets the reference.
        /// </summary>
        /// <param name="node">Node.</param>
        public void SetReference(DomainClass node)
        {
            this.ReferenceVM = new BaseModelElementViewModel(this.ViewModelStore, node);
        }

        /// <summary>
        /// Removes the reference.
        /// </summary>
        /// <param name="node">Node.</param>
        public void RemoveReference(DomainClass node)
        {
            this.ReferenceVM = null;
        }

        /// <summary>
        /// Called whenever a relationship of type ModalDiagramReferencesDomainClass is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnReferenceAdded(ElementAddedEventArgs args)
        {
            ModalDiagramReferencesDomainClass con = args.ModelElement as ModalDiagramReferencesDomainClass;
            if (con != null)
            {
                SetReference(con.DomainClass);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramClassViewHasRootDiagramNodes is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnReferenceRemoved(ElementDeletedEventArgs args)
        {
            ModalDiagramReferencesDomainClass con = args.ModelElement as ModalDiagramReferencesDomainClass;
            if (con != null)
            {
                RemoveReference(con.DomainClass);
            }

        }

        /// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args"></param>
        private void OnReferenceChanged(RolePlayerChangedEventArgs args)
        {
            ModalDiagramReferencesDomainClass con = args.ElementLink as ModalDiagramReferencesDomainClass;
            if (con != null)
            {
                if (args.DomainRole.Id == ModalDiagramReferencesDomainClass.DomainClassDomainRoleId)
                    if (con.ModalDiagram.Id == this.DiagramClassView.DiagramClass.Id)
                    {
                        if (this.ReferenceVM != null)
                            if (args.OldRolePlayerId == this.referenceVM.Element.Id)
                            {
                                RemoveReference(con.DomainClass);
                            }

                        SetReference(con.DomainClass);
                    }
            }
        }  
        #endregion

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.ReferenceVM != null)
            {
                this.ReferenceVM.Dispose();
            }

            if( this.DiagramClassView != null )
                if (this.DiagramClassView.DiagramClass != null)
                {
                    this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ModalDiagramReferencesDomainClass.DomainClassId),
                        true, this.DiagramClassView.DiagramClass.Id, new Action<ElementAddedEventArgs>(OnReferenceAdded));

                    this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ModalDiagramReferencesDomainClass.DomainClassId),
                        true, this.DiagramClassView.DiagramClass.Id, new Action<ElementDeletedEventArgs>(OnReferenceRemoved));

                    this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(ModalDiagramReferencesDomainClass.DomainClassId),
                        new Action<RolePlayerChangedEventArgs>(OnReferenceChanged));
                }

            this.ReferenceVM = null;

            base.OnDispose();
        }
    }
}
