using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Xml;

using HtmlAgilityPack;

using Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Converter
{
    /// <summary>
    /// This class is designed for the conversion of a subset of html to Wpf (as needed by VModell).
    /// Thus, only the following elements are supported:
    /// <list type="bullet">
    ///     <listheader>
    ///         <element>element</element>
    ///         <description>description</description>
    ///     </listheader>
    ///     <item>
    ///         <element>p</element>
    ///         <description>Converted to FlowDocument Paragraph. Accepted attributes: align, style=margin***.</description>
    ///     </item>
    ///     <item>
    ///         <element>a</element>
    ///         <description>Converted to FlowDocument Hyperlink. Accepted attributes: href.</description>
    ///     </item>
    ///     <item>
    ///         <element>b, u, i</element>
    ///         <description>Converted to FlowDocument Span/Run with corresponding style properties (FontWeight, FontStyle, TextDecorations).</description>
    ///     </item>
    ///     <item>
    ///         <element>img</element>
    ///         <description>Converted to Image. Accepted attributes: align, src, alt, id.</description>
    ///     </item>
    ///     <item>
    ///         <element>List (ul, ol, li)</element>
    ///         <description>Converted to FlowDocument List.</description>
    ///     </item>
    ///     <item>
    ///         <element>Table (table, tr, td)</element>
    ///         <description>
    ///         Converted to FlowDocument Table. Accepted attribute: "border" for table.
    ///         
    ///         Warning: colspan, rowspan are not supported.
    ///         </description>
    ///     </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// Based on XAML to HTML Conversion Demo: http://msdn.microsoft.com/en-us/library/aa972129.aspx
    /// Uses HtmlAgilityPack: http://www.codeplex.com/htmlagilitypack
    /// </remarks>
    public class HtmlToXamlConverter
    {
        #region Fields and constant values
        private static string assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;


        /// <summary>
        /// FlowDocument name.
        /// </summary>
        public const string Xaml_FlowDocument = "HtmlFlowDocument";

        /// <summary>
        /// Xaml namespace.
        /// </summary>
        public const string Xaml_Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";

        /// <summary>
        /// Xaml namespace vmx types.
        /// </summary>
        public static string Xaml_Namespace_Tum_VMX_Types = "clr-namespace:Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html;assembly=" + assemblyName;

        /// <summary>
        /// FlowDocument paragraph.
        /// </summary>
        public const string Xaml_Paragraph = "Paragraph";

        /// <summary>
        /// FlowDocument run.
        /// </summary>
        public const string Xaml_Run = "Run";

        /// <summary>
        /// FlowDocument span.
        /// </summary>
        public const string Xaml_Span = "Span";

        /// <summary>
        /// FlowDocument border thickness.
        /// </summary>
        public const string Xaml_BorderThickness = "BorderThickness";

        /// <summary>
        /// FlowDocument border brush.
        /// </summary>
        public const string Xaml_BorderBrush = "BorderBrush";

        /// <summary>
        /// FlowDocument text alignment.
        /// </summary>
        public const string Xaml_TextAlignment = "TextAlignment";

        /// <summary>
        /// FlowDocument text decorations.
        /// </summary>
        public const string Xaml_TextDecorations = "TextDecorations";

        /// <summary>
        /// FlowDocument text decorations underline.
        /// </summary>
        public const string Xaml_TextDecorations_Underline = "Underline";

        /// <summary>
        /// FlowDocument font weight.
        /// </summary>
        public const string Xaml_FontWeight = "FontWeight";

        /// <summary>
        /// FlowDocument font weight bold.
        /// </summary>
        public const string Xaml_FontWeight_Bold = "Bold";

        /// <summary>
        /// FlowDocument font style.
        /// </summary>
        public const string Xaml_FontStyle = "FontStyle";

        /// <summary>
        /// FlowDocument font style italic.
        /// </summary>
        public const string Xaml_FontStyle_Italic = "Italic";

        /// <summary>
        /// FlowDocument hyperlink.
        /// </summary>
        public const string Xaml_Hyperlink = "HtmlHyperlink";

        /// <summary>
        /// FlowDocument hyperlink click.
        /// </summary>
        public const string Xaml_Hyperlink_Click = "Click";

        /// <summary>
        /// FlowDocument hyperlink click value.
        /// </summary>
        public const string Xaml_Hyperlink_Click_Value = "HyperlinkClicked";

        /// <summary>
        /// FlowDocument hyperlink navigation uri.
        /// </summary>
        public const string Xaml_Hyperlink_NavigateUri = "NavigateUri";

        /// <summary>
        /// FlowDocument hyperlink target name.
        /// </summary>
        public const string Xaml_Hyperlink_TargetName = "TargetName";

        /// <summary>
        /// FlowDocument image.
        /// </summary>
        public const string Xaml_Image = "HtmlImage";

        /// <summary>
        /// FlowDocument image source.
        /// </summary>
        public const string Xaml_Image_Source = "HtmlImage.Source";

        /// <summary>
        /// FlowDocument image bitmapimage.
        /// </summary>
        public const string Xaml_Image_BitmapImage = "BitmapImage";

        /// <summary>
        /// FlowDocument uri source.
        /// </summary>
        public const string Xaml_UriSource = "UriSource";

        /// <summary>
        /// FlowDocument horizontal alignment.
        /// </summary>
        public const string Xaml_HorizontalAlignment = "HorizontalAlignment";

        /// <summary>
        /// FlowDocument margin.
        /// </summary>
        public const string Xaml_Margin = "Margin";

        /// <summary>
        /// FlowDocument list.
        /// </summary>
        public const string Xaml_List = "List";

        /// <summary>
        /// FlowDocument list item.
        /// </summary>
        public const string Xaml_ListItem = "ListItem";

        /// <summary>
        /// FlowDocument list marker style.
        /// </summary>
        public const string Xaml_List_MarkerStyle = "MarkerStyle";

        /// <summary>
        /// FlowDocument list marker style decimal.
        /// </summary>
        public const string Xaml_List_MarkerStyle_Decimal = "Decimal";

        /// <summary>
        /// FlowDocument list marker style disc.
        /// </summary>
        public const string Xaml_List_MarkerStyle_Disc = "Disc";

        /// <summary>
        /// FlowDocument table.
        /// </summary>
        public const string Xaml_Table = "Table";

        /// <summary>
        /// FlowDocument table column.
        /// </summary>
        public const string Xaml_TableColumn = "TableColumn";

        /// <summary>
        /// FlowDocument table row group.
        /// </summary>
        public const string Xaml_TableRowGroup = "TableRowGroup";

        /// <summary>
        /// FlowDocument table row.
        /// </summary>
        public const string Xaml_TableRow = "TableRow";

        /// <summary>
        /// FlowDocument table cell.
        /// </summary>
        public const string Xaml_TableCell = "TableCell";

        /// <summary>
        /// FlowDocument bold.
        /// </summary>
        public const string Xaml_Bold = "Bold";

        /// <summary>
        /// FlowDocument underline.
        /// </summary>
        public const string Xaml_Underline = "Underline";

        /// <summary>
        /// FlowDocument italic.
        /// </summary>
        public const string Xaml_Italic = "Italic";
        #endregion

        /// <summary>
        /// Converts an html string into xaml string.
        /// </summary>
        /// <param name="htmlDocument">Html document.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        /// <returns>
        /// Well-formed xml string representing XAML equivalent for the input html.
        /// </returns>
        public static string ConvertHtmlToXaml(HtmlDocument htmlDocument, ValidationResult conversionResult, string vModellDirectory)
        {
            // Decide what name to use as a root
            string rootElementName = HtmlToXamlConverter.Xaml_FlowDocument;

            // Create an XmlDocument for generated xaml
            XmlDocument xamlTree = new XmlDocument();
            XmlElement xamlFlowDocumentElement = xamlTree.CreateElement(null, rootElementName, HtmlToXamlConverter.Xaml_Namespace_Tum_VMX_Types);
            //xamlFlowDocumentElement.SetAttribute("TextOptions.TextFormattingMode", "Display");

            try
            {
                // Source context is a stack of all elements - ancestors of a parentElement
                List<HtmlNode> sourceContext = new List<HtmlNode>(10);

                // convert root html element
                AddBlock(xamlFlowDocumentElement, htmlDocument.DocumentNode, sourceContext, conversionResult, vModellDirectory);

                // Return a string representing resulting Xaml
                xamlFlowDocumentElement.SetAttribute("xml:space", "preserve");

            }
            catch (Exception ex)
            {
                if (conversionResult != null)
                    conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Error, "Conversion failed: " + ex.Message));
            }

            return xamlFlowDocumentElement.OuterXml;
        }

        /// <summary>
        /// Analyzes the given XmlElement htmlElement, recognizes it as some HTML element and adds it as a child to a xamlParentElement.
        /// </summary>
        /// <param name="xamlParentElement">Parent xaml element, to which new converted element will be added/// </param>
        /// <param name="htmlNode"> Source html element subject to convert to xaml.</param>
        /// <param name="sourceContext"></param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        /// <returns>
        /// Last processed html node. Normally it should be the same htmlElement as was passed as a paramater.
        /// The caller must use this node to get to next sibling from it.
        /// </returns>
        private static HtmlNode AddBlock(XmlElement xamlParentElement, HtmlNode htmlNode, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory)
        {
            if (htmlNode.NodeType == HtmlNodeType.Document)
            {
                // Recurse into element subtree
                for (HtmlNode htmlChildNode = htmlNode.FirstChild; htmlChildNode != null; htmlChildNode = htmlChildNode != null ? htmlChildNode.NextSibling : null)
                {
                    htmlChildNode = AddBlock(xamlParentElement, htmlChildNode, sourceContext, conversionResult, vModellDirectory);
                }
            }
            else if (htmlNode.NodeType == HtmlNodeType.Text || htmlNode.NodeType == HtmlNodeType.Comment)
            {
                htmlNode = AddImplicitParagraph(xamlParentElement, htmlNode, sourceContext, conversionResult, vModellDirectory);
            }
            else if (htmlNode.NodeType == HtmlNodeType.Element)
            {
                // Put source element to the stack if it is a block element
                if (HtmlSchema.IsBlockElement(htmlNode.Name.ToLower()))
                    sourceContext.Add(htmlNode);

                // Convert the name to lowercase, because html elements are case-insensitive
                string htmlElementName = htmlNode.Name.ToLower();

                // Switch to an appropriate kind of processing depending on html element name
                switch (htmlElementName)
                {
                    // Paragraphs:
                    case "p":
                        AddParagraph(xamlParentElement, htmlNode, sourceContext, conversionResult, vModellDirectory);
                        break;

                    case "ol":
                    case "ul":
                        // List element conversion
                        AddList(xamlParentElement, htmlNode, sourceContext, conversionResult, vModellDirectory);
                        break;

                    case "table":
                        // hand off to table parsing function which will perform special table syntax checks
                        AddTable(xamlParentElement, htmlNode, sourceContext, conversionResult, vModellDirectory);
                        break;

                    default:
                        // Wrap a sequence of inlines into an implicit paragraph
                        htmlNode = AddImplicitParagraph(xamlParentElement, htmlNode, sourceContext, conversionResult, vModellDirectory);
                        break;
                }

                // Remove the element from the stack
                if (sourceContext.Count > 0)
                {
                    System.Diagnostics.Debug.Assert(sourceContext.Count > 0 && sourceContext[sourceContext.Count - 1] == htmlNode);
                    sourceContext.RemoveAt(sourceContext.Count - 1);
                }
            }

            return htmlNode;
        }

        /// <summary>
        /// Generates Paragraph element from P.
        /// </summary>
        /// <param name="xamlParentElement">XmlElement representing Xaml parent to which the converted element should be added</param>
        /// <param name="htmlElement">XmlElement representing Html element to be converted</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        /// <param name="sourceContext"></param>
        private static void AddParagraph(XmlElement xamlParentElement, HtmlNode htmlElement, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory)
        {
            // Create a XAML element corresponding to this html element
            XmlElement xamlElement = xamlParentElement.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_Paragraph, HtmlToXamlConverter.Xaml_Namespace);

            // apply local paragraph properties
            bool bAlignmentSet = false;
            foreach (HtmlAttribute attribute in htmlElement.Attributes)
            {
                string name = attribute.Name.ToLower();
                switch (name)
                {
                    case "align":
                        xamlElement.SetAttribute(Xaml_TextAlignment, ParseTextAlignment(attribute.Value, conversionResult));
                        bAlignmentSet = true;
                        break;

                    case "style":
                        Hashtable cssAttributes = GetCssAttributes(attribute.Value);

                        // only margins are supported in inline style attribute
                        bool marginSet = false;
                        string marginTop = "0";
                        string marginBottom = "0";
                        string marginLeft = "0";
                        string marginRight = "0";
                        foreach (string cssName in cssAttributes.Keys)
                        {
                            string attributeValue = cssAttributes[cssName].ToString();
                            switch (cssName)
                            {
                                case "margin-top":
                                    marginSet = true;
                                    marginTop = attributeValue;
                                    break;
                                case "margin-right":
                                    marginSet = true;
                                    marginRight = attributeValue;
                                    break;
                                case "margin-bottom":
                                    marginSet = true;
                                    marginBottom = attributeValue;
                                    break;
                                case "margin-left":
                                    marginSet = true;
                                    marginLeft = attributeValue;
                                    break;

                                case "margin":
                                    marginSet = true;
                                    marginLeft = marginRight = marginTop = marginBottom = attributeValue;
                                    break;

                                default:
                                    if (conversionResult != null)
                                    {
                                        conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                                            "AddParagraph: Unknown style attribute on paragraph: " + attribute.Value));
                                    }
                                    break;
                            }
                        }

                        if (marginSet)
                        {
                            xamlElement.SetAttribute(Xaml_Margin, ParseMargin(marginLeft, marginRight, marginTop, marginBottom, conversionResult));
                        }
                        break;

                    default:
                        if (conversionResult != null)
                        {
                            conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                                "AddParagraph: Unknown attribute on paragraph: " + name));
                        }
                        break;
                }
            }
            if (!bAlignmentSet)
                xamlElement.SetAttribute(Xaml_TextAlignment, "Left");

            // Recurse into element subtree
            for (HtmlNode htmlChildNode = htmlElement.FirstChild; htmlChildNode != null; htmlChildNode = htmlChildNode.NextSibling)
            {
                AddInline(xamlElement, htmlChildNode, sourceContext, conversionResult, vModellDirectory);
            }

            // Add the new element to the parent.
            xamlParentElement.AppendChild(xamlElement);
        }

        /// <summary>
        /// Creates a Paragraph element and adds all nodes starting from htmlNode converted to appropriate Inlines.
        /// </summary>
        /// <param name="xamlParentElement">XmlElement representing Xaml parent to which the converted element should be added</param>
        /// <param name="htmlNode">XmlNode starting a collection of implicitly wrapped inlines. </param>
        /// <param name="sourceContext"></param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        /// <returns>The last htmlNode added to the implicit paragraph</returns>
        private static HtmlNode AddImplicitParagraph(XmlElement xamlParentElement, HtmlNode htmlNode, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory)
        {
            // Collect all non-block elements and wrap them into implicit Paragraph
            XmlElement xamlParagraph = xamlParentElement.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_Paragraph, HtmlToXamlConverter.Xaml_Namespace);
            HtmlNode lastNodeProcessed = null;
            while (htmlNode != null)
            {
                if (htmlNode.NodeType == HtmlNodeType.Comment)
                {
                    AddCommentText(xamlParagraph, htmlNode, conversionResult, vModellDirectory);
                }
                else if (htmlNode.NodeType == HtmlNodeType.Text)
                {
                    if (htmlNode.InnerText.Trim().Length > 0)
                    {
                        AddTextRun(xamlParagraph, htmlNode, conversionResult, vModellDirectory);
                    }
                }
                else if (htmlNode.NodeType == HtmlNodeType.Element)
                {
                    if (HtmlSchema.IsBlockElement(htmlNode.Name.ToLower()))
                    {
                        // The sequence of non-blocked inlines ended. Stop implicit loop here.
                        break;
                    }
                    else
                        AddInline(xamlParagraph, htmlNode, sourceContext, conversionResult, vModellDirectory);
                }

                // Store last processed node to return it at the end
                lastNodeProcessed = htmlNode;
                htmlNode = htmlNode.NextSibling;
            }

            // Add the Paragraph to the parent
            // If only whitespaces and commens have been encountered,
            // then we have nothing to add in implicit paragraph; forget it.
            if (xamlParagraph.FirstChild != null)
            {
                xamlParentElement.AppendChild(xamlParagraph);
            }

            // Need to return last processed node
            return lastNodeProcessed;
        }

        /// <summary>
        /// Converts htmlTableElement to a Xaml Table element. Adds tbody elements if they are missing so
        /// that a resulting Xaml Table element is properly formed.
        /// </summary>
        /// <param name="xamlParentElement">Parent xaml element to which a converted table must be added.</param>
        /// <param name="htmlTableElement">XmlElement reprsenting the Html table element to be converted</param>
        /// <param name="sourceContext">Source context.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        private static void AddTable(XmlElement xamlParentElement, HtmlNode htmlTableElement, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory)
        {
            // Parameter validation
            System.Diagnostics.Debug.Assert(htmlTableElement.Name.ToLower() == "table");
            System.Diagnostics.Debug.Assert(xamlParentElement != null);

            // Create xamlTableElement
            XmlElement xamlTableElement = xamlParentElement.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_Table, HtmlToXamlConverter.Xaml_Namespace);

            Hashtable inheritedProperties = new Hashtable();

            // apply local table properties, only border is supported
            foreach (HtmlAttribute attribute in htmlTableElement.Attributes)
            {
                string name = attribute.Name.ToLower();
                switch (name)
                {
                    case "border":
                        inheritedProperties.Add("border", attribute.Value);
                        //xamlTableElement.SetAttribute(Xaml_BorderThickness, ParseBorderThickness(attribute.Value, conversionResult));
                        //xamlTableElement.SetAttribute(Xaml_BorderBrush, "Black");
                        break;

                    default:
                        if (conversionResult != null)
                        {
                            conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                                "AddTable: Unknown attribute on table: " + name));
                        }
                        break;
                }
            }



            // Process table body - TR elements
            HtmlNode htmlChildNode = htmlTableElement.FirstChild;
            while (htmlChildNode != null)
            {
                string htmlChildName = htmlChildNode.Name.ToLower();
                if (htmlChildName == "tr")
                {
                    XmlElement xamlTableRowGroup = xamlTableElement.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_TableRowGroup, HtmlToXamlConverter.Xaml_Namespace);
                    htmlChildNode = AddTableRows(xamlTableRowGroup, htmlChildNode, sourceContext, conversionResult, vModellDirectory, inheritedProperties);

                    //if (xamlTableRowGroup.HasChildNodes)
                    //{
                    xamlTableElement.AppendChild(xamlTableRowGroup);
                    //}
                }
                else
                {
                    if (conversionResult != null)
                    {

                        if (String.IsNullOrWhiteSpace(htmlChildNode.InnerText) && htmlChildNode.NodeType == HtmlNodeType.Text)
                        {
                            // for some reason, there is always a white space behind the table/tr/td elements.. so dont react on that
                            // do we need a warning?
                        }
                        else
                            conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                                "AddTable: Unknown child: " + htmlChildName + ":" + htmlChildNode.OuterHtml));
                    }
                    htmlChildNode = htmlChildNode.NextSibling;
                }
            }

            //if (xamlTableElement.HasChildNodes)
            //{
            xamlParentElement.AppendChild(xamlTableElement);
            //}
        }

        /// <summary>
        /// Adds TableRow elements . The rows are converted from Html tr elements.
        /// </summary>
        /// <param name="xamlTableRowGroup">XmlElement representing Xaml TableRowGroup element to which the converted rows should be added.</param>
        /// <param name="htmlTRStartNode">XmlElement representing the first tr child.</param>
        /// <param name="sourceContext"></param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        /// <param name="inheritedProperties">Inherited properties.</param>
        /// <returns>
        /// XmlNode representing the current position of the iterator among tr elements.
        /// </returns>
        private static HtmlNode AddTableRows(XmlElement xamlTableRowGroup, HtmlNode htmlTRStartNode, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory, Hashtable inheritedProperties)
        {
            // Parameter validation
            System.Diagnostics.Debug.Assert(xamlTableRowGroup.LocalName == Xaml_TableRowGroup);

            // Initialize child node for iteratimg through children to the first tr element
            HtmlNode htmlChildNode = htmlTRStartNode;
            while (htmlChildNode != null)
            {
                if (htmlChildNode.Name.ToLower() == "tr")
                {
                    XmlElement xamlTableRowElement = xamlTableRowGroup.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_TableRow, HtmlToXamlConverter.Xaml_Namespace);
                    sourceContext.Add(htmlChildNode);

                    // We do not support any attributes on tr items
                    foreach (HtmlAttribute attribute in htmlChildNode.Attributes)
                    {
                        if (conversionResult != null)
                        {
                            conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                                "AddTableRows: Unknown attribute " + attribute.Name + ":" + attribute.Value + " on tr: " + htmlChildNode.Name));
                        }
                    }

                    AddTableCellsToTableRow(xamlTableRowElement, htmlChildNode.FirstChild, sourceContext, conversionResult, vModellDirectory, inheritedProperties);
                    //if (xamlTableRowElement.HasChildNodes)
                    //{
                    xamlTableRowGroup.AppendChild(xamlTableRowElement);
                    //}

                    System.Diagnostics.Debug.Assert(sourceContext.Count > 0 && sourceContext[sourceContext.Count - 1] == htmlChildNode);
                    sourceContext.RemoveAt(sourceContext.Count - 1);

                    // Advance
                    htmlChildNode = htmlChildNode.NextSibling;
                }
                else if (htmlChildNode.Name.ToLower() == "td")
                {
                    // Tr element is not present. We create one and add td elements to it
                    XmlElement xamlTableRowElement = xamlTableRowGroup.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_TableRow, HtmlToXamlConverter.Xaml_Namespace);

                    htmlChildNode = AddTableCellsToTableRow(xamlTableRowElement, htmlChildNode, sourceContext, conversionResult, vModellDirectory, inheritedProperties);
                    //if (xamlTableRowElement.HasChildNodes)
                    //{
                    xamlTableRowGroup.AppendChild(xamlTableRowElement);
                    //}
                }
                else
                {
                    if (conversionResult != null)
                    {
                        if (String.IsNullOrWhiteSpace(htmlChildNode.InnerText) && htmlChildNode.NodeType == HtmlNodeType.Text)
                        {
                            // for some reason, there is always a white space behind the table/tr/td elements.. so dont react on that
                            // do we need a warning?
                        }
                        else
                            conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                                "AddTableRows: Unknown child: " + htmlChildNode.Name + ":" + htmlChildNode.OuterHtml));
                    }

                    htmlChildNode = htmlChildNode.NextSibling;
                }
            }
            return htmlChildNode;
        }

        /// <summary>
        /// Adds TableCell elements to xamlTableRowElement.
        /// </summary>
        /// <param name="xamlTableRowElement">XmlElement representing Xaml TableRow element to which the converted cells should be added.</param>
        /// <param name="htmlTDStartNode">XmlElement representing the child of tr element from which we should start adding td elements. </param>
        /// <param name="sourceContext"></param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        /// <param name="inheritedProperties">Inherited properties.</param>
        /// <returns>
        /// XmlElement representing the current position of the iterator among the children of the parent Html tbody/tr element
        /// </returns>
        private static HtmlNode AddTableCellsToTableRow(XmlElement xamlTableRowElement, HtmlNode htmlTDStartNode, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory, Hashtable inheritedProperties)
        {
            System.Diagnostics.Debug.Assert(xamlTableRowElement.LocalName == Xaml_TableRow);
            HtmlNode htmlChildNode = htmlTDStartNode;

            while (htmlChildNode != null && htmlChildNode.Name.ToLower() != "tr")
            {
                if (htmlChildNode.Name.ToLower() == "td")
                {
                    XmlElement xamlTableCellElement = xamlTableRowElement.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_TableCell, HtmlToXamlConverter.Xaml_Namespace);
                    sourceContext.Add(htmlChildNode);

                    // We do not support any attributes on td items
                    foreach (HtmlAttribute attribute in htmlChildNode.Attributes)
                    {
                        if (conversionResult != null)
                        {
                            conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                                "AddTableCellsToTableRow: Unknown attribute " + attribute.Name + ":" + attribute.Value + " on td: " + htmlChildNode.Name));
                        }
                    }
                    foreach (object key in inheritedProperties.Keys)
                        if (key.ToString() == "border")
                        {
                            xamlTableCellElement.SetAttribute(Xaml_BorderThickness, ParseBorderThickness(inheritedProperties[key].ToString(), conversionResult));
                            xamlTableCellElement.SetAttribute(Xaml_BorderBrush, "Black");
                        }

                    AddDataToTableCell(xamlTableCellElement, htmlChildNode.FirstChild, sourceContext, conversionResult, vModellDirectory);


                    //if (xamlTableCellElement.HasChildNodes)
                    //{
                    xamlTableRowElement.AppendChild(xamlTableCellElement);
                    //}                   

                    System.Diagnostics.Debug.Assert(sourceContext.Count > 0 && sourceContext[sourceContext.Count - 1] == htmlChildNode);
                    sourceContext.RemoveAt(sourceContext.Count - 1);

                    htmlChildNode = htmlChildNode.NextSibling;
                }
                else
                {
                    if (conversionResult != null)
                    {
                        if (String.IsNullOrWhiteSpace(htmlChildNode.InnerText) && htmlChildNode.NodeType == HtmlNodeType.Text)
                        {
                            // for some reason, there is always a white space behind the table/tr/td elements.. so dont react on that
                            // do we need a warning?
                        }
                        else
                            conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                                "AddTableCellsToTableRow: Unknown child: " + htmlChildNode.Name + ":" + htmlChildNode.OuterHtml));
                    }

                    htmlChildNode = htmlChildNode.NextSibling;
                }
            }
            return htmlChildNode;
        }

        /// <summary>
        /// Adds table cell data to xamlTableCellElement
        /// </summary>
        /// <param name="xamlTableCellElement">XmlElement representing Xaml TableCell element to which the converted data should be added.</param>
        /// <param name="htmlDataStartNode">XmlElement representing the start element of data to be added to xamlTableCellElement.</param>
        /// <param name="sourceContext"></param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        private static void AddDataToTableCell(XmlElement xamlTableCellElement, HtmlNode htmlDataStartNode, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory)
        {
            // Parameter validation
            System.Diagnostics.Debug.Assert(xamlTableCellElement.LocalName == Xaml_TableCell);

            for (HtmlNode htmlChildNode = htmlDataStartNode; htmlChildNode != null; htmlChildNode = htmlChildNode != null ? htmlChildNode.NextSibling : null)
            {
                // Process a new html element and add it to the td element
                htmlChildNode = AddBlock(xamlTableCellElement, htmlChildNode, sourceContext, conversionResult, vModellDirectory);
            }
        }

        /// <summary>
        /// Converts Html ul or ol element into Xaml list element. During conversion if the ul/ol element has any children 
        /// that are not li elements, they are ignored and not added to the list element
        /// </summary>
        /// <param name="xamlParentElement">XmlElement representing Xaml parent to which the converted element should be added</param>
        /// <param name="htmlListElement">XmlElement representing Html ul/ol element to be converted</param>
        /// <param name="sourceContext"></param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        private static void AddList(XmlElement xamlParentElement, HtmlNode htmlListElement, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory)
        {
            string htmlListElementName = htmlListElement.Name.ToLower();

            // Create Xaml List element
            XmlElement xamlListElement = xamlParentElement.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_List, HtmlToXamlConverter.Xaml_Namespace);

            // We do not support any attributes on lists
            foreach (HtmlAttribute attribute in htmlListElement.Attributes)
            {
                if (conversionResult != null)
                {
                    conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                        "AddList: Unknown attribute " + attribute.Name + ":" + attribute.Value + " on list: " + htmlListElement.Name));
                }
            }

            // Set default list markers
            if (htmlListElementName == "ol")
            {
                // Ordered list
                xamlListElement.SetAttribute(HtmlToXamlConverter.Xaml_List_MarkerStyle, Xaml_List_MarkerStyle_Decimal);
            }
            else
            {
                // Unordered list - all elements other than OL treated as unordered lists
                xamlListElement.SetAttribute(HtmlToXamlConverter.Xaml_List_MarkerStyle, Xaml_List_MarkerStyle_Disc);
            }

            // Recurse into list subtree
            for (HtmlNode htmlChildNode = htmlListElement.FirstChild; htmlChildNode != null; htmlChildNode = htmlChildNode.NextSibling)
            {
                if (htmlChildNode.NodeType == HtmlNodeType.Element && htmlChildNode.Name.ToLower() == "li")
                {
                    sourceContext.Add(htmlChildNode);
                    AddListItem(xamlListElement, htmlChildNode, sourceContext, conversionResult, vModellDirectory);

                    System.Diagnostics.Debug.Assert(sourceContext.Count > 0 && sourceContext[sourceContext.Count - 1] == htmlChildNode);
                    sourceContext.RemoveAt(sourceContext.Count - 1);
                }
                else
                {
                    // Not an li element. Add it to previous ListBoxItem
                    //  We need to append the content to the end
                    // of a previous list item.
                }
            }

            // Add the List element to xaml tree - if it is not empty
            if (xamlListElement.HasChildNodes)
            {
                xamlParentElement.AppendChild(xamlListElement);
            }
        }

        /// <summary>
        /// Converts htmlLIElement into Xaml ListItem element, and appends it to the parent xamlListElement
        /// </summary>
        /// <param name="xamlListElement">XmlElement representing Xaml List element to which the converted td/th should be added</param>
        /// <param name="htmlLIElement">XmlElement representing Html li element to be converted</param>
        /// <param name="sourceContext">Source context.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        private static void AddListItem(XmlElement xamlListElement, HtmlNode htmlLIElement, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory)
        {
            // Parameter validation
            System.Diagnostics.Debug.Assert(xamlListElement != null);
            System.Diagnostics.Debug.Assert(xamlListElement.LocalName == Xaml_List);
            System.Diagnostics.Debug.Assert(htmlLIElement != null);
            System.Diagnostics.Debug.Assert(htmlLIElement.Name.ToLower() == "li");

            XmlElement xamlListItemElement = xamlListElement.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_ListItem, HtmlToXamlConverter.Xaml_Namespace);

            // We do not support any attributes on list items
            foreach (HtmlAttribute attribute in htmlLIElement.Attributes)
            {
                if (conversionResult != null)
                {
                    conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                        "AddList: Unknown attribute " + attribute.Name + ":" + attribute.Value + " on list: " + htmlLIElement.Name));
                }
            }

            // Process children of the ListItem
            for (HtmlNode htmlChildNode = htmlLIElement.FirstChild; htmlChildNode != null; htmlChildNode = htmlChildNode != null ? htmlChildNode.NextSibling : null)
            {
                htmlChildNode = AddBlock(xamlListItemElement, htmlChildNode, sourceContext, conversionResult, vModellDirectory);
            }

            // Add resulting ListBoxItem to a xaml parent
            xamlListElement.AppendChild(xamlListItemElement);
        }

        /// <summary>
        /// Adds inline elements.
        /// </summary>
        /// <param name="xamlParentElement">Parent xaml element, to which new converted element will be added </param>
        /// <param name="htmlNode"> Source html element subject to convert to xaml.</param>
        /// <param name="sourceContext"></param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        private static void AddInline(XmlElement xamlParentElement, HtmlNode htmlNode, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory)
        {
            if (htmlNode.NodeType == HtmlNodeType.Comment)
            {
                AddCommentText(xamlParentElement, htmlNode, conversionResult, vModellDirectory);
            }
            else if (htmlNode.NodeType == HtmlNodeType.Text)
            {
                AddTextRun(xamlParentElement, htmlNode, conversionResult, vModellDirectory);
            }
            else if (htmlNode.NodeType == HtmlNodeType.Element)
            {
                // Identify element name
                string htmlElementName = htmlNode.Name.ToLower();

                // Put source element to the stack
                sourceContext.Add(htmlNode);

                switch (htmlElementName)
                {
                    case "a":
                        AddHyperlink(xamlParentElement, htmlNode, sourceContext, conversionResult, vModellDirectory);
                        break;

                    case "img":
                        AddImage(xamlParentElement, htmlNode, sourceContext, conversionResult, vModellDirectory);
                        break;

                    case "b":
                    case "u":
                    case "i":
                        AddSpanOrRun(xamlParentElement, htmlNode, sourceContext, conversionResult, vModellDirectory);
                        break;

                    default:
                        if (conversionResult != null)
                        {
                            conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                                "AddInline: Unknown inline element: " + htmlElementName));
                        }
                        break;
                }
                // Ignore all other elements non-(block/inline/image)

                // Remove the element from the stack
                System.Diagnostics.Debug.Assert(sourceContext.Count > 0 && sourceContext[sourceContext.Count - 1] == htmlNode);
                sourceContext.RemoveAt(sourceContext.Count - 1);
            }
        }

        /// <summary>
        /// Adds a span or a run element depending on whether the current element has child element or not.
        /// </summary>
        /// <param name="xamlParentElement">Parent xaml element, to which new converted element will be added </param>
        /// <param name="htmlElement"> Source html element subject to convert to xaml.</param>
        /// <param name="sourceContext"></param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        private static void AddSpanOrRun(XmlElement xamlParentElement, HtmlNode htmlElement, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory)
        {
            // Decide what XAML element to use for this inline element.
            // Check whether it contains any nested inlines
            bool elementHasChildren = false;
            for (HtmlNode htmlNode = htmlElement.FirstChild; htmlNode != null; htmlNode = htmlNode.NextSibling)
            {
                if (htmlNode.NodeType == HtmlNodeType.Element)
                {
                    elementHasChildren = true;
                    break;

                    //string htmlChildName = htmlNode.Name.ToLower();
                    //if (htmlChildName == "u" || htmlChildName == "i" || htmlChildName == "b")
                    //{
                    //elementHasChildren = true;
                    //    break;
                    //}
                }
            }

            string xamlElementName = elementHasChildren ? HtmlToXamlConverter.Xaml_Span : HtmlToXamlConverter.Xaml_Run;

            // Create a XAML element corresponding to this html element
            XmlElement xamlElement = xamlParentElement.OwnerDocument.CreateElement(null, xamlElementName, HtmlToXamlConverter.Xaml_Namespace);

            // Apply local properties
            string htmlChildName = htmlElement.Name.ToLower();
            switch (htmlChildName)
            {
                case "u":
                    xamlElement.SetAttribute(HtmlToXamlConverter.Xaml_TextDecorations, HtmlToXamlConverter.Xaml_TextDecorations_Underline);
                    break;

                case "i":
                    xamlElement.SetAttribute(HtmlToXamlConverter.Xaml_FontStyle, HtmlToXamlConverter.Xaml_FontStyle_Italic);
                    break;

                case "b":
                    xamlElement.SetAttribute(HtmlToXamlConverter.Xaml_FontWeight, HtmlToXamlConverter.Xaml_FontWeight_Bold);
                    break;
            }

            // Recurse into element subtree
            for (HtmlNode htmlChildNode = htmlElement.FirstChild; htmlChildNode != null; htmlChildNode = htmlChildNode.NextSibling)
            {
                AddInline(xamlElement, htmlChildNode, sourceContext, conversionResult, vModellDirectory);
            }

            // Add the new element to the parent.
            xamlParentElement.AppendChild(xamlElement);
        }

        /// <summary>
        /// Adds a text run to a xaml tree.
        /// </summary>
        /// <param name="xamlElement">XamlElement to add the text run to.</param>
        /// <param name="htmlElement">Text node.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        private static void AddTextRun(XmlElement xamlElement, HtmlNode htmlElement, ValidationResult conversionResult, string vModellDirectory)
        {
            string textData = htmlElement.InnerText;
            if (textData.Length > 0)
            {
                //textData = System.Web.HttpUtility.HtmlDecode(textData);
                textData = ExtendedHtmlUtility.HtmlEntityDecode(textData);
                xamlElement.AppendChild(xamlElement.OwnerDocument.CreateTextNode(textData));
            }
        }

        /// <summary>
        /// Adds a comment text run to a xaml tree.
        /// </summary>
        /// <param name="xamlElement">XamlElement to add the text run to.</param>
        /// <param name="htmlNode">Comment node.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        private static void AddCommentText(XmlElement xamlElement, HtmlNode htmlNode, ValidationResult conversionResult, string vModellDirectory)
        {
            string textData = htmlNode.InnerText;
            //textData = System.Web.HttpUtility.HtmlDecode(textData);
            textData = ExtendedHtmlUtility.HtmlEntityDecode(textData);

            XmlElement node = xamlElement.OwnerDocument.CreateElement(null, "TextBlock", HtmlToXamlConverter.Xaml_Namespace);
            node.SetAttribute("FontStyle", "Italic");
            node.SetAttribute("Foreground", "Gray");
            node.SetAttribute("Text", textData);
            node.SetAttribute("TextWrapping", "WrapWithOverflow");
            xamlElement.AppendChild(node);

        }

        /// <summary>
        /// Adds a hyperlink.
        /// </summary>
        /// <param name="xamlParentElement">XmlElement representing Xaml parent to which the converted element should be added</param>
        /// <param name="htmlElement">Source html element subject to convert to xaml.</param>
        /// <param name="sourceContext"></param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        private static void AddHyperlink(XmlElement xamlParentElement, HtmlNode htmlElement, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory)
        {
            // Convert href attribute into NavigateUri and TargetName
            string href = GetAttribute(htmlElement, "href");
            if (href == null)
            {
                // When href attribute is missing - ignore the hyperlink
                if (conversionResult != null)
                {
                    conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                        "AddHyperlink: Href is missing: " + htmlElement.InnerHtml));
                }
            }
            else
            {
                // Create a XAML element corresponding to this html element
                XmlElement xamlElement = xamlParentElement.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_Hyperlink, HtmlToXamlConverter.Xaml_Namespace_Tum_VMX_Types);

                //string[] hrefParts = href.Split(new char[] { '#' });
                //if (hrefParts.Length > 0 && hrefParts[0].Trim().Length > 0)
                //{
                //xamlElement.SetAttribute(HtmlToXamlConverter.Xaml_Hyperlink_NavigateUri, hrefParts[0].Trim());
                //    xamlElement.SetAttribute(HtmlToXamlConverter.Xaml_Hyperlink_TargetName, hrefParts[0].Trim());
                //}
                //if (hrefParts.Length == 2 && hrefParts[1].Trim().Length > 0)
                //{
                //     xamlElement.SetAttribute(HtmlToXamlConverter.Xaml_Hyperlink_TargetName, hrefParts[1].Trim());
                //}
                xamlElement.SetAttribute(HtmlToXamlConverter.Xaml_Hyperlink_TargetName, href.Trim());

                // Recurse into element subtree
                for (HtmlNode htmlChildNode = htmlElement.FirstChild; htmlChildNode != null; htmlChildNode = htmlChildNode.NextSibling)
                {
                    AddInline(xamlElement, htmlChildNode, sourceContext, conversionResult, vModellDirectory);
                }

                // Add the new element to the parent.
                xamlParentElement.AppendChild(xamlElement);
            }
        }

        /// <summary>
        /// Adds an image.
        /// </summary>
        /// <param name="xamlParentElement">XmlElement representing Xaml parent to which the converted element should be added</param>
        /// <param name="htmlElement">Source html element subject to convert to xaml.</param>
        /// <param name="sourceContext"></param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        private static void AddImage(XmlElement xamlParentElement, HtmlNode htmlElement, List<HtmlNode> sourceContext, ValidationResult conversionResult, string vModellDirectory)
        {
            // Very simple processing for now
            bool bFoundImage = false;

            XmlElement xamlElement = xamlParentElement.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_Image, HtmlToXamlConverter.Xaml_Namespace_Tum_VMX_Types);
            string src = GetAttribute(htmlElement, "src");
            if (src != null)
            {
                string filePath = vModellDirectory + "\\" + src;
                if (System.IO.File.Exists(filePath))
                {
                    try
                    {
                        // try to load image
                        System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                        BitmapImage bimg = new BitmapImage();
                        bimg.BeginInit();
                        bimg.UriSource = new Uri(filePath, UriKind.Absolute);
                        bimg.EndInit();
                        image.Source = bimg;

                        string width = GetAttribute(htmlElement, "width");
                        string height = GetAttribute(htmlElement, "height");

                        if (width != null && height != null)
                        {
                            xamlElement.SetAttribute("MaxWidth", width);
                            xamlElement.SetAttribute("MaxHeight", height);
                        }
                        xamlElement.SetAttribute("Stretch", "Uniform");

                        XmlElement source = xamlElement.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_Image_Source, HtmlToXamlConverter.Xaml_Namespace_Tum_VMX_Types);
                        XmlElement bmp = source.OwnerDocument.CreateElement(null, HtmlToXamlConverter.Xaml_Image_BitmapImage, HtmlToXamlConverter.Xaml_Namespace);
                        bmp.SetAttribute(HtmlToXamlConverter.Xaml_UriSource, filePath);
                        source.AppendChild(bmp);
                        xamlElement.AppendChild(source);

                        bFoundImage = true;
                    }
                    catch { }
                }
            }

            if (!bFoundImage)
            {
                xamlElement.SetAttribute("Source", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Save-32.png");
                xamlElement.SetAttribute("Width", "32");
                xamlElement.SetAttribute("Height", "32");
            }

            foreach (HtmlAttribute attribute in htmlElement.Attributes)
            {
                string name = attribute.Name.ToLower();
                switch (name)
                {
                    case "align":
                        xamlElement.SetAttribute(HtmlToXamlConverter.Xaml_HorizontalAlignment, attribute.Value);
                        break;

                    case "alt":
                        xamlElement.SetAttribute("AlternativeText", attribute.Value);
                        break;

                    case "id":
                        xamlElement.SetAttribute("Id", attribute.Value);
                        break;

                    case "src":
                        xamlElement.SetAttribute("RelativeSource", attribute.Value);
                        break;

                    case "width":
                        xamlElement.SetAttribute("ExportWidth", attribute.Value);
                        break;

                    case "height":
                        xamlElement.SetAttribute("ExportHeight", attribute.Value);
                        break;

                    default:
                        if (conversionResult != null)
                        {
                            conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                                "AddImage: Unknown attribute on img: " + name));
                        }
                        break;
                }
            }

            // Add the new element to the parent.
            xamlParentElement.AppendChild(xamlElement);
        }

        /// <summary>
        /// Returns a value for an attribute by its name (ignoring casing)
        /// </summary>
        /// <param name="element">XmlElement in which we are trying to find the specified attribute.</param>
        /// <param name="attributeName">String representing the attribute name to be searched for</param>
        /// <returns></returns>
        public static string GetAttribute(HtmlNode element, string attributeName)
        {
            attributeName = attributeName.ToLower();

            for (int i = 0; i < element.Attributes.Count; i++)
            {
                if (element.Attributes[i].Name.ToLower() == attributeName)
                {
                    return element.Attributes[i].Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Extracts a value of css attribute from css style definition.
        /// </summary>
        /// <param name="cssStyle">Source csll style definition</param>
        /// <param name="attributeName">A name of css attribute to extract.</param>
        /// <returns>
        /// A string rrepresentation of an attribute value if found;
        /// null if there is no such attribute in a given string.
        /// </returns>
        public static string GetCssAttribute(string cssStyle, string attributeName)
        {
            //  This is poor man's attribute parsing. Replace it by real css parsing
            if (cssStyle != null)
            {
                string[] styleValues;

                attributeName = attributeName.ToLower();

                // Check for width specification in style string
                styleValues = cssStyle.Split(';');

                for (int styleValueIndex = 0; styleValueIndex < styleValues.Length; styleValueIndex++)
                {
                    string[] styleNameValue;

                    styleNameValue = styleValues[styleValueIndex].Split(':');
                    if (styleNameValue.Length == 2)
                    {
                        if (styleNameValue[0].Trim().ToLower() == attributeName)
                        {
                            return styleNameValue[1].Trim();
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns local css attributes.
        /// </summary>
        /// <returns>Hashtable with css attributes (name and value).</returns>
        public static Hashtable GetCssAttributes(string styleInline)
        {
            if (String.IsNullOrEmpty(styleInline))
                return new Hashtable();

            Hashtable localProperties = new Hashtable();

            // Parse the styles from the inline attribute.
            string[] styleValues = styleInline.Split(';');
            for (int i = 0; i < styleValues.Length; i++)
            {
                string[] styleNameValue = styleValues[i].Split(':');
                if (styleNameValue.Length == 2)
                {
                    string styleName = styleNameValue[0].Trim().ToLower();
                    string styleValue = UnQuote(styleNameValue[1].Trim()).ToLower();

                    localProperties.Add(styleName, styleValue);
                }
            }

            return localProperties;
        }

        /// <summary>
        /// Returns string extracted from quotation marks
        /// </summary>
        /// <param name="value">
        /// String representing value enclosed in quotation marks
        /// </param>
        internal static string UnQuote(string value)
        {
            if (value.StartsWith("\"") && value.EndsWith("\"") || value.StartsWith("'") && value.EndsWith("'"))
            {
                value = value.Substring(1, value.Length - 2).Trim();
            }
            return value;
        }

        /// <summary>
        /// Parses the html align attribute given as a string.
        /// </summary>
        /// <param name="alignment">Html align attribute value.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <returns>
        /// Returns the corresponding xaml alignment value as a string. 
        /// Should the given value not be recognized, the default value ('Left') is returned.</returns>
        public static string ParseTextAlignment(string alignment, ValidationResult conversionResult)
        {
            string alignmentValue = alignment.ToLower();
            switch (alignmentValue)
            {
                case "left":
                    return "Left";

                case "right":
                    return "Right";

                case "center":
                    return "Center";

                case "justify":
                    return "Justify";

                default:
                    if (conversionResult != null)
                    {
                        conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                            "ParseTextAlignment: Unknown value: " + alignment));
                    }
                    return "Left";
            }
        }

        /// <summary>
        /// Parses the html border attribute given as a string.
        /// </summary>
        /// <param name="border">Html border attribute value.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <returns>
        /// Returns the corresponding xaml border thickness value as a string. 
        /// Should the given value not be recognized, the default value ('0') is returned.</returns>
        public static string ParseBorderThickness(string border, ValidationResult conversionResult)
        {
            string bordernValue = border.ToLower();
            if (String.IsNullOrEmpty(bordernValue))
            {
                if (conversionResult != null)
                {
                    conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                        "ParseBorderThickness: Unknown value: " + border));
                }
            }
            else
            {
                int result;
                if (Int32.TryParse(bordernValue, out result))
                {
                    return result.ToString();
                }
                else
                {
                    if (conversionResult != null)
                    {
                        conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                            "ParseBorderThickness: Value is not a number: " + border));
                    }
                }
            }

            return "0";
        }

        /// <summary>
        /// Parses the html margin attributes.
        /// </summary>
        /// <param name="marginLeft">Left margin.</param>
        /// <param name="marginRight">Right margin.</param>
        /// <param name="marginTop">Top margin.</param>
        /// <param name="marginBottom">Bottom margin.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <returns>Returns the corresponding xaml margin value as a string.</returns>
        public static string ParseMargin(string marginLeft, string marginRight, string marginTop, string marginBottom, ValidationResult conversionResult)
        {
            marginLeft = ParseMarginValue(marginLeft, conversionResult);
            marginRight = ParseMarginValue(marginRight, conversionResult);
            marginTop = ParseMarginValue(marginTop, conversionResult);
            marginBottom = ParseMarginValue(marginBottom, conversionResult);

            string xamlMargin = marginLeft + "," + marginRight + "," + marginTop + "," + marginBottom;
            return xamlMargin;
        }

        /// <summary>
        /// Parses the html margin attribute given as a string.
        /// </summary>
        /// <param name="margin">Html margin attribute value.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <returns>
        /// Returns the corresponding xaml margin value as a string. 
        /// Should the given value not be recognized, the default value ('0') is returned.</returns>
        private static string ParseMarginValue(string margin, ValidationResult conversionResult)
        {
            string marginValue = margin.ToLower();
            if (String.IsNullOrEmpty(marginValue))
            {
                if (conversionResult != null)
                {
                    conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                        "ParseMargin: Unknown value: " + margin));
                }
            }
            else
            {
                int result;
                if (Int32.TryParse(marginValue, out result))
                {
                    return result.ToString();
                }
                else
                {
                    if (conversionResult != null)
                    {
                        conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                            "ParseMargin: Value is not a number: " + margin));
                    }
                }
            }

            return "0";
        }

        /// <summary>
        /// HtmlSchema class maintains static information about HTML structure.
        /// 
        /// So far it only contains information about block elements.
        /// </summary>
        public class HtmlSchema
        {
            private static ArrayList _htmlBlockElements;

            static HtmlSchema()
            {
                InitializeBlockElements();
            }

            /// <summary>
            /// Initializes the array of html block element names.
            /// </summary>
            private static void InitializeBlockElements()
            {
                _htmlBlockElements = new ArrayList();

                _htmlBlockElements.Add("blockquote");
                _htmlBlockElements.Add("body");
                _htmlBlockElements.Add("caption");
                _htmlBlockElements.Add("center");
                _htmlBlockElements.Add("cite");
                _htmlBlockElements.Add("dd");
                _htmlBlockElements.Add("dir"); //  treat as UL element
                _htmlBlockElements.Add("div");
                _htmlBlockElements.Add("dl");
                _htmlBlockElements.Add("dt");
                _htmlBlockElements.Add("form"); // Not a block according to XHTML spec
                _htmlBlockElements.Add("h1");
                _htmlBlockElements.Add("h2");
                _htmlBlockElements.Add("h3");
                _htmlBlockElements.Add("h4");
                _htmlBlockElements.Add("h5");
                _htmlBlockElements.Add("h6");
                _htmlBlockElements.Add("html");
                _htmlBlockElements.Add("li");
                _htmlBlockElements.Add("menu"); //  treat as UL element
                _htmlBlockElements.Add("ol");
                _htmlBlockElements.Add("p");
                _htmlBlockElements.Add("pre"); // Renders text in a fixed-width font
                _htmlBlockElements.Add("table");
                _htmlBlockElements.Add("tbody");
                _htmlBlockElements.Add("td");
                _htmlBlockElements.Add("textarea");
                _htmlBlockElements.Add("tfoot");
                _htmlBlockElements.Add("th");
                _htmlBlockElements.Add("thead");
                _htmlBlockElements.Add("tr");
                _htmlBlockElements.Add("tt");
                _htmlBlockElements.Add("ul");
            }

            /// <summary>
            /// Returns true if xmlElementName represents a block formatting element.
            /// </summary>
            /// <param name="xmlElementName"></param>
            /// <returns></returns>
            internal static bool IsBlockElement(string xmlElementName)
            {
                return _htmlBlockElements.Contains(xmlElementName);
            }
        }
    }
}
