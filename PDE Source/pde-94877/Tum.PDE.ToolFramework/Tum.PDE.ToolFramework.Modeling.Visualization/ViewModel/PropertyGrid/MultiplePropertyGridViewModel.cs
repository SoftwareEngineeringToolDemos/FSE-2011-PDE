using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// Class to group multiple property grid view models together.
    /// </summary>
    public class MultiplePropertyGridViewModel : PropertyGridViewModel
    {
        List<PropertyGridViewModel> elementVMs;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="elementVMs">Element vms.</param>
        public MultiplePropertyGridViewModel(ViewModelStore viewModelStore, List<PropertyGridViewModel> elementVMs)
            : base(viewModelStore, null)
        {
            this.elementVMs = elementVMs;
        }

        /// <summary>
        /// Gets or sets the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
        {
            get
            {
                return "";
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// Returns the collection of editor view models.
        /// </summary>
        /// <returns></returns>
        public override List<PropertyGridEditorViewModel> GetEditorViewModels()
        {
            List<PropertyGridEditorViewModel> editorVms = new List<PropertyGridEditorViewModel>();

            // simply remove not appliable editors or extend the gathered information for 
            // appliable editors as compared to what we already have in the editors collection. 
            if (this.elementVMs.Count > 0)
                editorVms.AddRange(this.elementVMs[0].GetEditorViewModels());

            for (int i = 1; i < this.elementVMs.Count; i++)
            {
                List<PropertyGridEditorViewModel> editorsToRemove = new List<PropertyGridEditorViewModel>();
                foreach (PropertyGridEditorViewModel editor in editorVms)
                {
                    // multi binding allowed?
                    if (!editor.CanHandleMultipleElements)
                    {
                        editorsToRemove.Add(editor);
                        continue;
                    }

                    // compare editor types and property names to be binded. If we find a match, update 
                    // binding information and keep in the editors collection.
                    bool bKeep = false;
                    foreach (PropertyGridEditorViewModel fCompare in this.elementVMs[i].GetEditorViewModels())
                    {
                        if (fCompare.GetType() == editor.GetType())
                        {
                            if (editor.PropertyName == fCompare.PropertyName &&
                                editor.IsPropertyReadOnly == fCompare.IsPropertyReadOnly)
                            {
                                editor.Elements.AddRange(fCompare.Elements);
                                bKeep = true;
                            }
                        }
                    }
                    if (!bKeep)
                        editorsToRemove.Add(editor);
                }

                foreach (PropertyGridEditorViewModel f in editorsToRemove)
                    editorVms.Remove(f);
            }

            return editorVms;
        }
    }
}
