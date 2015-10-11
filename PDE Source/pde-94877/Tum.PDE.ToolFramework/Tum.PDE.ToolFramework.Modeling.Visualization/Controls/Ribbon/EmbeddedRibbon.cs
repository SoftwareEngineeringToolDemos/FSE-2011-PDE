using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Ribbon
{
    /// <summary>
    /// Customization of the fluent ribbon control to make it work inside user controls.
    /// </summary>
    /// <remarks>
    /// Required change in fluent's source code:
    /// 
    /// RibbonTabsContainer: ArrangeOverride.
    /// 
    ///  /*
    ///   *  CHANGE: 
    ///   *  if( (InternalChildren[i] as RibbonTabItem).Group.Parent != null )
    ///  */
    ///  if ( (InternalChildren[i] as RibbonTabItem).Group.Parent != null )
    ///      ((InternalChildren[i] as RibbonTabItem).Group.Parent as RibbonTitleBar).InvalidateMeasure();
    /// </remarks>
    public class EmbeddedRibbon : Fluent.Ribbon
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810")]
        static EmbeddedRibbon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EmbeddedRibbon), new FrameworkPropertyMetadata(typeof(EmbeddedRibbon)));
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedRibbon()
            : base()
        {
        }
    }
}
