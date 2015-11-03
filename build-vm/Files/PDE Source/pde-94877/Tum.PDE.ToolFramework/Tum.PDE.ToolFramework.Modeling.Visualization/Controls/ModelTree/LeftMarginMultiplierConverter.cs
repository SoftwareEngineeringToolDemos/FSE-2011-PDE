using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.ModelTree
{
    /// <summary>
    /// http://stackoverflow.com/questions/664632/highlight-whole-treeviewitem-line-in-wpf
    /// </summary>
    public class LeftMarginMultiplierConverter : IValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (int)value;

            return new Thickness(Length * item, 0, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }

}
