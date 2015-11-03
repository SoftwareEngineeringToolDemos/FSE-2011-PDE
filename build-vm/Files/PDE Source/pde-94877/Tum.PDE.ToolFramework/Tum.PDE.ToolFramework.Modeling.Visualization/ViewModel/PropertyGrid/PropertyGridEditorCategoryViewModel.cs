using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// This class represents a category in the property grid, which consists of a category name as well as
    /// a collection of editor view models.
    /// </summary>
    public class PropertyGridEditorCategoryViewModel : BaseViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="categoryName">Category name.</param>
        /// <param name="editorVms">Editors.</param>
        public PropertyGridEditorCategoryViewModel(ViewModelStore viewModelStore, string categoryName, List<PropertyGridEditorViewModel> editorVms)
            : base(viewModelStore)
        {
            this.CategoryChildren = editorVms;
            this.CategoryName = categoryName;
        }

        /// <summary>
        /// Name of the category.
        /// </summary>
        public string CategoryName { get; private set; }

        /// <summary>
        /// Children of the category. These are the actual editor view models.
        /// </summary>
        public List<PropertyGridEditorViewModel> CategoryChildren { get; private set; }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            for (int i = CategoryChildren.Count - 1; i >= 0; i--)
                if( !CategoryChildren[i].IsDisposed )
                    CategoryChildren[i].Dispose();

            CategoryChildren.Clear();

            base.OnDispose();
        }
    }
}
