using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Design;

namespace Tum.PDE.LanguageDSL
{
    /// <summary>
    /// Source: DSL Tools
    /// </summary>
    internal class DomainEnumPropertyDescriptor : Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor
    {
        internal const char FlagEnumDelimiter = '|';

        private DomainEnumeration domainEnum;
        private ReadOnlyCollection<string> enumFields;

        public override System.ComponentModel.TypeConverter Converter
        {
            get
            {
                return new DomainEnumConverter();
            }
        }

        public DomainEnumPropertyDescriptor(ElementTypeDescriptor owner, ModelElement modelElement, DomainPropertyInfo domainProperty, DomainEnumeration domainEnum, Attribute[] attributes)
            : base(owner, modelElement, domainProperty, attributes)
        {
            this.domainEnum = domainEnum;

            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            foreach(EnumerationLiteral enumerationLiteral in this.domainEnum.Literals)
                list.Add(enumerationLiteral.Name);
            
            enumFields = list.AsReadOnly();
        }

        public override object GetEditor(System.Type editorBaseType)
        {
            if (domainEnum.IsFlags)
                return new FlagEnumerationEditor(enumFields, '|');
            return new EnumerationEditor(enumFields);
        }

        internal class DomainEnumConverter : TypeConverter
        {

            public DomainEnumConverter()
            {
            }

            public override bool CanConvertFrom(ITypeDescriptorContext context, System.Type sourceType)
            {
                if (sourceType != typeof(string))
                    return base.CanConvertFrom(context, sourceType);
                return true;
            }

            public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
            {
                if (destinationType != typeof(string))
                    return base.CanConvertTo(context, destinationType);
                return true;
            }

            public override bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context)
            {
                return true;
            }

        }

        internal sealed class EnumerationEditor : UITypeEditor
        {

            private ReadOnlyCollection<string> enumFields;

            public EnumerationEditor(ReadOnlyCollection<string> enumFields)
            {
                this.enumFields = enumFields;
            }

            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                if (context == null)
                    throw new System.ArgumentNullException("context");
                if (provider == null)
                    throw new System.ArgumentNullException("provider");

                System.Windows.Forms.Design.IWindowsFormsEditorService iwindowsFormsEditorService = provider.GetService(typeof(System.Windows.Forms.Design.IWindowsFormsEditorService)) as System.Windows.Forms.Design.IWindowsFormsEditorService;
                if (iwindowsFormsEditorService != null)
                {
                    ListBoxControl listBoxControl = new ListBoxControl(iwindowsFormsEditorService);
                    listBoxControl.Items.Add("None");
                    foreach(string s1 in enumFields)
                        listBoxControl.Items.Add(s1);

                    string s2 = (string)value;
                    if (System.String.IsNullOrEmpty(s2))
                        listBoxControl.SelectedIndex = 0;
                    else
                        listBoxControl.SelectedIndex = listBoxControl.FindString(s2);
                    iwindowsFormsEditorService.DropDownControl(listBoxControl);
                    
                    string s3 = System.String.Empty;
                    int i = listBoxControl.SelectedIndex;
                    if (i > 0)
                        s3 = listBoxControl.Items[i] as string;
                    return s3;
                }
                return value;
            }

            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.DropDown;
            }

        }

        internal sealed class ListBoxControl : System.Windows.Forms.ListBox
        {

            private IWindowsFormsEditorService editorService;

            internal ListBoxControl(IWindowsFormsEditorService editorService)
            {
                if (editorService == null)
                    throw new System.ArgumentNullException("editorService");

                this.editorService = editorService;

                Click += new System.EventHandler(ListBoxControl_Click);
            }

            private void ListBoxControl_Click(object sender, System.EventArgs e)
            {
                editorService.CloseDropDown();
            }

        }
    }
}
