using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram;

namespace Tum.PDE.LanguageDSL.Visualization.Selectors
{
    public class DiagramItemTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Shape class template.
        /// </summary>
        public DataTemplate ShapeClassTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Relationship class template.
        /// </summary>
        public DataTemplate RelationshipClassTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Relationship class template.
        /// </summary>
        public DataTemplate MappingRelationshipClassTemplate
        {
            get;
            set;
        }
        
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is DiagramTreeNodeViewModel)
            {
                DiagramTreeNodeViewModel vm = item as DiagramTreeNodeViewModel;

                DiagramTreeNode node = vm.DiagramTreeNode;
                if (node.PresentationElementClass is MappingRelationshipShapeClass)
                    return MappingRelationshipClassTemplate;
                else if (node.PresentationElementClass is ShapeClass)
                    return ShapeClassTemplate;
                else if (node.PresentationElementClass is RelationshipShapeClass)
                    return RelationshipClassTemplate;
                else
                    return null;
            }
            else
                return null;
        }
    }
}
