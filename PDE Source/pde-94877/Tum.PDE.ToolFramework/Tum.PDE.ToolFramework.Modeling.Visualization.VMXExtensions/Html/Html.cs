using System;
using System.Windows.Documents;

using HtmlAgilityPack; // http://www.codeplex.com/htmlagilitypack

using Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Converter;
using Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.View;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html
{
    /// <summary>
    /// This class is used to represent html in the domain model. The html type consists of:
    /// - HtmlData: this is the rough html.
    /// - HtmlDocument: this is the parsed html document (HtmlAgilityPack).
    /// - FlowDocumentData: this is the parsed flow document as string (corresponds to the HtmlData). 
    /// - FlowDocument: this is the actual flow document. It is build using FlowDocumentData.
    /// 
    /// Apart from that, an opportunity to track warnings and errors is also given through the
    /// HtmlConversionResult property, which contains warnings, errors or just information messages
    /// gathered while converting. (The result is reset each time a conversion takes place.)
    /// 
    /// Conversions are available from html data to flow document and vice versa.
    /// Warning: Only a partial subset of both html data and flow document elements are supported.
    /// </summary>
    /// <remarks>
    /// This class is designed for the interpretation of a subset of html as needed by the VModell. 
    /// (Refer to HtmlToXamlConverter and XamlToHtmlConverter for more information).
    /// </remarks>
    [System.Serializable]
    public class Html : Tum.PDE.ToolFramework.Modeling.IValidatable, System.Runtime.Serialization.ISerializable
    {
        private string htmlData;
        private string flowDocumentData;
        private string vModellDirectory;
        private HtmlDocument htmlDocument;
        private Tum.PDE.ToolFramework.Modeling.ValidationResult htmlConversionResult;
        private bool isParsed = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Html as string.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        public Html(string data, string vModellDirectory)
        {
            this.htmlData = data;
            this.vModellDirectory = vModellDirectory;

            //ParseHtml();

            //DEBUG: 
            //ParseFlowDocument(this.FlowDocument, htmlConversionResult);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Flowdocument which is to be converted to html.</param>
        /// <param name="vModellDirectory">Directory of the VModell instance containing the element that has a html property.</param>
        public Html(FlowDocument data, string vModellDirectory)
        {
            this.htmlConversionResult = new Tum.PDE.ToolFramework.Modeling.ValidationResult();
            this.vModellDirectory = vModellDirectory;

            ParseFlowDocument(data, htmlConversionResult);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">The SerializationInfo to get the data from.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        protected Html(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            htmlData = (string)info.GetValue("htmlData", typeof(string));
            flowDocumentData = (string)info.GetValue("flowDocumentData", typeof(string));
            vModellDirectory = (string)info.GetValue("vModellDirectory", typeof(string));
        }

        /// <summary>
        /// Populates a System.Runtime.Serialization.SerializationInfo with the data
        /// needed to serialize the target object.
        /// </summary>
        /// <param name="info">The SerializationInfo to populate with data.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("htmlData", htmlData, typeof(string));
            info.AddValue("flowDocumentData", flowDocumentData, typeof(string));
            info.AddValue("vModellDirectory", vModellDirectory, typeof(string));
        }

        /*
        /// <summary>
        /// Create a new html instance.
        /// </summary>
        /// <param name="data">Html as a string.</param>
        /// <returns>Html instance.</returns>
        public static implicit operator Html(string data)
        {
            return new Html(data);
        }

        /// <summary>
        /// Create a new html instance.
        /// </summary>
        /// <param name="data">Flowdocument which is to be converted to html.</param>
        /// <returns>Html instance.</returns>
        public static implicit operator Html(FlowDocument data)
        {
            return new Html(data);
        }
        */

        /// <summary>
        /// Converts html to string.
        /// </summary>
        /// <param name="data">Html object.</param>
        /// <returns>Html as string.</returns>
        public static explicit operator string(Html data)
        {
            return data.HtmlData;
        }

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current Html instance.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current Html instance.</param>
        /// <returns>true if the specified System.Object is equal to the current Html instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Html return false.
            Html p = obj as Html;
            if (p == null)
                return false;

            // Return true if the html data match:
            return (HtmlData == p.HtmlData);
        }

        /// <summary>
        /// == operator.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Html a, Html b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.HtmlData == b.HtmlData;
        }

        /// <summary>
        /// != operator.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Html a, Html b)
        {
            return !(a == b);
        }

        /// <summary>
        ///  Returns a System.String that represents the html data.
        /// </summary>
        public override string ToString()
        {
            return htmlData;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current Html instance.</returns>
        public override int GetHashCode()
        {
            return this.htmlData.GetHashCode();
        }

        /// <summary>
        /// Gets the directory of the VModell instance containing the element that has this html property.
        /// </summary>
        public string VModellDirectory
        {
            get { return this.vModellDirectory; }
        }

        /// <summary>
        /// Gets or sets html data.
        /// </summary>
        public string HtmlData
        {
            get
            {
                if (this.htmlData == null)
                    return "";
                else
                    return htmlData;
            }
            set
            {
                this.htmlData = value;
                ParseHtml();
            }
        }

        /// <summary>
        /// Gets the flow document data string representing the actual html data.
        /// </summary>
        public string FlowDocumentData
        {
            get { return flowDocumentData; }
        }

        /// <summary>
        /// Gets the converted flow document correspoding to html data.
        /// </summary>
        public FlowDocument FlowDocument
        {
            get
            {
                if (!isParsed)
                    ParseHtml();

                try
                {
                    if (FlowDocumentData.Trim() == string.Empty)
                        return new HtmlFlowDocument();

                    HtmlFlowDocument doc = System.Windows.Markup.XamlReader.Parse(FlowDocumentData) as HtmlFlowDocument;
                    return doc;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Conversion to flow document failed: " + ex.Message);
                    return new HtmlFlowDocument();
                }
            }
        }

        /// <summary>
        /// Gets the parsed html representaton.
        /// </summary>
        public HtmlDocument HtmlDocument
        {
            get 
            {
                if (!isParsed)
                    ParseHtml();

                return this.htmlDocument; 
            }
        }

        /// <summary>
        /// Parses the current html data by creating the corresponding HtmlDocument as well as its FlowDocument representation.
        /// </summary>
        /// <remarks>The created FlowDument is stored as a string for later use.</remarks>
        private void ParseHtml()
        {
            this.htmlConversionResult = new Tum.PDE.ToolFramework.Modeling.ValidationResult();
            ParseHtml(this.htmlConversionResult);
        }

        /// <summary>
        /// Parses the current html data by creating the corresponding HtmlDocument as well as its FlowDocument representation.
        /// </summary>
        /// <param name="conversionResult">Conversion result to store error and warning messages.</param>
        /// <remarks>The created FlowDument is stored as a string for later use.</remarks>
        private void ParseHtml(Tum.PDE.ToolFramework.Modeling.ValidationResult conversionResult)
        {
            this.isParsed = true;

            if (String.IsNullOrEmpty(this.htmlData))
            {
                this.htmlDocument = new HtmlDocument();
                this.flowDocumentData = string.Empty;
                return;
            }

            this.htmlDocument = ConvertToHtmlDocument(this.htmlData);
            this.flowDocumentData = ConvertToFlowDocument(this.HtmlDocument, conversionResult, this.VModellDirectory);
        }

        /// <summary>
        /// Parses the given flow document by creating the corresponding html data as well as the html document.
        /// </summary>
        /// <param name="document">Flow document to parse</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages.</param>
        private void ParseFlowDocument(FlowDocument document, Tum.PDE.ToolFramework.Modeling.ValidationResult conversionResult)
        {
            if (document == null)
                return;

            string html = XamlToHtmlConverter.ConvertXamlToHtml(document, conversionResult);
            this.htmlData = html;
            ParseHtml(conversionResult);
        }

        /// <summary>
        /// Converts the given html document to its flow document representation.
        /// </summary>
        /// <param name="htmlDocument">Html document to convert.</param>
        /// <param name="conversionResult">Conversion result to store error and warning messages.</param>
        /// <param name="vModellDirectory">Directory of the v-modell.</param>
        /// <returns>Flow document representing the given html document.</returns>
        public static string ConvertToFlowDocument(HtmlDocument htmlDocument, Tum.PDE.ToolFramework.Modeling.ValidationResult conversionResult, string vModellDirectory)
        {
            string flowDocument = HtmlToXamlConverter.ConvertHtmlToXaml(htmlDocument, conversionResult, vModellDirectory);
            return flowDocument;
        }

        /// <summary>
        /// Converts the given html data to the corresponding html document.
        /// </summary>
        /// <param name="htmlData">Html data as string.</param>
        /// <returns>Html document representing the given html data.</returns>
        public static HtmlDocument ConvertToHtmlDocument(string htmlData)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlData);

            return htmlDocument;
        }

        /// <summary>
        /// Error/Warning messages added during conversion of html to xaml.
        /// </summary>
        public Tum.PDE.ToolFramework.Modeling.IValidationResult ValidationResult
        {
            get { return htmlConversionResult; }
        }

        /// <summary>
        /// Method to start validation.
        /// </summary>
        public void Validate()
        {
            // TODO
        }

    }
}
