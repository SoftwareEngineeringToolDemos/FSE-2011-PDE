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
using System.Windows.Shapes;

namespace Tum.PDE.LanguageDSL.Visualization.View.Forms
{
    /// <summary>
    /// Interaction logic for RelationshipTypeSelector.xaml
    /// </summary>
    public partial class RelationshipTypeSelector : Window
    {
        public RelationshipTypeSelector()
        {
            InitializeComponent();
        }

        private void ListBoxItemEmb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EmbeddedRelationshipSelected = true;
            this.DialogResult = true;
        }

        private void ListBoxItemRef_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EmbeddedRelationshipSelected = false;
            this.DialogResult = true;
        }

        public bool? EmbeddedRelationshipSelected = null;
    }
}
