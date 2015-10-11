using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Common
{
    /// <summary>
    /// RadioButton with bindable IsChecked property.
    /// </summary>
    /// <remarks>
    /// http://pstaev.blogspot.com/2008/10/binding-ischecked-property-of.html
    /// </remarks>
    public class RadioButtonBindable : RadioButton
    {
        private static bool m_bIsChanging = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RadioButtonBindable()
        {
            this.Checked += new RoutedEventHandler(RadioButtonExtended_Checked);
            this.Unchecked += new RoutedEventHandler(RadioButtonExtended_Unchecked);
        }

        void RadioButtonExtended_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!m_bIsChanging)
                this.IsCheckedReal = false;
        }
        void RadioButtonExtended_Checked(object sender, RoutedEventArgs e)
        {
            if (!m_bIsChanging)
                this.IsCheckedReal = true;
        }

        /// <summary>
        /// Bindable is checked property.
        /// </summary>
        public bool? IsCheckedReal
        {
            get { return (bool?)GetValue(IsCheckedRealProperty); }
            set
            {
                SetValue(IsCheckedRealProperty, value);
            }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for IsCheckedReal. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsCheckedRealProperty = DependencyProperty.Register("IsCheckedReal", typeof(bool?), typeof(RadioButtonBindable),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Journal|FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, IsCheckedRealChanged));

        private static void IsCheckedRealChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            m_bIsChanging = true;
            ((RadioButtonBindable)d).IsChecked = (bool)e.NewValue;
            m_bIsChanging = false;
        }
    }
}
