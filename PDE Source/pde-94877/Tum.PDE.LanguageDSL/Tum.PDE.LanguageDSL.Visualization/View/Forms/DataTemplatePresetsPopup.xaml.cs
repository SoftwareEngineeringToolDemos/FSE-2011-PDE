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
    /// Interaction logic for DataTemplatePresetsPopup.xaml
    /// </summary>
    public partial class DataTemplatePresetsPopup : Window
    {
        public DataTemplatePresetsPopup()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.pdeTextEditor.Focus();
        }

        private void ButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, this.pdeTextEditor.Text);
        }
    }
}
