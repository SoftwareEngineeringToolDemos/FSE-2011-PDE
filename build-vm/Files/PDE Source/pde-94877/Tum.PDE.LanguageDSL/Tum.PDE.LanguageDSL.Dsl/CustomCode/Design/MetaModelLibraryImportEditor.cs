using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL.Design
{
    /// <summary>
    /// Editor to load meta model library files.
    /// </summary>
    public class MetaModelLibraryImportEditor : System.Windows.Forms.Design.FileNameEditor
    {
        /// <summary>
        /// Contructor.
        /// </summary>
        public MetaModelLibraryImportEditor()
        {
        }

        /// <summary>
        /// Initializes the open file dialog when it is created.
        /// </summary>
        /// <param name="openFileDialog">Open file dialog.</param>
        protected override void InitializeDialog(System.Windows.Forms.OpenFileDialog openFileDialog)
        {
            base.InitializeDialog(openFileDialog);
            openFileDialog.Filter = "Language DSL file|*.lngdsl";
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            object editValue = value;
            if( editValue != null )
                 if( !String.IsNullOrEmpty(editValue.ToString().Trim()) )
                     try
                     {
                         // relative path to absolute path
                         editValue = MetaModelLibraryBase.GetAbsoluteFilePathGlobally(editValue.ToString());
                     }
                     catch { }

            object val = base.EditValue(context, provider, editValue);
            if( val != null )
                if( !String.IsNullOrEmpty(val.ToString().Trim()) )
                    try
                    {
                        // convert absolute path to relative path
                        val = MetaModelLibraryBase.GetRelativeFilePathGlobally(val.ToString());
                    }
                    catch
                    {
                    }


            return val;
        }
    }
}
