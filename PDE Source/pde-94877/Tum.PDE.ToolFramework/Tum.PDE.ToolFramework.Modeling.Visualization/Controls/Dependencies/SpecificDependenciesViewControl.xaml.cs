using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Dependencies
{
    /// <summary>
    /// Interaction logic for SpecificDependenciesViewControl.xaml
    /// </summary>
    public partial class SpecificDependenciesViewControl : UserControl
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public SpecificDependenciesViewControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clicked point.
        /// </summary>
        public Brush ItemPanelBackground
        {
            get { return (Brush)GetValue(ItemPanelBackgroundProperty); }
            set { SetValue(ItemPanelBackgroundProperty, value); }
        }

        /// <summary>
        /// Clicked point property.
        /// </summary>
        public static readonly DependencyProperty ItemPanelBackgroundProperty =
            DependencyProperty.Register("ItemPanelBackground", typeof(Brush), typeof(SpecificDependenciesViewControl), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
    }
}
