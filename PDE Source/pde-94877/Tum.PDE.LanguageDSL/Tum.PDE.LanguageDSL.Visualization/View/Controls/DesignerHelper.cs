using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Tum.PDE.LanguageDSL.Visualization.View.Controls
{
    public static class DesignerHelper
    {
        /// <summary>
        /// Gets the parent object of the type DesignerCanvas starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        public static DesignerCanvas GetDesignerCanvas(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is DesignerCanvas)
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as DesignerCanvas;
        }

        /// <summary>
        /// Gets the parent object of the type DesignerItem that represents an element
        /// starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        public static DesignerItem GetDesignerItem(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is DesignerItem)
                {
                    break;
                }
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as DesignerItem;
        }
    }
}
