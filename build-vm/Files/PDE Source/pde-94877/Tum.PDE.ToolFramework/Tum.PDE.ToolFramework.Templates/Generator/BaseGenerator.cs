using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates.Generator
{
    public abstract class BaseGenerator : T4Toolbox.Generator
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public BaseGenerator()
            : base()
        {
            this.EditorType = GenerationEditorType.Application;
        }

        /// <summary>
        /// Gets or sets root object of the class model to be generated.
        /// </summary>
        public MetaModel MetaModel { get; set; }

        /// <summary>
        /// Gets or sets the GeneratedResourceName.
        /// </summary>
        public string GeneratedResourceName { get; set; }

        /// <summary>
        /// Gets or sets the GeneratedNamespace.
        /// </summary>
        public string GeneratedNamespace { get; set; }

        /// <summary>
        /// Gets or sets the editor type.
        /// </summary>
        public GenerationEditorType EditorType
        {
            get;
            set;
        }

        /// <summary>
        /// Compliles a generator template and saves it to the specified fileName.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="outputName"></param>
        protected virtual void Run(BaseTemplate t, string outputName)
        {
            t.EditorType = EditorType;
            t.MetaModel = this.MetaModel;
            t.GeneratedResourceName = GeneratedResourceName;
            t.GeneratedNamespace = GeneratedNamespace;
            t.RenderToFile(outputName);
        }

        /// <summary>
        /// Compliles a generator template and saves it to the specified fileName.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="outputName"></param>
        protected virtual void Run(BaseTemplate t, string outputName, string buildAction)
        {
            t.EditorType = EditorType;
            t.MetaModel = this.MetaModel;
            t.GeneratedResourceName = GeneratedResourceName;
            t.GeneratedNamespace = GeneratedNamespace;
            t.RenderToFile(outputName);
            t.Output.BuildAction = buildAction;
        }

        /// <summary>
        /// Compliles a generator template and saves it to the specified fileName.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="outputName"></param>
        protected virtual void Run(BaseTemplate t, string outputName, string buildAction, Encoding encoding)
        {
            t.EditorType = EditorType;
            t.MetaModel = this.MetaModel;
            t.GeneratedResourceName = GeneratedResourceName;
            t.GeneratedNamespace = GeneratedNamespace;
            t.Output.Encoding = encoding;
            t.RenderToFile(outputName);
            t.Output.BuildAction = buildAction;
        }

        /// <summary>
        /// Validates code generation parameters.
        /// </summary>
        protected override void Validate()
        {
            if (this.MetaModel == null)
            {
                throw new T4Toolbox.TransformationException("MetaModel property must be assigned");
            }
            if (this.GeneratedResourceName == null)
            {
                throw new T4Toolbox.TransformationException("GeneratedResourceName property must be assigned");
            }
            if (this.GeneratedNamespace == null)
            {
                throw new T4Toolbox.TransformationException("GeneratedNamespace property must be assigned");
            }
        }
    }
}
