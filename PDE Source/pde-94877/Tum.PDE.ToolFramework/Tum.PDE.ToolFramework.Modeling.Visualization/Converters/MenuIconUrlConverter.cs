using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Converters
{
    /// <summary>
    /// This class simply converts a image url into a Image for use within a MenuItem
    /// </summary>
    /// <remarks>
    /// From the Cinch framework by Sacha Barber: http://cinch.codeplex.com/
    /// </remarks>
    [ValueConversion(typeof(String), typeof(Image))]
    public class MenuIconConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to its target type.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Optional parameter to use during conversion.</param>
        /// <param name="culture">CultureInfo to use during conversion.</param>
        /// <returns>Converted value</returns>
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value == null)
                return Binding.DoNothing;

            String imageUrl = value.ToString();

            if (String.IsNullOrEmpty(imageUrl))
                return Binding.DoNothing;

            Image img = new Image();
            img.Width = 16;
            img.Height = 16;
            BitmapImage bmp = new BitmapImage(new Uri(imageUrl,
                UriKind.RelativeOrAbsolute));
            img.Source = bmp;
            return img;
        }

        /// <summary>
        /// Converts a value to its target type.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Optional parameter to use during conversion.</param>
        /// <param name="culture">CultureInfo to use during conversion.</param>
        /// <returns>Converted value</returns>
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Not implemented");
        }
    }
}
