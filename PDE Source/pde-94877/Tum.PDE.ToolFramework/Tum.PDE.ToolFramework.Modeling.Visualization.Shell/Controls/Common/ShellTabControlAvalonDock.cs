using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Common;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using System.Windows;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Shell.Controls.Common
{
    /// <summary>
    /// The tab control customized to use in the VS shell.
    /// </summary>
    /// <remarks>
    /// Extended to provide an ActivatedCommand that is only triggered if 
    /// TriggerActivatedCommand is set to true.
    /// </remarks>
    public class ShellTabControlAvalonDock : TabControlAvalonDock
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ShellTabControlAvalonDock()
            : base()
        {
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static ShellTabControlAvalonDock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ShellTabControlAvalonDock), new FrameworkPropertyMetadata(typeof(ShellTabControlAvalonDock)));
        }

        /// <summary>
        /// TriggerActivatedCommand command.
        /// </summary>
        public bool TriggerActivatedCommand
        {
            get { return (bool)GetValue(TriggerActivatedCommandProperty); }
            set
            {
                SetValue(TriggerActivatedCommandProperty, value);
            }
        }

        /// <summary>
        /// Triggers activated command if required.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.TriggerActivatedCommand == true)
            {
                if (this.ActivatedCommand != null)
                    this.ActivatedCommand.Execute();
            }

            base.OnPreviewMouseDown(e);
        }

        /// <summary>
        /// TriggerActivatedCommand.
        /// </summary>
        public static readonly DependencyProperty TriggerActivatedCommandProperty =
          DependencyProperty.Register("TriggerActivatedCommand", typeof(bool), typeof(ShellTabControlAvalonDock), new PropertyMetadata(false));

        /// <summary>
        /// ActivatedComand command.
        /// </summary>
        public DelegateCommand ActivatedCommand
        {
            get { return (DelegateCommand)GetValue(ActivatedCommandProperty); }
            set
            {
                SetValue(ActivatedCommandProperty, value);
            }
        }

        /// <summary>
        /// ActivatedComand.
        /// </summary>
        public static readonly DependencyProperty ActivatedCommandProperty =
          DependencyProperty.Register("ActivatedCommand", typeof(DelegateCommand), typeof(ShellTabControlAvalonDock), new PropertyMetadata(null));
    }
}
