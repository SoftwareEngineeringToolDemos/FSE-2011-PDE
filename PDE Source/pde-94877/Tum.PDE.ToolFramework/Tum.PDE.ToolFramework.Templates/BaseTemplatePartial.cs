using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates
{
    public enum GenerationEditorType
    {
        Application,
        VSPlugin
    }

    /// <summary>
    /// Base template.
    /// </summary>
    public partial class BaseTemplate
    {
        private GenerationEditorType editorType = GenerationEditorType.Application;

        /// <summary>
        /// Gets or sets the meta model.
        /// </summary>
        public MetaModel MetaModel { get; set; }

        public string GeneratedResourceName { get; set; }
        public string GeneratedNamespace { get; set; }

        /// <summary>
        /// Gets or sets the editor type.
        /// </summary>
        public GenerationEditorType EditorType 
        {
            get
            {
                return this.editorType;
            }
            set
            {
                this.editorType = value;
            }
        }
    }
}