using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Xml;

using Tum.PDE.ToolFramework.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.View;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Converter
{
    /// <summary>
    /// This class is designed for the conversion of xaml flow documents to html data. The supported flow document elements are:
    /// <list type="bullet">
    ///     <listheader>
    ///         <element>element</element>
    ///         <description>description</description>
    ///     </listheader>
    ///     <item>
    ///         <element>Paragraph</element>
    ///         <description>Converted to p. Applied attributes: align, style=margin***.</description>
    ///     </item>
    ///     <item>
    ///         <element>Hyperlink</element>
    ///         <description>Converted to a. Applied attributes: href.</description>
    ///     </item>
    ///     <item>
    ///         <element>Bold, Underline, Italic elements. (which are specified via Run/Span and font***)</element>
    ///         <description>Converted to b, u, or i.</description>
    ///     </item>
    ///     <item>
    ///         <element>Image</element>
    ///         <description>Converted to img. Applied attributes: align, src, alt, id.</description>
    ///     </item>
    ///     <item>
    ///         <element>List (List, ListItem with marker style: Disc or Decimal)</element>
    ///         <description>Converted to (ul, ol, li).</description>
    ///     </item>
    ///     <item>
    ///         <element>Table (TableRowGroup, TableRow, TableColumn, TableCell) </element>
    ///         <description>
    ///         Converted to (table, tr, td). Applied attribute: "border" for table.
    ///         </description>
    ///     </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// Based on XAML to HTML Conversion Demo: http://msdn.microsoft.com/en-us/library/aa972129.aspx
    /// </remarks>
    public class XamlToHtmlConverter
    {
        /// <summary>
        /// Converts an flow document to html string.
        /// </summary>
        /// <param name="flowDocument">Flow document.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <returns>
        /// Well-formed xml string representing html equivalent for the input flow document.
        /// </returns>
        public static string ConvertXamlToHtml(FlowDocument flowDocument, ValidationResult conversionResult)
        {
            StringBuilder htmlStringBuilder = new StringBuilder();
            System.IO.StringWriter stringWriter = null;
            try
            {
                stringWriter = new System.IO.StringWriter(htmlStringBuilder);
                using (XmlTextWriter htmlWriter = new XmlTextWriter(stringWriter))
                {
                    try
                    {
                        foreach (Block block in flowDocument.Blocks)
                        {
                            AddBlock(block, htmlWriter, conversionResult);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (conversionResult != null)
                            conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Error, "Conversion failed: " + ex.Message));
                    }
                    finally
                    {
                        stringWriter = null;
                    }
                }
            }
            finally
            {
                if (stringWriter != null)
                    stringWriter.Dispose();
            }

            string htmlString = htmlStringBuilder.ToString();
            return htmlString;
        }

        /// <summary>
        /// Convert an flow document paragraph into its html representation.
        /// </summary>
        /// <param name="block">Flow document block.</param>
        /// <param name="htmlWriter">XmlTextWriter producing resulting html.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <remarks>
        /// List, Paragraph, Table are supported Block elements. Section is not supported.
        /// </remarks>
        private static void AddBlock(Block block, XmlTextWriter htmlWriter, ValidationResult conversionResult)
        {
            if (block is List)
            {
                AddList(block as List, htmlWriter, conversionResult);
            }
            else if (block is Paragraph)
            {
                AddParagraph(block as Paragraph, htmlWriter, conversionResult);
            }
            else if (block is Table)
            {
                AddTable(block as Table, htmlWriter, conversionResult);
            }
            else
            {
                // not supported: Section
                if (conversionResult != null)
                {
                    conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                        "AddBlock: Unknown block element: " + block.ToString()));
                }
            }
        }

        /// <summary>
        /// Convert an flow document block into its html representation.
        /// </summary>
        /// <param name="paragraph">Flow document paragraph.</param>
        /// <param name="htmlWriter">XmlTextWriter producing resulting html.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        private static void AddParagraph(Paragraph paragraph, XmlTextWriter htmlWriter, ValidationResult conversionResult)
        {
            htmlWriter.WriteStartElement("p");

            // convert properties: only alignment and margin are supported
            if (paragraph.TextAlignment != System.Windows.TextAlignment.Left)
                htmlWriter.WriteAttributeString("align", paragraph.TextAlignment.ToString().ToLower());

            if (paragraph.Margin.Top == paragraph.Margin.Bottom &&
                paragraph.Margin.Bottom == paragraph.Margin.Left &&
                paragraph.Margin.Left == paragraph.Margin.Right && paragraph.TextIndent == 0)
            {
                if (paragraph.Margin.Left > 0 || paragraph.Margin.Left < 0)
                    htmlWriter.WriteAttributeString("style", "margin: " + paragraph.Margin.Left.ToString());
            }
            else
            {
                string styleAttribute = "style";
                string styleAttributeValue = "";

                if (paragraph.Margin.Left > 0 || paragraph.Margin.Left < 0 || paragraph.TextIndent > 0)
                {
                    if (styleAttributeValue != "")
                        styleAttributeValue += "; ";

                    double val = paragraph.TextIndent;
                    if (!Double.IsNaN(paragraph.Margin.Left))
                        val += paragraph.Margin.Left;

                    styleAttributeValue += "margin-left: " + val.ToString();
                }
                if( !Double.IsNaN(paragraph.Margin.Top) )
                    if (paragraph.Margin.Top > 0 || paragraph.Margin.Top < 0)
                    {
                        if (styleAttributeValue != "")
                            styleAttributeValue += "; ";
                        styleAttributeValue += "margin-top: " + paragraph.Margin.Top.ToString();
                    }
                if (!Double.IsNaN(paragraph.Margin.Right))
                    if (paragraph.Margin.Right > 0 || paragraph.Margin.Right < 0)
                    {
                        if (styleAttributeValue != "")
                            styleAttributeValue += "; ";
                        styleAttributeValue += "margin-right: " + paragraph.Margin.Right.ToString();
                    }
                if (!Double.IsNaN(paragraph.Margin.Bottom))
                    if (paragraph.Margin.Bottom > 0 || paragraph.Margin.Bottom < 0)
                    {
                        if (styleAttributeValue != "")
                            styleAttributeValue += "; ";
                        styleAttributeValue += "margin-bottom: " + paragraph.Margin.Bottom.ToString();
                    }
                if (styleAttributeValue != "")
                {
                    htmlWriter.WriteAttributeString(styleAttribute, styleAttributeValue);
                }
            }

            // convert inlines
            AddInlines(paragraph.Inlines, htmlWriter, conversionResult);

            htmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Convert an flow document list into its html representation.
        /// </summary>
        /// <param name="list">Flow document list.</param>
        /// <param name="htmlWriter">XmlTextWriter producing resulting html.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        private static void AddList(List list, XmlTextWriter htmlWriter, ValidationResult conversionResult)
        {
            if (list.MarkerStyle == System.Windows.TextMarkerStyle.Disc)
                htmlWriter.WriteStartElement("ul");
            else if (list.MarkerStyle == System.Windows.TextMarkerStyle.Decimal)
                htmlWriter.WriteStartElement("ol");
            else
            {
                if (conversionResult != null)
                    conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Error, "Unknown list marker style: " + list.MarkerStyle.ToString()));
                return;
            }

            // process list items
            foreach (ListItem item in list.ListItems)
            {
                htmlWriter.WriteStartElement("li");

                // process blocks
                foreach (Block block in item.Blocks)
                    AddBlock(block, htmlWriter, conversionResult);

                htmlWriter.WriteEndElement();
            }

            htmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Convert an flow document table into its html representation.
        /// </summary>
        /// <param name="table">Flow document table.</param>
        /// <param name="htmlWriter">XmlTextWriter producing resulting html.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        private static void AddTable(Table table, XmlTextWriter htmlWriter, ValidationResult conversionResult)
        {
            htmlWriter.WriteStartElement("table");

            /*
            if (table.BorderThickness.Left == table.BorderThickness.Right &&
                table.BorderThickness.Right == table.BorderThickness.Top &&
                table.BorderThickness.Top == table.BorderThickness.Bottom)
            {
                if (table.BorderThickness.Left != 0)
                    htmlWriter.WriteAttributeString("border", table.BorderThickness.Left.ToString());
            }
            */

            double border = 0.0;
            foreach (TableRowGroup group in table.RowGroups)
            {
                foreach (TableRow row in group.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        if (cell.BorderThickness.Left == cell.BorderThickness.Right &&
                           cell.BorderThickness.Right == cell.BorderThickness.Top &&
                           cell.BorderThickness.Top == cell.BorderThickness.Bottom)
                        {
                            border = cell.BorderThickness.Left;
                            break;
                        }
                    }

                    if (border > 0)
                        break;
                }
                if (border > 0)
                    break;
            }

            if (border > 0)
                // set border attribute
                htmlWriter.WriteAttributeString("border", border.ToString());

            foreach (TableRowGroup group in table.RowGroups)
            {
                foreach (TableRow row in group.Rows)
                {
                    // add tr
                    htmlWriter.WriteStartElement("tr");

                    foreach (TableCell cell in row.Cells)
                    {
                        if (cell.BorderThickness.Left == cell.BorderThickness.Right &&
                            cell.BorderThickness.Right == cell.BorderThickness.Top &&
                            cell.BorderThickness.Top == cell.BorderThickness.Bottom)
                        {
                            if (cell.BorderThickness.Left != 0)
                                if (border != cell.BorderThickness.Left)
                                {
                                    // error
                                    if (conversionResult != null)
                                    {
                                        conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                                            "AddInline: All border values on table cells within one table need to be equal, ignoring newly found border value."));
                                    }
                                }
                        }

                        // add td
                        htmlWriter.WriteStartElement("td");

                        // process blocks
                        foreach (Block block in cell.Blocks)
                            AddBlock(block, htmlWriter, conversionResult);

                        htmlWriter.WriteEndElement();
                    }

                    htmlWriter.WriteEndElement();
                }
            }


            htmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Convert an flow document inlines into their (combined!) html representation.
        /// </summary>
        /// <param name="inlines">Flow document inlines collection.</param>
        /// <param name="htmlWriter">XmlTextWriter producing resulting html.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <remarks>
        /// Supported: Hyperlink, Bold, Underline, Italic as well as Run and InlineUIContainer for Image.
        /// </remarks>
        private static void AddInlines(InlineCollection inlines, XmlTextWriter htmlWriter, ValidationResult conversionResult)
        {
            List<InlineStyles> inheritedStyle = new List<InlineStyles>();

            AddInlines(inlines, htmlWriter, conversionResult, inheritedStyle);

            for (int i = 0; i < inheritedStyle.Count; ++i)
                htmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Convert an flow document inlines into their (combined!) html representation.
        /// </summary>
        /// <param name="inlines">Flow document inlines collection.</param>
        /// <param name="htmlWriter">XmlTextWriter producing resulting html.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="inheritedStyle">Inherited inline styles.</param>
        /// <remarks>
        /// Supported: Hyperlink, Bold, Underline, Italic as well as Run and InlineUIContainer for Image.
        /// </remarks>
        private static void AddInlines(InlineCollection inlines, XmlTextWriter htmlWriter, ValidationResult conversionResult, List<InlineStyles> inheritedStyle)
        {
            for (int i = 0; i < inlines.Count; ++i)
            {
                Inline inline = inlines.ElementAt(i);

                #region InheritedStyle + B,I,U processing
                bool bAddBold = false;
                bool bAddItalic = false;
                bool bAddUnderlined = false;

                // Bold
                if (inline.FontWeight != System.Windows.FontWeights.Bold && inheritedStyle.Contains(InlineStyles.Bold))
                {
                    // close last element tag
                    htmlWriter.WriteEndElement();
                    inheritedStyle.Remove(InlineStyles.Bold);
                }
                else if (!inheritedStyle.Contains(InlineStyles.Bold) && inline.FontWeight == System.Windows.FontWeights.Bold)
                    bAddBold = true;

                // Italic
                if (inline.FontStyle != System.Windows.FontStyles.Italic && inheritedStyle.Contains(InlineStyles.Italic))
                {
                    // close last element tag
                    htmlWriter.WriteEndElement();
                    inheritedStyle.Remove(InlineStyles.Italic);
                }
                else if (!inheritedStyle.Contains(InlineStyles.Italic) && inline.FontStyle == System.Windows.FontStyles.Italic)
                    bAddItalic = true;

                // Underline
                bool bHasUnderline = false;
                if (inline is Run && inline.Parent is Span)
                {
                    if ((inline.Parent as Span).TextDecorations.Contains(System.Windows.TextDecorations.Underline[0]))
                        bHasUnderline = true;
                }

                if (!inline.TextDecorations.Contains(System.Windows.TextDecorations.Underline[0]) && inheritedStyle.Contains(InlineStyles.Underlined))
                {
                    if (!bHasUnderline)
                    {
                        // close last element tag
                        htmlWriter.WriteEndElement();
                        inheritedStyle.Remove(InlineStyles.Underlined);
                    }
                }
                else if (!inheritedStyle.Contains(InlineStyles.Underlined) && inline.TextDecorations.Contains(System.Windows.TextDecorations.Underline[0]))
                    if (!bHasUnderline)
                        bAddUnderlined = true;

                if (inline is HtmlHyperlink)
                    bAddUnderlined = false;

                // see what needs to be added.. if multiple elements need to be added, than we have to iterate through
                // siblings to see what tag to set first (depending on what to close first).
                if (bAddUnderlined || bAddBold || bAddItalic)
                {
                    if (bAddBold && bAddItalic || bAddBold && bAddUnderlined || bAddItalic && bAddUnderlined)
                    {
                        InlineStylesCount stylesCount = InlineStylesCounter.Count(inlines, i + 1);

                        // see what has to be added first
                        // add tags
                        for (int z = 0; z < 3; ++z)
                        {
                            if (stylesCount.Order[z] == InlineStyles.Bold && bAddBold)
                            {
                                htmlWriter.WriteStartElement("b");
                                inheritedStyle.Add(InlineStyles.Bold);
                            }
                            else if (stylesCount.Order[z] == InlineStyles.Italic && bAddItalic)
                            {
                                htmlWriter.WriteStartElement("i");
                                inheritedStyle.Add(InlineStyles.Italic);
                            }
                            else if (stylesCount.Order[z] == InlineStyles.Underlined && bAddUnderlined)
                            {
                                htmlWriter.WriteStartElement("u");
                                inheritedStyle.Add(InlineStyles.Underlined);
                            }
                        }
                    }
                    else
                    {
                        // just add the tag of the needed style
                        if (bAddBold)
                        {
                            htmlWriter.WriteStartElement("b");
                            inheritedStyle.Add(InlineStyles.Bold);
                        }
                        else if (bAddItalic)
                        {
                            htmlWriter.WriteStartElement("i");
                            inheritedStyle.Add(InlineStyles.Italic);
                        }
                        else if (bAddUnderlined)
                        {
                            htmlWriter.WriteStartElement("u");
                            inheritedStyle.Add(InlineStyles.Underlined);
                        }
                    }
                }
                #endregion

                // continue with text or inlines
                if (inline is InlineUIContainer)
                {
                    InlineUIContainer container = inline as InlineUIContainer;
                    if (container.Child is HtmlImage)
                    {
                        // Add image
                        AddImage(container.Child as HtmlImage, htmlWriter, conversionResult);
                    }
                    else if (container.Child is System.Windows.Controls.TextBlock)
                    {
                        // Comment, just add text as is
                        string text = ExtendedHtmlUtility.HtmlEntityEncode((container.Child as System.Windows.Controls.TextBlock).Text);
                        htmlWriter.WriteRaw(text);
                    }
                    else
                    {
                        // not supported
                        if (conversionResult != null)
                        {
                            if (container.Child != null)
                                conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                                    "AddInline: Unknown inline ui container child: " + container.Child.ToString()));
                            //else
                            //    conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                            //        "AddInline: Inline ui container child is null: " + container.ToString()));
                        }
                    }
                }
                else if (inline is HtmlHyperlink)
                {
                    // Add hyperlink
                    AddHyperlink(inline as HtmlHyperlink, htmlWriter, conversionResult, inheritedStyle);
                }
                else if (inline is Span)
                {
                    Span span = inline as Span;
                    AddInlines(span.Inlines, htmlWriter, conversionResult, inheritedStyle);
                }
                else if (inline is Run)
                {
                    string text = ExtendedHtmlUtility.HtmlEntityEncode((inline as Run).Text);
                    //string text = HtmlEncode((inline as Run).Text); ;
                    htmlWriter.WriteRaw(text);
                }
                else
                {
                    // not supported
                    if (conversionResult != null)
                    {
                        conversionResult.AddMessage(new ConversionMessage(ModelValidationViolationType.Warning,
                            "AddInline: Unknown inline element: " + inline.ToString()));
                    }

                }
            }
        }

        /*
        /// <summary>
        /// Convert an flow document inlines into their (combined!) html representation.
        /// </summary>
        /// <param name="inlines">Flow document inlines collection.</param>
        /// <param name="htmlWriter">XmlTextWriter producing resulting html.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <remarks>
        /// Supported: Hyperlink, Bold, Underline, Italic as well as Run and InlineUIContainer for Image.
        /// </remarks>
        private static void AddInlines(InlineCollection inlines, XmlTextWriter htmlWriter, ConversionResult conversionResult)
        {
            bool bBold = false;
            bool bItalic = false;
            bool bUnderlined = false;

            for (int i = 0; i < inlines.Count; ++i)
            {
                Inline inline = inlines.ElementAt(i);
                if (inline is Run || inline is Span)
                {
                    bool bAddBold = false;
                    bool bAddItalic = false;
                    bool bAddUnderlined = false;

                    // Bold
                    if (bBold && inline.FontWeight != System.Windows.FontWeights.Bold)
                    {
                        // close last element tag
                        htmlWriter.WriteEndElement();
                        bBold = false;
                    }
                    else if (!bBold && inline.FontWeight == System.Windows.FontWeights.Bold)
                        bAddBold = true;

                    // Italic
                    if (bItalic && inline.FontStyle != System.Windows.FontStyles.Italic)
                    {
                        // close last element tag
                        htmlWriter.WriteEndElement();
                        bItalic = false;
                    }
                    else if (!bItalic && inline.FontStyle == System.Windows.FontStyles.Italic)
                        bAddItalic = true;

                    // Underline
                    if (bUnderlined && !inline.TextDecorations.Contains(System.Windows.TextDecorations.Underline[0]))
                    {
                        // close last element tag
                        htmlWriter.WriteEndElement();
                        bUnderlined = false;
                    }
                    else if (!bUnderlined && inline.TextDecorations.Contains(System.Windows.TextDecorations.Underline[0]))
                        bAddUnderlined = true;

                    // see what needs to be added.. if multiple elements need to be added, than we have to iterate through
                    // siblings to see what tag to set first (depending on what to close first).
                    if( bAddUnderlined || bAddBold || bAddItalic )
                    {
                        if (bAddBold && bAddItalic || bAddBold && bAddUnderlined || bAddItalic && bAddUnderlined)
                        {
                            // see what has to be added first
                            int iBold = 0;
                            int iItalic = 0;
                            int iUnderlined = 0;

                            for (int y = i+1; y < inlines.Count; ++y)
                            {
                                Inline inlineY = inlines.ElementAt(y);
                                if (inlineY.FontStyle == System.Windows.FontStyles.Italic)
                                    iItalic++;
                                if (inlineY.FontWeight == System.Windows.FontWeights.Bold)
                                    iBold++;
                                if (inlineY.TextDecorations.Contains(System.Windows.TextDecorations.Underline[0]))
                                    iUnderlined++;
                            }

                            List<InlineStyles> addOrder = new List<InlineStyles>();
                            addOrder.Add(InlineStyles.Bold);
                            if (iItalic > iBold)
                                addOrder.Insert(0, InlineStyles.Italic);
                            else
                                addOrder.Add(InlineStyles.Italic);

                            for (int z = 0; z < 2; ++z)
                            {
                                if (addOrder[z] == InlineStyles.Bold && iUnderlined > iBold)
                                {
                                    addOrder.Insert(z, InlineStyles.Underlined);
                                    break;
                                }
                                else if (addOrder[z] == InlineStyles.Italic && iUnderlined > iItalic)
                                {
                                    addOrder.Insert(z, InlineStyles.Underlined);
                                    break;
                                }
                                else if (z == 1)
                                    addOrder.Add(InlineStyles.Underlined);
                            }

                            // add tags
                            for (int z = 0; z < 3; ++z)
                            {
                                if (addOrder[z] == InlineStyles.Bold && bAddBold)
                                {
                                    htmlWriter.WriteStartElement("b");
                                    bBold = true;
                                }
                                else if (addOrder[z] == InlineStyles.Italic && bAddItalic)
                                {
                                    htmlWriter.WriteStartElement("i");
                                    bItalic = true;
                                }
                                else if (addOrder[z] == InlineStyles.Underlined && bAddUnderlined)
                                {
                                    htmlWriter.WriteStartElement("u");
                                    bUnderlined = true;
                                }
                            }
                        }
                        else
                        {
                            // just add the tag of the needed style
                            if (bAddBold)
                            {
                                htmlWriter.WriteStartElement("b");
                                bBold = true;
                            }
                            else if (bAddItalic)
                            {
                                htmlWriter.WriteStartElement("i");
                                bItalic = true;
                            }
                            else if (bAddUnderlined)
                            {
                                htmlWriter.WriteStartElement("u");
                                bUnderlined = true;
                            }
                        }
                    }

                    // continue with text or inlines
                    if (inline is Run)
                    {
                        htmlWriter.WriteString((inline as Run).Text);
                    }
                    else
                    {
                        Span span = inline as Span;
                        AddInlines(span.Inlines, htmlWriter, conversionResult);
                    }
                }
                else if (inline is InlineUIContainer)
                {
                    InlineUIContainer container = inline as InlineUIContainer;
                    if (container.Child is HtmlImage)
                    {
                        // Add image
                        // TODO...
                    }
                    else
                    {
                        // not supported
                        if (conversionResult != null)
                        {
                            conversionResult.AddMessage(new ConversionMessage(ConversionMessageKind.Warning,
                                "AddInline: Unknown inline ui container child: " + container.Child.ToString()));
                        }
                    }
                }
                else if (inline is HtmlHyperlink)
                {
                    // Add hyperlink
                    AddHyperlink(inline as HtmlHyperlink, htmlWriter, conversionResult);
                }
                else
                {
                    // not supported
                    if (conversionResult != null)
                    {
                        conversionResult.AddMessage(new ConversionMessage(ConversionMessageKind.Warning,
                            "AddInline: Unknown inline element: " + inline.ToString()));
                    }

                }
            }

            if (bBold)
                htmlWriter.WriteEndElement();

            if (bItalic)
                htmlWriter.WriteEndElement();

            if (bUnderlined)
                htmlWriter.WriteEndElement();
        }

        */

        /// <summary>
        /// Convert an flow document hyperlink into its html representation.
        /// </summary>
        /// <param name="hyperlink">Flow document hyperlink.</param>
        /// <param name="htmlWriter">XmlTextWriter producing resulting html.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        /// <param name="inheritedStyle">Inherited inline styles.</param>
        private static void AddHyperlink(HtmlHyperlink hyperlink, XmlTextWriter htmlWriter, ValidationResult conversionResult, List<InlineStyles> inheritedStyle)
        {
            htmlWriter.WriteStartElement("a");

            //if (Tum.VModellXT.Keys.KeyGenerator.Instance.CanConvertVModellIDToGuid(hyperlink.TargetName))
            //{
            //   htmlWriter.WriteAttributeString("href", "#" + hyperlink.TargetName);
            // }
            //else
            htmlWriter.WriteAttributeString("href", hyperlink.TargetName);

            // process inlines
            AddInlines(hyperlink.Inlines, htmlWriter, conversionResult, inheritedStyle);

            htmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Convert an image into its html representation.
        /// </summary>
        /// <param name="image">Image.</param>
        /// <param name="htmlWriter">XmlTextWriter producing resulting html.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages. Can be null.</param>
        private static void AddImage(HtmlImage image, XmlTextWriter htmlWriter, ValidationResult conversionResult)
        {
            htmlWriter.WriteStartElement("img");
            htmlWriter.WriteAttributeString("src", image.RelativeSource);

            if (!String.IsNullOrEmpty(image.AlternativeText))
                htmlWriter.WriteAttributeString("alt", image.AlternativeText);

            if (!String.IsNullOrEmpty(image.Id))
                htmlWriter.WriteAttributeString("id", image.Id);

            if (image.ExportHeight != null)
                htmlWriter.WriteAttributeString("height", image.ExportHeight.Value.ToString());
            if (image.ExportWidth != null)
                htmlWriter.WriteAttributeString("width", image.ExportWidth.Value.ToString());

            htmlWriter.WriteEndElement();
        }

        private class InlineStylesCounter
        {
            public static InlineStylesCount Count(InlineCollection collection, int startIndex)
            {
                InlineStylesCount stylesCount = new InlineStylesCount();
                stylesCount.BoldCount = 0;
                stylesCount.ItalicCount = 0;
                stylesCount.UnderlinedCount = 0;
                stylesCount.BoldCountingFinished = false;
                stylesCount.UnderlinedCountingFinished = false;
                stylesCount.ItalicCountingFinished = false;
                stylesCount.Order = new List<InlineStyles>();

                Count(collection, startIndex, stylesCount);

                // build order
                stylesCount.Order.Add(InlineStyles.Bold);
                if (stylesCount.ItalicCount > stylesCount.BoldCount)
                    stylesCount.Order.Insert(0, InlineStyles.Italic);
                else
                    stylesCount.Order.Add(InlineStyles.Italic);

                for (int z = 0; z < 2; ++z)
                {
                    if (stylesCount.Order[z] == InlineStyles.Bold && stylesCount.UnderlinedCount > stylesCount.BoldCount)
                    {
                        stylesCount.Order.Insert(z, InlineStyles.Underlined);
                        break;
                    }
                    else if (stylesCount.Order[z] == InlineStyles.Italic && stylesCount.UnderlinedCount > stylesCount.ItalicCount)
                    {
                        stylesCount.Order.Insert(z, InlineStyles.Underlined);
                        break;
                    }
                    else if (z == 1)
                        stylesCount.Order.Add(InlineStyles.Underlined);
                }

                // remove unneeded elements
                /*
                if (stylesCount.BoldCount == 0)
                    stylesCount.Order.Remove(InlineStyles.Bold);
                if (stylesCount.ItalicCount == 0)
                    stylesCount.Order.Remove(InlineStyles.Italic);
                if (stylesCount.UnderlinedCount == 0)
                    stylesCount.Order.Remove(InlineStyles.Underlined);
                */

                return stylesCount;
            }

            private static void Count(InlineCollection inlines, int startIndex, InlineStylesCount stylesCount)
            {
                for (int y = startIndex + 1; y < inlines.Count; ++y)
                {
                    Inline inlineY = inlines.ElementAt(y);
                    if (inlineY.FontStyle == System.Windows.FontStyles.Italic)
                        stylesCount.ItalicCount++;
                    else
                        stylesCount.ItalicCountingFinished = true;

                    if (inlineY.FontWeight == System.Windows.FontWeights.Bold)
                        stylesCount.BoldCount++;
                    else
                        stylesCount.BoldCountingFinished = true;

                    if (inlineY.TextDecorations.Contains(System.Windows.TextDecorations.Underline[0]))
                        stylesCount.UnderlinedCount++;
                    else
                        stylesCount.UnderlinedCountingFinished = true;

                    // continue with children
                    if (inlineY is Span)
                    {
                        if (!stylesCount.BoldCountingFinished || !stylesCount.UnderlinedCountingFinished || !stylesCount.ItalicCountingFinished)
                        {
                            Count((inlineY as Span).Inlines, 0, stylesCount);
                        }
                    }

                    if (stylesCount.BoldCountingFinished && stylesCount.UnderlinedCountingFinished && stylesCount.ItalicCountingFinished)
                        break;
                }
            }
        }

        private struct InlineStylesCount
        {
            public int BoldCount;
            public int ItalicCount;
            public int UnderlinedCount;

            public List<InlineStyles> Order;

            public bool BoldCountingFinished;
            public bool ItalicCountingFinished;
            public bool UnderlinedCountingFinished;
        }
        private enum InlineStyles
        {
            Bold,
            Italic,
            Underlined
        }
    }
}
