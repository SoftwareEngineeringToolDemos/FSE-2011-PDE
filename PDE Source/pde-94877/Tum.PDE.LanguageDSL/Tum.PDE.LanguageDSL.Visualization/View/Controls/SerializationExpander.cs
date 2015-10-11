using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Tum.PDE.LanguageDSL.Visualization.View.Controls
{
    public class SerializationExpander : Expander
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsItemsAreaDisabled
        {
            get { return (bool)GetValue(IsItemsAreaDisabledProperty); }
            set { SetValue(IsItemsAreaDisabledProperty, value); }
        }
        public static readonly DependencyProperty IsItemsAreaDisabledProperty =
            DependencyProperty.Register("IsItemsAreaDisabled", typeof(bool), typeof(SerializationExpander), new PropertyMetadata(false));

        /// <summary>
        /// 
        /// </summary>
        public bool IsHeaderAreaDisabled
        {
            get { return (bool)GetValue(IsHeaderAreaDisabledProperty); }
            set { SetValue(IsHeaderAreaDisabledProperty, value); }
        }
        public static readonly DependencyProperty IsHeaderAreaDisabledProperty =
            DependencyProperty.Register("IsHeaderAreaDisabled", typeof(bool), typeof(SerializationExpander), new PropertyMetadata(false));
        
    }
}
