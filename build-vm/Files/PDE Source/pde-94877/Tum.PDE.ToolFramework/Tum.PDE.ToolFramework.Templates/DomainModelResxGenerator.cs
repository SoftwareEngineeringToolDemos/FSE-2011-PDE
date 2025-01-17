﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 10.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Tum.PDE.ToolFramework.Templates
{
    using Tum.PDE.LanguageDSL;
    using Microsoft.VisualStudio.Modeling;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Globalization;
    using System.Linq;
    using System;
    
    
    #line 1 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class DomainModelResxGenerator : BaseTemplate
    {
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
        public override string TransformText()
        {
            this.GenerationEnvironment = null;
            
            #line 11 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"

  GenerateDomainModelResx(this.MetaModel);

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 14 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"

public void GenerateDomainModelResx(MetaModel dm)
{
	Dictionary<string, KeyValuePair<string, string>> resourcedStrings = new Dictionary<string, KeyValuePair<string, string>>();
	Dictionary<string, KeyValuePair<string, string>> resourcedFileObjects = new Dictionary<string, KeyValuePair<string, string>>();

	string commentString = "{0} for {1} '{2}'";
	string propertyCommentString = "{0} for {1} '{2}' on {3} '{4}'";
	string domainModelNamespace = String.IsNullOrEmpty(this.MetaModel.Namespace) ? "" : (this.MetaModel.Namespace)+".";
	
	// Don't generate any resources if there is no resource name.
		
	if(!String.IsNullOrEmpty(this.MetaModel.GeneratedResourceName))
	{
		resourcedStrings.Add(domainModelNamespace+this.MetaModel.Name+"DomainModel.Description", new KeyValuePair<string, string>(this.MetaModel.Description, String.Format(CultureInfo.CurrentCulture, commentString, "Description", "DslLibrary", this.MetaModel.Name)));
		resourcedStrings.Add(domainModelNamespace+this.MetaModel.Name+"DomainModel.DisplayName", new KeyValuePair<string, string>(this.MetaModel.DisplayName, String.Format(CultureInfo.CurrentCulture, commentString, "DisplayName", "DslLibrary", this.MetaModel.Name)));
	
		foreach(DomainClass c in this.MetaModel.AllClasses)
		{
			AddDomainClassResources(c, resourcedStrings, commentString, propertyCommentString);
		}
	
		
		foreach(DomainRelationship r in this.MetaModel.AllRelationships)
		{
			AddDomainClassResources(r, resourcedStrings, commentString, propertyCommentString);
			string fullName = r.GetFullName(false);
			
			DomainRole role = r.Source;
			resourcedStrings.Add(fullName+"/"+role.Name+".Description", new KeyValuePair<string, string>(role.Description, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "Description", "DomainRole", role.Name, "DomainRelationship", r.Name)));
			resourcedStrings.Add(fullName+"/"+role.Name+".DisplayName", new KeyValuePair<string, string>(role.DisplayName, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "DisplayName", "DomainRole", role.Name, "DomainRelationship", r.Name)));
			if(!String.IsNullOrEmpty(role.Category))
			{
				resourcedStrings.Add(fullName+"/"+role.Name+".Category", new KeyValuePair<string, string>(role.Category, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "Category", "DomainRole", role.Name, "DomainRelationship", r.Name)));
			}
			if(!String.IsNullOrEmpty(role.PropertyDisplayName))
			{
				resourcedStrings.Add(fullName+"/"+role.Name+".PropertyDisplayName", new KeyValuePair<string, string>(role.PropertyDisplayName, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "PropertyDisplayName", "DomainRole", role.Name, "DomainRelationship", r.Name)));
			}
			
			role = r.Target;
			resourcedStrings.Add(fullName+"/"+role.Name+".Description", new KeyValuePair<string, string>(role.Description, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "Description", "DomainRole", role.Name, "DomainRelationship", r.Name)));
			resourcedStrings.Add(fullName+"/"+role.Name+".DisplayName", new KeyValuePair<string, string>(role.DisplayName, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "DisplayName", "DomainRole", role.Name, "DomainRelationship", r.Name)));
			if(!String.IsNullOrEmpty(role.Category))
			{
				resourcedStrings.Add(fullName+"/"+role.Name+".Category", new KeyValuePair<string, string>(role.Category, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "Category", "DomainRole", role.Name, "DomainRelationship", r.Name)));
			}
			if(!String.IsNullOrEmpty(role.PropertyDisplayName))
			{
				resourcedStrings.Add(fullName+"/"+role.Name+".PropertyDisplayName", new KeyValuePair<string, string>(role.PropertyDisplayName, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "PropertyDisplayName", "DomainRole", role.Name, "DomainRelationship", r.Name)));
			}
		}
		
		foreach(DomainType t in this.MetaModel.DomainTypes)
		{
			if(t is DomainEnumeration)
			{
				string fullName = t.GetFullName(false);
				foreach(EnumerationLiteral literal in ((DomainEnumeration)t).Literals)
				{
					// Add an entry for localizable field names
					resourcedStrings.Add(fullName+"/"+literal.Name+".DisplayName", new KeyValuePair<string, string>(literal.DisplayName, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "Display name", "EnumerationLiteral", literal.Name, "DomainEnumeration", t.Name)));					
					resourcedStrings.Add(fullName+"/"+literal.Name+".Description", new KeyValuePair<string, string>(literal.Description, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "Description", "EnumerationLiteral", literal.Name, "DomainEnumeration", t.Name)));
				}
			}
		}
	}
	
	// Incorrect ElementType passed in to CreateElement API
	resourcedStrings.Add("UnrecognizedElementType", new KeyValuePair<string, string>( "ElementType {0} is not recognized as a type of domain class which belongs to this domain model.", "Incorrect ElementType passed in to Model.CreateElement method"));
	
	// Incorrect ElementLinkType passed in to CreateElementLink API
	resourcedStrings.Add("UnrecognizedElementLinkType", new KeyValuePair<string, string>( "ElementLinkType {0} is not recognized as a type of domain relationship which belongs to this domain model.", "Incorrect ElementLinkType passed in to Model.CreateElementLink method"));
	
	
	// Add default resource strings for serialization.
	CodeGenerationUtilities.AddSerializationResourceStrings(resourcedStrings);
	
	// Cannot open file due to user rejects closing diagram file
	resourcedStrings.Add("CannotCloseExistingDiagramDocument", new KeyValuePair<string, string>( "Diagram file '{0}' cannot be closed.", "User cancel closing diagram file. Hence, the DSL model file cannot be opened"));

	// MEF binding error
	resourcedStrings.Add("BindingErrorOccurred", new KeyValuePair<string, string>( "Extensions for this designer may not be found as a MEF binding error has occurred. The error that occurred was:\n{0}", "MEF binding error occurred - exception message being logged in the error window so the user is aware."));

	// IDomainModelSerializer argument errors
	resourcedStrings.Add("InvalidSaveRootElementType", new KeyValuePair<string, string>( "'{0}' is not a valid root element type.", "Exception message used if an invalid root element type is passed to IDomainModelSerializer.SaveModel / SaveModelAndDiagram"));

	resourcedStrings.Add("InvalidSaveDiagramType", new KeyValuePair<string, string>( "'{0}' is not a valid diagram type.", "Exception message used if an invalid diagram type is passed to IDomainModelSerializer.SaveModelAndDiagram"));


	// Add resource strings for validation.

			resourcedStrings.Add(
				"MinimumMultiplicityMissingLink",
				new KeyValuePair<string, string>(
					"{0} {1} has no {2}.",
					"Multiplicity underflow validation."
				)
			);
			resourcedStrings.Add(
				"SaveOperationCancelled",
				new KeyValuePair<string, string>(
					"Save operation cancelled.",
					"Message when save is cancelled on validation errors"
				)
			);
			resourcedStrings.Add(
				"SaveValidationFailed",
				new KeyValuePair<string, string>(
					"There were validation errors, continue save?",
					"Message when validation errors are found on save"
				)
			);
			resourcedStrings.Add(
				"UnloadableSaveValidationFailed",
				new KeyValuePair<string, string>(
					"There were validation errors. Continuing to save may cause the file to become unloadable, do you want to continue?",
					"Message when validation errors are found on save that will cause file to become unloadable"
				)
			);	

        
        #line default
        #line hidden
        
        #line 134 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<root>\r\n  <!-- \r\n    Microsoft ResX Schem" +
        "a \r\n    \r\n    Version 2.0\r\n    \r\n    The primary goals of this format is to allo" +
        "w a simple XML format \r\n    that is mostly human readable. The generation and pa" +
        "rsing of the \r\n    various data types are done through the TypeConverter classes" +
        " \r\n    associated with the data types.\r\n    \r\n    Example:\r\n    \r\n    ... ado.ne" +
        "t/XML headers & schema ...\r\n    <resheader name=\"resmimetype\">text/microsoft-res" +
        "x</resheader>\r\n    <resheader name=\"version\">2.0</resheader>\r\n    <resheader nam" +
        "e=\"reader\">System.Resources.ResXResourceReader, System.Windows.Forms, ...</reshe" +
        "ader>\r\n    <resheader name=\"writer\">System.Resources.ResXResourceWriter, System." +
        "Windows.Forms, ...</resheader>\r\n    <data name=\"Name1\"><value>this is my long st" +
        "ring</value><comment>this is a comment</comment></data>\r\n    <data name=\"Color1\"" +
        " type=\"System.Drawing.Color, System.Drawing\">Blue</data>\r\n    <data name=\"Bitmap" +
        "1\" mimetype=\"application/x-microsoft.net.object.binary.base64\">\r\n        <value>" +
        "[base64 mime encoded serialized .NET Framework object]</value>\r\n    </data>\r\n   " +
        " <data name=\"Icon1\" type=\"System.Drawing.Icon, System.Drawing\" mimetype=\"applica" +
        "tion/x-microsoft.net.object.bytearray.base64\">\r\n        <value>[base64 mime enco" +
        "ded string representing a byte array form of the .NET Framework object]</value>\r" +
        "\n        <comment>This is a comment</comment>\r\n    </data>\r\n                \r\n  " +
        "  There are any number of \"resheader\" rows that contain simple \r\n    name/value " +
        "pairs.\r\n    \r\n    Each data row contains a name, and value. The row also contain" +
        "s a \r\n    type or mimetype. Type corresponds to a .NET class that support \r\n    " +
        "text/value conversion through the TypeConverter architecture. \r\n    Classes that" +
        " don\'t support this are serialized and stored with the \r\n    mimetype set.\r\n    " +
        "\r\n    The mimetype is used for serialized objects, and tells the \r\n    ResXResou" +
        "rceReader how to depersist the object. This is currently not \r\n    extensible. F" +
        "or a given mimetype the value must be set accordingly:\r\n    \r\n    Note - applica" +
        "tion/x-microsoft.net.object.binary.base64 is the format \r\n    that the ResXResou" +
        "rceWriter will generate, however the reader can \r\n    read any of the formats li" +
        "sted below.\r\n    \r\n    mimetype: application/x-microsoft.net.object.binary.base6" +
        "4\r\n    value   : The object must be serialized with \r\n            : System.Runti" +
        "me.Serialization.Formatters.Binary.BinaryFormatter\r\n            : and then encod" +
        "ed with base64 encoding.\r\n    \r\n    mimetype: application/x-microsoft.net.object" +
        ".soap.base64\r\n    value   : The object must be serialized with \r\n            : S" +
        "ystem.Runtime.Serialization.Formatters.Soap.SoapFormatter\r\n            : and the" +
        "n encoded with base64 encoding.\r\n\r\n    mimetype: application/x-microsoft.net.obj" +
        "ect.bytearray.base64\r\n    value   : The object must be serialized into a byte ar" +
        "ray \r\n            : using a System.ComponentModel.TypeConverter\r\n            : a" +
        "nd then encoded with base64 encoding.\r\n    -->\r\n  <xsd:schema id=\"root\" xmlns=\"\"" +
        " xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsof" +
        "t-com:xml-msdata\">\r\n    <xsd:import namespace=\"http://www.w3.org/XML/1998/namesp" +
        "ace\" />\r\n    <xsd:element name=\"root\" msdata:IsDataSet=\"true\">\r\n      <xsd:compl" +
        "exType>\r\n        <xsd:choice maxOccurs=\"unbounded\">\r\n          <xsd:element name" +
        "=\"metadata\">\r\n            <xsd:complexType>\r\n              <xsd:sequence>\r\n     " +
        "           <xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" />\r\n       " +
        "       </xsd:sequence>\r\n              <xsd:attribute name=\"name\" use=\"required\" " +
        "type=\"xsd:string\" />\r\n              <xsd:attribute name=\"type\" type=\"xsd:string\"" +
        " />\r\n              <xsd:attribute name=\"mimetype\" type=\"xsd:string\" />\r\n        " +
        "      <xsd:attribute ref=\"xml:space\" />\r\n            </xsd:complexType>\r\n       " +
        "   </xsd:element>\r\n          <xsd:element name=\"assembly\">\r\n            <xsd:com" +
        "plexType>\r\n              <xsd:attribute name=\"alias\" type=\"xsd:string\" />\r\n     " +
        "         <xsd:attribute name=\"name\" type=\"xsd:string\" />\r\n            </xsd:comp" +
        "lexType>\r\n          </xsd:element>\r\n          <xsd:element name=\"data\">\r\n       " +
        "     <xsd:complexType>\r\n              <xsd:sequence>\r\n                <xsd:eleme" +
        "nt name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />\r\n         " +
        "       <xsd:element name=\"comment\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordina" +
        "l=\"2\" />\r\n              </xsd:sequence>\r\n              <xsd:attribute name=\"name" +
        "\" type=\"xsd:string\" use=\"required\" msdata:Ordinal=\"1\" />\r\n              <xsd:att" +
        "ribute name=\"type\" type=\"xsd:string\" msdata:Ordinal=\"3\" />\r\n              <xsd:a" +
        "ttribute name=\"mimetype\" type=\"xsd:string\" msdata:Ordinal=\"4\" />\r\n              " +
        "<xsd:attribute ref=\"xml:space\" />\r\n            </xsd:complexType>\r\n          </x" +
        "sd:element>\r\n          <xsd:element name=\"resheader\">\r\n            <xsd:complexT" +
        "ype>\r\n              <xsd:sequence>\r\n                <xsd:element name=\"value\" ty" +
        "pe=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />\r\n              </xsd:sequenc" +
        "e>\r\n              <xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" />" +
        "\r\n            </xsd:complexType>\r\n          </xsd:element>\r\n        </xsd:choice" +
        ">\r\n      </xsd:complexType>\r\n    </xsd:element>\r\n  </xsd:schema>\r\n  <resheader n" +
        "ame=\"resmimetype\">\r\n    <value>text/microsoft-resx</value>\r\n  </resheader>\r\n  <r" +
        "esheader name=\"version\">\r\n    <value>2.0</value>\r\n  </resheader>\r\n  <resheader n" +
        "ame=\"reader\">\r\n    <value>System.Resources.ResXResourceReader, System.Windows.Fo" +
        "rms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>\r\n" +
        "  </resheader>\r\n  <resheader name=\"writer\">\r\n    <value>System.Resources.ResXRes" +
        "ourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyTo" +
        "ken=b77a5c561934e089</value>\r\n  </resheader>\r\n");

        
        #line default
        #line hidden
        
        #line 254 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"

	foreach(string resourceKey in resourcedStrings.Keys)
	{
		KeyValuePair<string, string> pair = resourcedStrings[resourceKey];
		string resourceValue = pair.Key;
		string resourceComment = pair.Value;
		if(resourceValue==null)
		{
			resourceValue="";
		}

        
        #line default
        #line hidden
        
        #line 264 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write("  <data name=\"");

        
        #line default
        #line hidden
        
        #line 265 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(System.Security.SecurityElement.Escape(resourceKey)));

        
        #line default
        #line hidden
        
        #line 265 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write("\" xml:space=\"preserve\">\r\n    <value>");

        
        #line default
        #line hidden
        
        #line 266 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(System.Security.SecurityElement.Escape(resourceValue)));

        
        #line default
        #line hidden
        
        #line 266 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write("</value>\r\n    <comment>");

        
        #line default
        #line hidden
        
        #line 267 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(System.Security.SecurityElement.Escape(resourceComment)));

        
        #line default
        #line hidden
        
        #line 267 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write("</comment>\r\n  </data>\r\n");

        
        #line default
        #line hidden
        
        #line 269 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"

	}
	if(resourcedFileObjects.Count > 0)
	{

        
        #line default
        #line hidden
        
        #line 273 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write("  <assembly alias=\"System.Windows.Forms\" name=\"System.Windows.Forms, Version=4.0." +
        "0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" />\r\n");

        
        #line default
        #line hidden
        
        #line 275 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"

		foreach(string resourceKey in resourcedFileObjects.Keys)
		{
			KeyValuePair<string, string> pair = resourcedFileObjects[resourceKey];
			string resourceValue = pair.Key;
			string resourceComment = pair.Value;
			if(resourceValue==null)
			{
				resourceValue="";
			}

        
        #line default
        #line hidden
        
        #line 285 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write("  <data name=\"");

        
        #line default
        #line hidden
        
        #line 286 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(System.Security.SecurityElement.Escape(resourceKey)));

        
        #line default
        #line hidden
        
        #line 286 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write("\" type=\"System.Resources.ResXFileRef, System.Windows.Forms\" xml:space=\"preserve\">" +
        "\r\n    <value>");

        
        #line default
        #line hidden
        
        #line 287 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(System.Security.SecurityElement.Escape(resourceValue)));

        
        #line default
        #line hidden
        
        #line 287 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write("</value>\r\n    <comment>");

        
        #line default
        #line hidden
        
        #line 288 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(System.Security.SecurityElement.Escape(resourceComment)));

        
        #line default
        #line hidden
        
        #line 288 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write("</comment>\r\n  </data>\r\n");

        
        #line default
        #line hidden
        
        #line 290 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"

		}
	}

        
        #line default
        #line hidden
        
        #line 293 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"
this.Write("</root>\r\n");

        
        #line default
        #line hidden
        
        #line 295 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\DomainModelResxGenerator.tt"

}
private void AddDomainClassResources(AttributedDomainElement c, Dictionary<string, KeyValuePair<string, string>> resourcedStrings, string commentString, string propertyCommentString)
{
	string fullName = c.GetFullName(false);
	resourcedStrings.Add(fullName+".Description", new KeyValuePair<string, string>(c.Description, String.Format(CultureInfo.CurrentCulture, commentString, "Description", "DomainClass", c.Name)));
	resourcedStrings.Add(fullName+".DisplayName", new KeyValuePair<string, string>(c.DisplayName, String.Format(CultureInfo.CurrentCulture, commentString, "DisplayName", "DomainClass", c.Name)));
	
	foreach(DomainProperty p in c.Properties)
	{
		resourcedStrings.Add(fullName+"/"+p.Name+".Description", new KeyValuePair<string, string>(p.Description, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "Description", "DomainProperty", p.Name, "DomainClass", c.Name)));
		resourcedStrings.Add(fullName+"/"+p.Name+".DisplayName", new KeyValuePair<string, string>(p.DisplayName, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "DisplayName", "DomainProperty", p.Name, "DomainClass", c.Name)));
		if(!String.IsNullOrEmpty(p.Category))
		{
			resourcedStrings.Add(fullName+"/"+p.Name+".Category", new KeyValuePair<string, string>(p.Category, String.Format(CultureInfo.CurrentCulture, propertyCommentString, "Category", "DomainProperty", p.Name, "DomainClass", c.Name)));
		}
	}
}

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}
