using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon
{
    /// <summary>
    /// Helper class for creating the ribbon menu.
    /// </summary>
    public static class RibbonCreationHelper
    {
        /// <summary>
        /// Creates a ribbon button.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <returns>Ribbon button.</returns>
        public static Fluent.Button CreateButton(string text)
        {
            return CreateButton(text, null);
        }

        /// <summary>
        /// Creates a ribbon button.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="imageUri">Image uri. Can be null.</param>
        /// <returns>Ribbon button.</returns>
        public static Fluent.Button CreateButton(string text, string imageUri)
        {
            return CreateButton(text, imageUri, "Large", null);
        }

        /// <summary>
        /// Creates a ribbon button.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="imageUri">Image uri. Can be null.</param>
        /// <param name="size">Large, Medium, .. Can be null.</param>
        /// <param name="commandBinding">Binding path for the Command-Property. Can be null.</param>
        /// <returns>Ribbon button.</returns>
        public static Fluent.Button CreateButton(string text, string imageUri, string size, string commandBinding)
        {
            return CreateButton(text, imageUri, size, commandBinding, BindingMode.OneWay);
        }

        /// <summary>
        /// Creates a ribbon button.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="imageUri">Image uri. Can be null.</param>
        /// <param name="size">Large, Medium, .. Can be null.</param>
        /// <param name="commandBinding">Binding path for the Command-Property. Can be null.</param>
        /// <param name="commandBindingMode">Binding mode for the Command-Property.</param>
        /// <returns>Ribbon button.</returns>
        public static Fluent.Button CreateButton(string text, string imageUri, string size, string commandBinding, BindingMode commandBindingMode)
        {
            return CreateButton(text, imageUri, size, commandBinding, commandBindingMode, null, BindingMode.Default);
        }

        /// <summary>
        /// Creates a ribbon button.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="imageUri">Image uri. Can be null.</param>
        /// <param name="size">Large, Medium, .. Can be null.</param>
        /// <param name="commandBinding">Binding path for the Command-Property. Can be null.</param>
        /// <param name="commandParameterBinding">>Binding path for the CommandParameter-Property. Can be null.</param>
        /// <returns>Ribbon button.</returns>
        public static Fluent.Button CreateButton(string text, string imageUri, string size, string commandBinding, string commandParameterBinding)
        {
            return CreateButton(text, imageUri, size, commandBinding, BindingMode.OneWay, commandParameterBinding, BindingMode.Default);
        }

        /// <summary>
        /// Creates a ribbon button.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="imageUri">Image uri. Can be null.</param>
        /// <param name="size">Large, Medium, .. Can be null.</param>
        /// <param name="commandBinding">Binding path for the Command-Property. Can be null.</param>
        /// <param name="commandBindingMode">Binding mode for the Command-Property. Default is OneWay.</param>
        /// <param name="commandParameterBinding">>Binding path for the CommandParameter-Property. Can be null.</param>
        /// <param name="commandParameterBindingMode">Binding mode for the CommandParameter-Property.</param>
        /// <returns>Ribbon button.</returns>
        public static Fluent.Button CreateButton(string text, string imageUri, string size, string commandBinding, BindingMode commandBindingMode, string commandParameterBinding, BindingMode commandParameterBindingMode)
        {
            Fluent.Button btn = new Fluent.Button();
            btn.Text = text;
            if (size == "Large")
            {
                if( imageUri != null )
                    btn.LargeIcon = new BitmapImage(new Uri(imageUri, UriKind.RelativeOrAbsolute));
                btn.SizeDefinition = size;
            }
            else
            {
                if (imageUri != null)
                    btn.Icon = new BitmapImage(new Uri(imageUri));
                btn.SizeDefinition = size;
            }

            if (commandBinding != null)
            {
                Binding cmdB = new Binding(commandBinding);
                cmdB.Mode = commandBindingMode;
                btn.SetBinding(Fluent.Button.CommandProperty, cmdB);

            }

            if (commandParameterBinding != null)
            {
                Binding cmdBParam = new Binding(commandBinding);
                cmdBParam.Mode = commandParameterBindingMode;
                btn.SetBinding(Fluent.Button.CommandParameterProperty, cmdBParam);
            }

            return btn;
        }
    }
}
