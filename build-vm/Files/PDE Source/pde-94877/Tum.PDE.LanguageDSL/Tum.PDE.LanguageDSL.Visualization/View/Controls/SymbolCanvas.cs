using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Tum.PDE.LanguageDSL.Visualization.View.Controls
{
    public class SymbolCanvas : Canvas
    {
        public SymbolCanvas()
        {
            Canvas.SetZIndex(this, 99999);
        }
    }
}
