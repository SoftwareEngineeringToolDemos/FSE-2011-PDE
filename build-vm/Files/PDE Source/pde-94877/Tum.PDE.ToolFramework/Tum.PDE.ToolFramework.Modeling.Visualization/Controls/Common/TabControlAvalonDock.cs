using System.Windows;
using System.Windows.Controls;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Common
{
    /// <summary>
    /// TabControl that is modeling after the modeling dock document pane. It contains closable
    /// items that are displayed in a single scrollable line.
    /// </summary>
    public class TabControlAvalonDock : TabControl, INotifyPropertyChanged
    {
        private DelegateCommand closeCommand;

        /// <summary>
        /// Constructor.
        /// </summary>
        public TabControlAvalonDock()
        {
            this.closeCommand = new DelegateCommand(CloseCommand_Execute, CloseCommand_CanExecute);
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static TabControlAvalonDock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabControlAvalonDock), new FrameworkPropertyMetadata(typeof(TabControlAvalonDock)));
        }

        /// <summary>
        /// Gets the close command.
        /// </summary>
        public DelegateCommand CloseCommand
        {
            get
            {
                return this.closeCommand;
            }
        }

        /// <summary>
        /// Callen on items changes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            this.OnPropertyChanged("TabItems");
            //this.CloseCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Selection changes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            this.CloseCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Gets the tab items collection.
        /// </summary>
        public List<TabItem> TabItems
        {
            get
            {
                List<TabItem> items = new List<TabItem>();
                for (int i = 0; i < this.Items.Count; i++)
                {
                    TabItem ti = (TabItem)this.ItemContainerGenerator.ContainerFromIndex(i);

                    items.Add(ti);
                }

                return items;
            }
        }

        /// <summary>
        /// Creates a TabItemAvalonDock to use to display content.
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TabItemAvalonDock();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TabItemAvalonDock;
        }

        private void CloseCommand_Execute()
        {
            if (this.CloseCurrentTabComand != null)
            {
                CloseCurrentTabComand.Execute();
                return;
            }

            if (this.SelectedIndex >= 0)
            {
                this.Items.RemoveAt(this.SelectedIndex);
            }
        }
        private bool CloseCommand_CanExecute()
        {
            if (this.CloseCurrentTabComand != null)
                return CloseCurrentTabComand.CanExecute();

            if (this.SelectedIndex >= 0 && this.SelectedItem != null)
                if( this.SelectedItem is TabItem )
                    return true;

            return false;
        }

        /// <summary>
        /// IsHeaderTabBig.
        /// </summary>
        public static readonly DependencyProperty IsHeaderTabBigProperty =
          DependencyProperty.Register("IsHeaderTabBig", typeof(bool), typeof(TabControlAvalonDock), new PropertyMetadata(false));

        /// <summary>
        /// CloseCurrentTab command.
        /// </summary>
        public DelegateCommand CloseCurrentTabComand
        {
            get { return (DelegateCommand)GetValue(CloseCurrentTabComandProperty); }
            set
            {
                SetValue(CloseCurrentTabComandProperty, value);
            }
        }

        /// <summary>
        /// CloseCurrentTab.
        /// </summary>
        public static readonly DependencyProperty CloseCurrentTabComandProperty =
          DependencyProperty.Register("CloseCurrentTabComand", typeof(DelegateCommand), typeof(TabControlAvalonDock), new PropertyMetadata(null, new PropertyChangedCallback(CloseCurrentTabComandChanged)));
        private static void CloseCurrentTabComandChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            TabControlAvalonDock item = obj as TabControlAvalonDock;
            if (item.CloseCurrentTabComand != null)
                item.CloseCommand.CanExecute();
        }

        #region INotifyPropertyChanged Members
        /// <summary>
        /// Property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called whenever a specific property changes.
        /// </summary>
        /// <param name="name">Name of the property, which value changed.</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

    }
}
