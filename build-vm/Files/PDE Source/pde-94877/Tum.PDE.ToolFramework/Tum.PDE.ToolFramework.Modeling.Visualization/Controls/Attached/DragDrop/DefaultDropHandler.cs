using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop.Utilities;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop
{
    /// <summary>
    /// Default drop handler.
    /// </summary>
    /// <remarks>
    /// Source: http://www.codeproject.com/KB/WPF/gong-wpf-dragdrop-ii.aspx
    /// </remarks>
    public class DefaultDropHandler : IDropTarget
    {
        /// <summary>
        /// Drag over logic.
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        public virtual void DragOver(DropInfo dropInfo)
        {
            if (CanAcceptData(dropInfo))
            {
                dropInfo.Effects = DragDropEffects.Copy;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            }
        }

        /// <summary>
        /// Drop logic.
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        public virtual void Drop(DropInfo dropInfo)
        {
            int insertIndex = dropInfo.InsertIndex;
            IList destinationList = GetList(dropInfo.TargetCollection);
            IEnumerable data = ExtractData(dropInfo.Data);

            if (dropInfo.DragInfo.VisualSource == dropInfo.VisualTarget)
            {
                IList sourceList = GetList(dropInfo.DragInfo.SourceCollection);

                foreach (object o in data)
                {
                    int index = sourceList.IndexOf(o);

                    if (index != -1)
                    {
                        sourceList.RemoveAt(index);
                        
                        if (sourceList == destinationList && index < insertIndex)
                        {
                            --insertIndex;
                        }
                    }
                }
            }

            foreach (object o in data)
            {
                destinationList.Insert(insertIndex++, o);
            }
        }

        /// <summary>
        /// Can accept data?
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        /// <returns></returns>
        protected static bool CanAcceptData(DropInfo dropInfo)
        {
            if (dropInfo.DragInfo.SourceCollection == dropInfo.TargetCollection)
            {
                return GetList(dropInfo.TargetCollection) != null;
            }
            else if (dropInfo.DragInfo.SourceCollection is ItemCollection)
            {
                return false;
            }
            else
            {
                if (TestCompatibleTypes(dropInfo.TargetCollection, dropInfo.Data))
                {
                    return !IsChildOf(dropInfo.VisualTargetItem, dropInfo.DragInfo.VisualSourceItem);
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Extract data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected static IEnumerable ExtractData(object data)
        {
            if (data is IEnumerable && !(data is string))
            {
                return (IEnumerable)data;
            }
            else
            {
                return Enumerable.Repeat(data, 1);
            }
        }

        /// <summary>
        /// Get list.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        protected static IList GetList(IEnumerable enumerable)
        {
            if (enumerable is ICollectionView)
            {
                return ((ICollectionView)enumerable).SourceCollection as IList;
            }
            else
            {
                return enumerable as IList;
            }
        }

        /// <summary>
        /// Is child of.
        /// </summary>
        /// <param name="targetItem"></param>
        /// <param name="sourceItem"></param>
        /// <returns></returns>
        protected static bool IsChildOf(UIElement targetItem, UIElement sourceItem)
        {
            ItemsControl parent = ItemsControl.ItemsControlFromItemContainer(targetItem);

            while (parent != null)
            {
                if (parent == sourceItem)
                {
                    return true;
                }

                parent = ItemsControl.ItemsControlFromItemContainer(parent);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected static bool TestCompatibleTypes(IEnumerable target, object data)
        {
            if (target == null)
                return false;

            TypeFilter filter = (t, o) =>
            {
                return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            };

            var enumerableInterfaces = target.GetType().FindInterfaces(filter, null);
            var enumerableTypes = from i in enumerableInterfaces select i.GetGenericArguments().Single();

            if (enumerableTypes.Count() > 0)
            {
                Type dataType = TypeUtilities.GetCommonBaseClass(ExtractData(data));
                return enumerableTypes.Any(t => t.IsAssignableFrom(dataType));
            }
            else
            {
                return target is IList;
            }
        }
    }
}
