using System;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html
{
    /// <summary>
    /// This class extends the default hyperlink class by providing an NavigationCommand, that can
    /// be used to provide custom navigation based on the hyperlink, which is passed as parameter.
    /// </summary>
    public class HtmlHyperlink : Hyperlink
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public HtmlHyperlink()
        {
            //Init();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public HtmlHyperlink(TextPointer start, TextPointer end)
            : base(start, end)
        {
            //Init();
        }

        private void Init()
        {
            this.ContextMenu = new System.Windows.Controls.ContextMenu();

            MenuItem menuItem = new MenuItem();
            menuItem.Header = "Edit Hyperlink";
            menuItem.Icon = new System.Windows.Controls.Image
            {
                Source = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/Edit.png"))
            };
            //this.ContextMenu.Items.Add(menuItem);
        }

        /*protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && NavigationCommand != null)
                NavigationCommand.Execute(this);
        }*/
    }
}
