using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.Reflection;
using System.Xml;
using System.IO;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    /// <summary>
    /// Data templates provider.
    /// </summary>
    /// <remarks>
    /// Format: /Templates/DataTemplate.xsd
    ///
    /// </remarks>
    public static class DataTemplates
    {
        public static List<DataTemplateViewModel> GetTemplates(BaseModelElementViewModel vm)
        {
            if (vm is SpecificDependencyDiagramViewModel)
            {
                return DataTemplates.GetSpecificDependencyDiagramTemplate(vm as SpecificDependencyDiagramViewModel);
            }
            else if (vm is DependencyDiagramViewModel)
            {
                return DataTemplates.GetDependencyDiagramTemplate(vm as DependencyDiagramViewModel);
            }
            else if (vm is SpecificElementsDiagramViewModel)
            {
                return DataTemplates.GetSpecificElementsDiagramTemplate(vm as SpecificElementsDiagramViewModel);
            }
            else if (vm is ModalDiagramViewModel)
            {
                return DataTemplates.GetModalDiagramTemplate(vm as ModalDiagramViewModel);
            }
            else if (vm is DiagramClassViewModel)
            {
                return DataTemplates.GetDiagramClassTemplate(vm as DiagramClassViewModel);
            }
            else if (vm.GetHostedElement() is ShapeClass)
            {
                return DataTemplates.GetShapeClassTemplate(vm);
            }
            else if (vm.GetHostedElement() is RelationshipShapeClass)
            {
                return DataTemplates.GetRelationshipShapeClassTemplate(vm);
            }
            else if (vm.GetHostedElement() is MappingRelationshipShapeClass)
            {
                return DataTemplates.GetMappingRelationshipShapeClassTemplate(vm);
            }

            return new List<DataTemplateViewModel>();
        }

        public static List<DataTemplateViewModel> GetSpecificDependencyDiagramTemplate(SpecificDependencyDiagramViewModel vm)
        { 
            MetaModel metaModel = vm.DiagramClassView.DiagramView.ViewContext.ModelContext.MetaModel;

            return ParseFile(vm.ViewModelStore, "SpecificDependencyDiagramTemplate.xml", 
                new string[]{
                    metaModel.Name,                             // CustomString0
                    vm.DiagramClassView.DiagramClass.Name,      // CustomString1
                    metaModel.Namespace,                        // CustomString2
                });
        }
        public static List<DataTemplateViewModel> GetSpecificElementsDiagramTemplate(SpecificElementsDiagramViewModel vm)
        {
            List<DataTemplateViewModel> templates = new List<DataTemplateViewModel>();
            templates.AddRange(GetDiagramClassTemplate(vm));

            // bindable properties and important methods
            string str = "The ViewModel generated for the SpecificElementsDiagram contains the following properties and methods: " + "\r\n" + "\r\n";
            
            str += " HostedElement:BaseModelElementViewModel (This is the currently hosted element)." + "\r\n";
            str += "      If the DomainClass currently hosted has a SpecificViewModel, than instead of the general BaseModelElementViewModel," + "\r\n";
            str += "      the specific VM is chosen" + "\r\n";

            str += " SelectedElementType:SelectedElementEnum (This is the type of the selected model)." + "\r\n";
            str += "      The SelectedElementEnum is automatically generated and contains the following values: " + "\r\n";
            str += "      - ___None___" + "\r\n";
            foreach(DomainClass d in (vm.DiagramClassView.DiagramClass as SpecificElementsDiagram).DomainClasses)
                str += "      - " + d.Name + "\r\n";
            str += "\r\n";

            str += " protected virtual void UpdateView()" + "\r\n";
            str += "      This method is called on every selection change." + "\r\n";
            str += "      The selection is saved in the 'SelectedItemsCollection' property" + "\r\n\r\n";

            str += " protected virtual void OnHostedElementDeleted" + "\r\n";
            str += "      This method is called if the hosted element is deleted." + "\r\n\r\n";
            
            DataTemplateViewModel template = new DataTemplateViewModel(vm.ViewModelStore,
                   "Customization/Visualization", str);
            template.ImageUri = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Class_32.png";
            template.Description = "This template provides help on customizing and visualizing the view.";
            templates.Add(template);

            return templates;
        }
        public static List<DataTemplateViewModel> GetModalDiagramTemplate(ModalDiagramViewModel vm)
        {
            List<DataTemplateViewModel> templates = new List<DataTemplateViewModel>();
            templates.AddRange(GetDiagramClassTemplate(vm));

            // bindable properties and important methods
            string str = "The ViewModel generated for the ModalDiagram contains the following properties and methods: " + "\r\n" + "\r\n";

            str += " HostedElementVM:BaseModelElementViewModel (This is the currently hosted element)." + "\r\n";
            str += "      If the hosted DomainClass has a SpecificViewModel, than instead of the general BaseModelElementViewModel," + "\r\n";
            str += "      the specific VM is chosen" + "\r\n\r\n";

            str += " HostedElement:DomainModelElement (This is the hosted element)." + "\r\n";
            str += "\r\n";

            str += " TitleExtension:string (This is the extension added to the docking window title after the title of the diagram)." + "\r\n";
            str += "\r\n";

            str += " NameExtension:string (This is the extension added to the identification name after the name of the diagram)." + "\r\n";
            str += "\r\n";

            str += " protected virtual void OnModelElementDeleted" + "\r\n";
            str += "      This method is called if the hosted element is deleted." + "\r\n\r\n";

            str += " protected virtual void DragOver" + "\r\n";
            str += "      This method is called during a drag over operation." + "\r\n\r\n";

            str += " protected virtual void Drop" + "\r\n";
            str += "      This method is called after an element was dropped on the diagram surface (see remarks below on Drag&Drop)." + "\r\n\r\n";

            str += " For Drag&Drop to work, the xaml part of the view has to implement specific attributes: " + "\r\n";
            str += "    dd:DragDrop.IsDropTarget and dd:DragDrop.DropHandler " + "\r\n\r\n";
            str += " An example is given below: " + "\r\n";
            str += "    xmlns:dd=\"clr-namespace:Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop\"" + "\r\n";
            str += "    <Border Grid.Row=\"3\" HorizontalAlignment=\"Stretch\" VerticalAlignment=\"Stretch\"" + "\r\n";
            str += "        Background=\"Transparent\" dd:DragDrop.IsDropTarget=\"True\" dd:DragDrop.DropHandler=\"{Binding}\"/>" + "\r\n\r\n";

            DataTemplateViewModel template = new DataTemplateViewModel(vm.ViewModelStore,
                   "Customization/Visualization", str);
            template.ImageUri = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Class_32.png";
            template.Description = "This template provides help on customizing and visualizing the view.";
            templates.Add(template);

            return templates;
        }
        public static List<DataTemplateViewModel> GetDependencyDiagramTemplate(DependencyDiagramViewModel vm)
        {
            MetaModel metaModel = vm.DiagramClassView.DiagramView.ViewContext.ModelContext.MetaModel;

            return ParseFile(vm.ViewModelStore, "DependencyDiagramTemplate.xml",
                new string[]{
                    metaModel.Name,                             // CustomString0
                    vm.DiagramClassView.DiagramClass.Name,      // CustomString1
                    metaModel.Namespace,                        // CustomString2
                });

        }
        public static List<DataTemplateViewModel> GetDiagramClassTemplate(DiagramClassViewModel vm)
        {
            MetaModel metaModel = vm.DiagramClassView.DiagramView.ViewContext.ModelContext.MetaModel;

            return ParseFile(vm.ViewModelStore, "DiagramTemplate.xml",
                new string[]{
                    metaModel.Name,                             // CustomString0
                    vm.DiagramClassView.DiagramClass.Name,      // CustomString1
                    metaModel.Namespace,                        // CustomString2
                });

        }
        public static List<DataTemplateViewModel> GetShapeClassTemplate(BaseModelElementViewModel vm)
        {
            ShapeClass shapeClass = vm.GetHostedElement() as ShapeClass;
            MetaModel metaModel = shapeClass.GetMetaModel();

            List<DataTemplateViewModel> retVms = ParseFile(vm.ViewModelStore, "ShapeClassTemplate.xml",
                new string[]{
                    shapeClass.Name,                            // CustomString0
                    metaModel.Namespace,                        // CustomString1
                });

            retVms.Add(CreateBindablePropertiesTemplate(vm));
            return retVms;

        }
        public static List<DataTemplateViewModel> GetRelationshipShapeClassTemplate(BaseModelElementViewModel vm)
        {
            RelationshipShapeClass shapeClass = vm.GetHostedElement() as RelationshipShapeClass;
            MetaModel metaModel = shapeClass.GetMetaModel();

            List<DataTemplateViewModel> retVms = ParseFile(vm.ViewModelStore, "RelationshipShapeClassTemplate.xml",
                new string[]{
                    shapeClass.Name,                            // CustomString0
                    metaModel.Namespace,                        // CustomString1
                });

            retVms.Add(CreateBindablePropertiesTemplate(vm));
            return retVms;
        }
        public static List<DataTemplateViewModel> GetMappingRelationshipShapeClassTemplate(BaseModelElementViewModel vm)
        {
            MappingRelationshipShapeClass shapeClass = vm.GetHostedElement() as MappingRelationshipShapeClass;
            MetaModel metaModel = shapeClass.GetMetaModel();

            List<DataTemplateViewModel> retVms = ParseFile(vm.ViewModelStore, "MappingRelationshipShapeClassTemplate.xml",
                new string[]{
                    shapeClass.Name,                            // CustomString0
                    metaModel.Namespace,                        // CustomString1
                });

            retVms.Add(CreateBindablePropertiesTemplate(vm));
            return retVms;
        }
        
        public static DataTemplateViewModel CreateBindablePropertiesTemplate(BaseModelElementViewModel vm)
        {
            ModelElement modelElement = vm.GetHostedElement();
            AttributedDomainElement attrDomainElement = null;

            string specificProperties = "";
            if (modelElement is ShapeClass)
            {
                attrDomainElement = ((modelElement) as ShapeClass).DomainClass;

                specificProperties =  "*** Specific properties: *** " + "\r\n";
                specificProperties += "   AbsoluteLeft (double)" + "\r\n";
                specificProperties += "   AbsoluteTop (double)" + "\r\n";
                specificProperties += "   AbsoluteLocation (PointD(double, double))" + "\r\n";
                specificProperties += "   Bounds (RectangleD(double, double, double, double))" + "\r\n";
                specificProperties += "   CanHaveNestedChildren (bool)" + "\r\n";
                specificProperties += "   CanHaveRelativeChildren (bool)" + "\r\n";
                specificProperties += "   Height (double)" + "\r\n";
                specificProperties += "   IsHeightFixed (bool)" + "\r\n";
                specificProperties += "   IsRelativeChildShape (bool)" + "\r\n";
                specificProperties += "   IsWidthFixed (bool)" + "\r\n";
                specificProperties += "   Left (double)" + "\r\n";
                specificProperties += "   Location (PointD(double, double))" + "\r\n";
                specificProperties += "   Size (SizeD(double, double))" + "\r\n";
                specificProperties += "   TakesPartInRelationship (bool)" + "\r\n";
                specificProperties += "   Top (double)" + "\r\n";
                specificProperties += "   Width (double)" + "\r\n";
                specificProperties += "\r\n";
            }
            else if (modelElement is RelationshipShapeClass || modelElement is MappingRelationshipShapeClass)
            {
                if (modelElement is RelationshipShapeClass )
                    attrDomainElement = ((modelElement) as RelationshipShapeClass).ReferenceRelationship;
                else
                    attrDomainElement = ((modelElement) as MappingRelationshipShapeClass).DomainClass;

                specificProperties = "*** Specific properties: *** " + "\r\n";
                specificProperties += "   EdgePoints (EdgePointViewModel(X,Y, ...))" + "\r\n";
                specificProperties += "   StartEdgePoint (IEdgePointViewModel(X,Y,...))" + "\r\n";
                specificProperties += "   MiddleEdgePoint (IEdgePointViewModel(X,Y,...))" + "\r\n";
                specificProperties += "   EndEdgePoint (IEdgePointViewModel(X,Y,...))" + "\r\n";
                specificProperties += "   Geometry (PathGeometry)" + "\r\n";
                specificProperties += "   FromAnchorAngle (double)" + "\r\n";
                specificProperties += "   ToAnchorAngle (double)" + "\r\n";
                specificProperties += "   RoutingMode (RoutingMode(Orthogonal, Straight))" + "\r\n";
                specificProperties += "\r\n";
            }

            bool hasSpecificDomainProperties = false;
            string specificDomainProperties = "*** Specific domain properties: *** " + "\r\n";

            if (attrDomainElement != null)
            {
                foreach (DomainProperty p in attrDomainElement.Properties)
                {
                    if( p.Type == null )
                        continue;

                    hasSpecificDomainProperties = true;
                    specificDomainProperties += "   Element_" + p.Name + "(" + p.Type.Name + ")" + "\r\n";
                }
            }

            if (!hasSpecificDomainProperties)
                specificDomainProperties = "";
            else
                specificDomainProperties += "\r\n";

            DataTemplateViewModel template = new DataTemplateViewModel(vm.ViewModelStore,
                    "Bindable Properties",

                    specificProperties +
                    
                    specificDomainProperties + 

                    "*** General properties: *** " + "\r\n" +
                    "   DomainElementName (string)" + "\r\n" +
                    "   DomainElementFullName (string)" + "\r\n" +
                    "   DomainElementHasName (bool)" + "\r\n" +
                    "   DomainElementType (string)" + "\r\n" +
                    "   DomainElementTypeDisplayName (string)" + "\r\n" +
                    "   DomainElementParentHasName (bool)" + "\r\n" +
                    "   DomainElementParentName (string)" + "\r\n" +
                    "   DomainElementParentFullName (string)" + "\r\n" +
                    "   DomainElementParentHasFirstExistingName (bool)" + "\r\n" +
                    "   DomainElementParentFirstExistingName (string)" + "\r\n" +
                    "   DomainElementHasParentFullPath (bool)" + "\r\n" +
                    "   DomainElementParentFullPath (string)");
            template.ImageUri = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Properties-32x32.png";
            template.Description = "These are bindable properties you can utilize in your data templates. ";
            template.SyntaxHighlighting = "C#";

            return template;
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
            StreamReader reader = new StreamReader(Assembly.GetAssembly(typeof(DataTemplates)).GetManifestResourceStream("Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram.Templates." + embeddedFileName));
            xdoc.LoadXml(reader.ReadToEnd());
            reader.Close();

            return xdoc;
        }
    }
}
