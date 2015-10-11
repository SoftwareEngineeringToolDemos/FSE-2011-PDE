using System;
using System.Windows;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// Helper class.
    /// </summary>
    public static class DiagramHelper
    {
        /// <summary>
        /// Gets the parent object of the type DiagramDesigner starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        public static DiagramDesigner GetDiagramDesigner(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is DiagramDesigner)
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as DiagramDesigner;
        }

        /// <summary>
        /// Gets the parent object of the type DiagramDesignerItems starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        public static DiagramDesignerItems GetDiagramDesignerItems(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is DiagramDesignerItems)
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as DiagramDesignerItems;
        }

        /// <summary>
        /// Gets the parent object of the type DiagramDesignerCanvas starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        public static DiagramDesignerCanvas GetDiagramDesignerCanvas(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is DiagramDesignerCanvas)
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as DiagramDesignerCanvas;
        }

        /// <summary>
        /// Gets the parent object of the type DiagramDesignerItem that represents a link
        /// starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        public static DiagramDesignerItem GetDiagramDesignerLink(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is DiagramDesignerItem)
                {
                    if ((parent as DiagramDesignerItem).IsDiagramLink )
                        break;
                }
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as DiagramDesignerItem;
        }

        /// <summary>
        /// Gets the parent object of the type DiagramDesignerItem that represents an element
        /// starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        public static DiagramDesignerItem GetDiagramDesignerItem(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is DiagramDesignerItem)
                {
                    if (!(parent as DiagramDesignerItem).IsDiagramLink)
                        break;
                }
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as DiagramDesignerItem;
        }

        /// <summary>
        /// Gets the children object of the specified type.
        /// </summary>
        /// <param name="startObject">Object to start the search from.</param>
        /// <param name="elementType">Type of element to find.</param>
        /// <returns>Element of the specified type if found. Null otherwise</returns>
        public static DependencyObject GetChild(DependencyObject startObject, Type elementType)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(startObject);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject obj = VisualTreeHelper.GetChild(startObject, i);
                if (obj.GetType() == elementType)
                    return obj;

                obj = GetChild(obj, elementType);
                if (obj != null)
                    return obj;
            }

            return null;
        }
    }
}
