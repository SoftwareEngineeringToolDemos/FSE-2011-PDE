using System.Windows.Input;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html
{
    /// <summary>
    /// This class is used to extend the default image class to store properties required for conversion from wpf to html and vice versa.
    /// </summary>
    public class HtmlImage : System.Windows.Controls.Image
    {
        private string relativeSource;
        private string alternativeText;

        private string id;

        private double? exportWidth;
        private double? exportHeight;

        private bool bFullSize = false;

        /// <summary>
        /// Default image width.
        /// </summary>
        public const double ImageWidth = 300;

        /// <summary>
        /// Default image height.
        /// </summary>
        public const double ImageHeight = 300;

        /// <summary>
        /// Constructor.
        /// </summary>
        public HtmlImage()
            : base()
        {
            this.MaxWidth = ImageWidth;
            this.MaxHeight = ImageHeight;

            this.Cursor = Cursors.Hand;

            /*this.ContextMenu = new System.Windows.Controls.ContextMenu();

            MenuItem menuItem = new MenuItem();
            menuItem.Header = "Edit Image";
            menuItem.Icon = new System.Windows.Controls.Image
            {
                Source = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/Edit-16x16.png"))
            };
             * */
            //this.ContextMenu.Items.Add(menuItem);
        }

        /// <summary>
        /// Navigation logic.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (e.ClickCount < 2)
                return;

            if (!bFullSize)
            {
                bFullSize = true;
                this.MaxWidth = double.PositiveInfinity;
                this.MaxHeight = double.PositiveInfinity;
            }
            else
            {
                bFullSize = false;
                this.MaxWidth = ImageWidth;
                this.MaxHeight = ImageHeight;
            }
        }

        /// <summary>
        /// Gets or sets the id of the image.
        /// </summary>
        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Gets or sets the relative source of the image.
        /// </summary>
        public string RelativeSource
        {
            get { return this.relativeSource; }
            set { this.relativeSource = value; }
        }

        /// <summary>
        /// Gets or sets the alternative text of the image.
        /// </summary>
        public string AlternativeText
        {
            get { return this.alternativeText; }
            set { this.alternativeText = value; }
        }

        /// <summary>
        /// Gets or sets the export width of the image.
        /// </summary>
        public double? ExportWidth
        {
            get { return this.exportWidth; }
            set { this.exportWidth = value; }
        }

        /// <summary>
        /// Gets or sets the export height of the image.
        /// </summary>
        public double? ExportHeight
        {
            get { return this.exportHeight; }
            set { this.exportHeight = value; }
        }
    }
}
