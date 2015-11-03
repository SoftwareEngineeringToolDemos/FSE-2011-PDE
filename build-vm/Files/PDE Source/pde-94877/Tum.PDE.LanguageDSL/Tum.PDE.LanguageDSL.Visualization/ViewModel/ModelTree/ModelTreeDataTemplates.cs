using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.Reflection;
using System.Xml;
using System.IO;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// Data templates provider.
    /// </summary>
    /// <remarks>
    /// Format: /Templates/DataTemplate.xsd
    ///
    /// </remarks>
    public static class ModelTreeDataTemplates
    {
        public static List<DataTemplateViewModel> GetTemplates(BaseModelElementViewModel vm)
        {
            List<DataTemplateViewModel> templates = new List<DataTemplateViewModel>();
            if (vm is BaseAttributeElementViewModel)
            {
                templates.AddRange(ModelTreeDataTemplates.GetDomainElementViewModelTemplates(vm as BaseAttributeElementViewModel));
            }

            if (vm is TreeNodeViewModel)
            {
                List<DataTemplateViewModel> temp = ModelTreeDataTemplates.GetDomainClassPropertyGridViewModelTemplates(vm as TreeNodeViewModel);
                if( temp != null )
                    templates.AddRange(temp);
            }

            return templates;
        }

        public static List<DataTemplateViewModel> GetDomainElementViewModelTemplates(BaseAttributeElementViewModel vm)
        { 
            MetaModel metaModel = vm.Element.GetMetaModel();

            return ParseFile(vm.ViewModelStore, "DomainClassValidationTemplate.xml", 
                new string[]{
                    vm.Element.Name,                         // CustomString0
                    metaModel.Namespace,                     // CustomString1
                });
        }
        public static List<DataTemplateViewModel> GetDomainClassPropertyGridViewModelTemplates(BaseAttributeElementViewModel vm)
        {
            MetaModel metaModel = vm.Element.GetMetaModel();
            DomainClass element = vm.Element as DomainClass;
            if (element == null )
                return null;

            string examples = "";
            bool bReferenceFound = false;
            foreach (DomainRole role in element.RolesPlayed)
            {
                if (role.Relationship is ReferenceRelationship && !bReferenceFound)
                    if (role.IsPropertyGenerator)
                    {
                        bReferenceFound = true;

                        examples += "       // EXAMLE: Custom values provider for role editor: " + "\r\n";
                        examples += "       // HINT: Don't forget to set 'Generates Double Derived' to 'True' for " + element.Name + "\r\n";
                        examples += "       protected override void CreateEditorViewModelFor" + role.PropertyName + "Role(System.Collections.Generic.List<PropertyGridEditorViewModel> collection)" + "\r\n";
                        examples += "       {" + "\r\n";
                        examples += "           /*" + "\r\n";
                        examples += "           Copy and paste from the original method " + "\r\n";
                        examples += "           */" + "\r\n\r\n";

                        examples += "           // Change:" + "\r\n";
                        examples += "           editor.DefaultValuesProvider = new LookupListEditorDefaultValuesProvider<object>(GetDefaultElements);" + "\r\n";

                        examples += "           // End of original method:" + "\r\n";
                        examples += "           collection.Add(editor);" + "\r\n" + "\r\n";
                        
                        examples += "       }" + "\r\n";


                        examples += "       // This method returns the default values for a role view model" + "\r\n";
                        examples += "       private List<object> GetDefaultElements(LookupListEditorViewModel viewModel)" + "\r\n";
                        examples += "       {" + "\r\n";
                        examples += "           " + element.Name + " element = this.Element as " + element.Name + ";\r\n";
                        examples += "           // TODO" + "\r\n";
                        examples += "       }" + "\r\n";
                    }

                if (bReferenceFound)
                    break;
            }

            List<DataTemplateViewModel> retVms = ParseFile(vm.ViewModelStore, "DomainClassPropertyGridTemplate.xml",
                new string[]{
                    vm.Element.Name,                         // CustomString0
                    metaModel.Namespace,                     // CustomString1
                    examples,                                // CustomString2
                });



            DataTemplateViewModel specificVM = new DataTemplateViewModel(vm.ViewModelStore, "Specific ViewModel Properties",
                GetSpecificViewModelString(element, false));
            retVms.Add(specificVM);
            specificVM.Description = "Properties and Roles generated for Specific ViewModels...";

            return retVms;
        }

        private static string GetSpecificViewModelString(DomainClass domainClass, bool bBase)
        {
            string specificVMProperties = "";
            if (domainClass.GenerateSpecificViewModel == false)
                specificVMProperties = "// Specific ViewModels are generated if 'GenerateSpecificVM' is set to true. This is not the case for the DomainClass '" + domainClass.Name + "': " + "\r\n";
            else
            {
                specificVMProperties = "";
                if (!bBase)
                {
                    specificVMProperties += "// The following general properties  are available for binding in the Specific ViewModel '" + domainClass.Name + "SpecificViewModel': \r\n";
                    specificVMProperties += "    DomainElementName (string)" + "\r\n";
                    specificVMProperties += "    DomainElementFullName (string)" + "\r\n";
                    specificVMProperties += "    DomainElementHasName (bool)" + "\r\n";
                    specificVMProperties += "    DomainElementType (string)" + "\r\n";
                    specificVMProperties += "    DomainElementTypeDisplayName (string)" + "\r\n";
                    specificVMProperties += "    DomainElementParentHasName (bool)" + "\r\n";
                    specificVMProperties += "    DomainElementParentName (string)" + "\r\n";
                    specificVMProperties += "    DomainElementParentFullName (string)" + "\r\n";
                    specificVMProperties += "    DomainElementParentHasFirstExistingName (bool)" + "\r\n";
                    specificVMProperties += "    DomainElementParentFirstExistingName (string)" + "\r\n";
                    specificVMProperties += "    DomainElementHasParentFullPath (bool)" + "\r\n";
                    specificVMProperties += "    DomainElementParentFullPath (string)" + "\r\n\r\n";
                }

                specificVMProperties += "// The following properties/roles are available for binding in the Specific ViewModel '" + domainClass.Name + "SpecificViewModel':";


                specificVMProperties += "\r\n";
                foreach (DomainProperty p in domainClass.Properties)
                {
                    if (p.IsElementName)
                        continue;

                    if (p.Type == null)
                        continue;

                    specificVMProperties += "   "+p.Name + "\r\n";
                }

                foreach (DomainRole role in domainClass.RolesPlayed)
                {
                    if (role.Relationship.InheritanceModifier == InheritanceModifier.Abstract)
                        continue;

                    if (role.Relationship.Source != role)
                    {
                        if (!domainClass.GenerateSpecificViewModelOppositeReferences)
                            continue;

                        if (!(role.Relationship is ReferenceRelationship))
                            continue;
                    }

                    //if( !role.IsPropertyGenerator )
                    //	continue;

                    if (role.Relationship is EmbeddingRelationship && !domainClass.GenerateSpecificViewModelEmbeddings)
                        continue;

                    if (role.Relationship is ReferenceRelationship && !domainClass.GenerateSpecificViewModelReferences)
                        if (role.Relationship.Source == role)
                            continue;

                    /*
                    if (role.Relationship.InheritanceModifier == InheritanceModifier.Abstract ||
                        role.Relationship.Source != role)
                        continue;

                    if (!role.IsPropertyGenerator)
                        continue;

                    if (role.Relationship is EmbeddingRelationship && !domainClass.GenerateSpecificViewModelEmbeddings)
                        continue;

                    if (role.Relationship is ReferenceRelationship && !domainClass.GenerateSpecificViewModelReferences)
                        continue;
                    */

                    if (role.Multiplicity == Tum.PDE.LanguageDSL.Multiplicity.ZeroMany || role.Multiplicity == Tum.PDE.LanguageDSL.Multiplicity.OneMany)
                    {
                        specificVMProperties += "   " + role.PropertyName + "VMs // for DomainClasses of type '" + role.Opposite.RolePlayer.Name + "' and Relationship type '"+role.Relationship.Name+"'" + "\r\n";
                    }
                    else
                    {
                        specificVMProperties += "   " + role.PropertyName + "VM // for DomainClass of type '" + role.Opposite.RolePlayer.Name + "' and Relationship type '" + role.Relationship.Name + "'" + "\r\n";
                    }
                }

                if (domainClass.BaseClass != null)
                    if (domainClass.BaseClass.GenerateSpecificViewModel)
                    {
                        specificVMProperties += "\r\n";
                        specificVMProperties += "// ***Base Class '"+domainClass.BaseClass.Name+"' of " + domainClass.Name + "***:" + "\r\n";
                        specificVMProperties += GetSpecificViewModelString(domainClass.BaseClass, true);
                    }
            }

            return specificVMProperties;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="elementName"></param>
        /// <param name="metmodelName"></param>
        /// <param name="nameSpace"></param>
        /// <param name="customStrings"></param>
        /// <remarks>
        /// Replaceable fields:
        /// $CustomString0$
        /// ...
        /// $CustomString19$
        /// </remarks>
        private static string ReplaceFields(string text, params string[] customStrings)
        {
            for (int i = 0; i < customStrings.Count(); i++)
            {
                string par = "$CustomString" + i.ToString() +"$";
                text = text.Replace(par, customStrings.ElementAt(i));
            }

            return text;
        }
        private static List<DataTemplateViewModel> ParseFile(ViewModelStore store, string embeddedFileName, params string[] customStrings)
        {
            List<DataTemplateViewModel> viewModels = new List<DataTemplateViewModel>();
            
            XmlDocument doc = GetFile(embeddedFileName);
            XmlNodeList list = doc.DocumentElement.GetElementsByTagName("DataTemplate");
            foreach (XmlNode node in list)
            {
                string displayName = null;
                string description = null;
                string imageURI = null;
                string syntaxHighlighting = "C#";
                string template = null;
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    switch (node.ChildNodes[i].Name)
                    {
                        case "DisplayName":
                            if (node.ChildNodes[i].HasChildNodes)
                                displayName = node.ChildNodes[i].ChildNodes[0].Value;
                            else
                                displayName = node.ChildNodes[i].Value;
                            break;

                        case "Description":
                            if (node.ChildNodes[i].HasChildNodes)
                                description = node.ChildNodes[i].ChildNodes[0].Value;
                            else
                                description = node.ChildNodes[i].Value;
                            break;

                        case "ImageURI":
                            if (node.ChildNodes[i].HasChildNodes)
                                imageURI = node.ChildNodes[i].ChildNodes[0].Value;
                            else
                                imageURI = node.ChildNodes[i].Value;
                            break;

                        case "SyntaxHighlighting":
                            if (node.ChildNodes[i].HasChildNodes)
                                syntaxHighlighting = node.ChildNodes[i].ChildNodes[0].Value;
                            else
                                syntaxHighlighting = node.ChildNodes[i].Value;
                            break;

                        case "Template":
                            if (node.ChildNodes[i].HasChildNodes)
                                if (node.ChildNodes[i].ChildNodes[0] is XmlCDataSection)
                                {
                                    template = (node.ChildNodes[i].ChildNodes[0] as XmlCDataSection).Value;
                                    break;
                                }

                            template = node.ChildNodes[i].Value;
                            break;
                    }
                }

                if (displayName != null && template != null)
                {
                    // parse template
                    template = ReplaceFields(template.Trim(), customStrings);

                    // create vm
                    DataTemplateViewModel vm = new DataTemplateViewModel(store, displayName, template);
                    if (description != null)
                        vm.Description = description;
                    if (imageURI != null)
                        vm.ImageUri = imageURI;
                    if (syntaxHighlighting != null)
                        vm.SyntaxHighlighting = syntaxHighlighting;
                    viewModels.Add(vm);
                }
            }

            return viewModels;
        }

        /// <summary>
        /// Loads a specified file from Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram.Templates.
        /// </summary>
        /// <param name="embeddedFileName"></param>
        /// <returns></returns>
        private static XmlDocument GetFile(string embeddedFileName)
        {
            XmlDocument xdoc = new XmlDocument();
            StreamReader reader = new StreamReader(Assembly.GetAssembly(typeof(DataTemplates)).GetManifestResourceStream("Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree.Templates." + embeddedFileName));
            xdoc.LoadXml(reader.ReadToEnd());
            reader.Close();

            return xdoc;
        }
    }
}
