using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;
using Tum.PDE.LanguageDSL.Visualization.Commands;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    public class SpecificElementsDiagramViewModel : DiagramClassViewModel
    {
        private ObservableCollection<BaseModelElementViewModel> referenceVMs;
        private DelegateCommand<BaseModelElementViewModel> deleteCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagramClass">Element to be hosted by this view model.</param>
        public SpecificElementsDiagramViewModel(ViewModelStore viewModelStore, DiagramClassView diagramClassView, DiagramViewModel parent)
            : base(viewModelStore, diagramClassView, parent)
        {
            this.referenceVMs = new ObservableCollection<BaseModelElementViewModel>();
            this.deleteCommand = new DelegateCommand<BaseModelElementViewModel>(DeleteCommand_Executed);

            SpecificElementsDiagram diagramClass = diagramClassView.DiagramClass as SpecificElementsDiagram;
            foreach (DomainClass d in diagramClass.DomainClasses)
                this.AddReference(d);

            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SpecificElementsDiagramReferencesDomainClasses.DomainClassId),
                true, diagramClass.Id, new Action<ElementAddedEventArgs>(OnReferenceAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SpecificElementsDiagramReferencesDomainClasses.DomainClassId),
                true, diagramClass.Id, new Action<ElementDeletedEventArgs>(OnReferenceRemoved));

            this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(SpecificElementsDiagramReferencesDomainClasses.DomainClassDomainRoleId),
                new Action<RolePlayerChangedEventArgs>(OnReferenceChanged));
            this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(SpecificElementsDiagramReferencesDomainClasses.SpecificElementsDiagramDomainRoleId),
                new Action<RolePlayerChangedEventArgs>(OnReferenceChanged));
        }

        /// <summary>
        /// Reference VM.
        /// </summary>
        public ObservableCollection<BaseModelElementViewModel> ReferenceVMs
        {
            get
            {
                return this.referenceVMs;
            }
        }

        /// <summary>
        /// Delete command.
        /// </summary>
        public DelegateCommand<BaseModelElementViewModel> DeleteCommand
        {
            get { return this.deleteCommand; }
        }

        private void DeleteCommand_Executed(BaseModelElementViewModel vm)
        {
            DomainClass d = vm.Element as DomainClass;
            if (d != null)
            {
                SpecificElementsDiagram diagram = this.DiagramClassView.DiagramClass as SpecificElementsDiagram;
                if (diagram.DomainClasses.Contains(d))
                {
                    using (Transaction t = this.Store.TransactionManager.BeginTransaction() )
                    {
                        diagram.DomainClasses.Remove(d);
                        t.Commit();
                    }
                }

                this.RemoveReference(d);
            }
        }

        #region Model Events
        /// <summary>
        /// Sets the reference.
        /// </summary>
        /// <param name="node">Node.</param>
        public void AddReference(DomainClass node)
        { 
            // verify that element has not been added yet
            foreach (BaseModelElementViewModel viewModel in this.referenceVMs)
                if (viewModel.Element.Id == node.Id)
                    return;

            BaseModelElementViewModel vm = new BaseModelElementViewModel(this.ViewModelStore, node, true);
            this.referenceVMs.Add(vm);

            OnPropertyChanged("ReferenceVMs");
        }

        /// <summary>
        /// Removes the reference.
        /// </summary>
        /// <param name="node">Node.</param>
        public void RemoveReference(DomainClass node)
        {
            for (int i = this.referenceVMs.Count - 1; i >= 0; i--)
                if (this.referenceVMs[i].Element.Id == node.Id)
                {
                    this.referenceVMs[i].Dispose();
                    this.referenceVMs.RemoveAt(i);
                }

            OnPropertyChanged("ReferenceVMs");
        }

        /// <summary>
        /// Called whenever a relationship of type SpecificElementsDiagramReferencesDomainClasses is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnReferenceAdded(ElementAddedEventArgs args)
        {
            SpecificElementsDiagramReferencesDomainClasses con = args.ModelElement as SpecificElementsDiagramReferencesDomainClasses;
            if (con != null)
            {
                AddReference(con.DomainClass);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type SpecificElementsDiagramReferencesDomainClasses is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnReferenceRemoved(ElementDeletedEventArgs args)
        {
            SpecificElementsDiagramReferencesDomainClasses con = args.ModelElement as SpecificElementsDiagramReferencesDomainClasses;
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
            SpecificElementsDiagramReferencesDomainClasses con = args.ElementLink as SpecificElementsDiagramReferencesDomainClasses;
            if (con != null)
            {
                if (args.DomainRole.Id == SpecificElementsDiagramReferencesDomainClasses.SpecificElementsDiagramDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.DiagramClassView.DiagramClass.Id)
                        RemoveReference(con.DomainClass);

                    if (args.NewRolePlayerId == this.DiagramClassView.DiagramClass.Id)
                        AddReference(con.DomainClass);
                }
                else if (args.DomainRole.Id == SpecificElementsDiagramReferencesDomainClasses.DomainClassId)
                {
                    if (args.OldRolePlayer != null)
                        RemoveReference(args.OldRolePlayer as DomainClass);

                    if (args.NewRolePlayer != null)
                        AddReference(args.NewRolePlayer as DomainClass);
                }
            }
        }
        #endregion

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            for (int i = this.referenceVMs.Count - 1; i >= 0; i--)
                this.referenceVMs[i].Dispose();
            this.referenceVMs.Clear();

            if (this.DiagramClassView != null)
                if (this.DiagramClassView.DiagramClass != null)
                {
                    this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SpecificElementsDiagramReferencesDomainClasses.DomainClassId),
                        true, DiagramClassView.DiagramClass.Id, new Action<ElementAddedEventArgs>(OnReferenceAdded));

                    this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SpecificElementsDiagramReferencesDomainClasses.DomainClassId),
                        true, DiagramClassView.DiagramClass.Id, new Action<ElementDeletedEventArgs>(OnReferenceRemoved));

                    this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(SpecificElementsDiagramReferencesDomainClasses.DomainClassDomainRoleId),
                        new Action<RolePlayerChangedEventArgs>(OnReferenceChanged));
                    this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(SpecificElementsDiagramReferencesDomainClasses.SpecificElementsDiagramDomainRoleId),
                        new Action<RolePlayerChangedEventArgs>(OnReferenceChanged));
                }

            base.OnDispose();
        }
    }
}
