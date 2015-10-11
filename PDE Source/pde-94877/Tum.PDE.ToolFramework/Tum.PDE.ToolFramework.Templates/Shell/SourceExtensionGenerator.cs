﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 10.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Tum.PDE.ToolFramework.Templates.Shell
{
    using Tum.PDE.LanguageDSL;
    using Microsoft.VisualStudio.Modeling;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System;
    
    
    #line 1 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\Shell\SourceExtensionGenerator.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class SourceExtensionGenerator : BaseTemplate
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
            
            #line 9 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\Shell\SourceExtensionGenerator.tt"

  	// The name of the Dsl Project - Must be updated if the project is renamed.
  	//string dslProjectName = "Tum.PDE.VSPluginDSL";
  	
	// The name of the UI Project - Must be updated if the project is renamed.
  	//string uiProjectName = "Tum.PDE.VSPluginDSL.UI";

  	string localeId = "1033";

  	string description = this.MetaModel.Description;
  	if( String.IsNullOrEmpty(description) )
		description = "Desciption of VSPluginDSL";
	
	string version = "";
	if( !String.IsNullOrEmpty(this.MetaModel.MajorVersion) )
		version += this.MetaModel.MajorVersion + ".";
	else
		version +="0" + ".";
	
	if( !String.IsNullOrEmpty(this.MetaModel.MinorVersion) )
		version += this.MetaModel.MinorVersion + ".";
	else
		version +="0" + ".";
	
	if( !String.IsNullOrEmpty(this.MetaModel.Build) )
		version += this.MetaModel.Build + ".";
	else
		version +="0" + ".";
	
	if( !String.IsNullOrEmpty(this.MetaModel.Revision) )
		version += this.MetaModel.Revision;
	else
		version +="0";
	

            
            #line default
            #line hidden
            this.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Vsix xmlns:xsi=\"http://www.w3.org/2001/X" +
                    "MLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" Version=\"1.0.0\" " +
                    "xmlns=\"http://schemas.microsoft.com/developer/vsx-schema/2010\">\r\n  <Identifier I" +
                    "d=\"");
            
            #line 46 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\Shell\SourceExtensionGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.MetaModel.PackageGuid));
            
            #line default
            #line hidden
            this.Write("\">\r\n    <Name>");
            
            #line 47 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\Shell\SourceExtensionGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.MetaModel.DisplayName));
            
            #line default
            #line hidden
            this.Write("</Name>\r\n    <Author>");
            
            #line 48 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\Shell\SourceExtensionGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.MetaModel.CompanyName));
            
            #line default
            #line hidden
            this.Write("</Author>\r\n    <Version>");
            
            #line 49 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\Shell\SourceExtensionGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(version));
            
            #line default
            #line hidden
            this.Write("</Version>\r\n    <Description>");
            
            #line 50 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\Shell\SourceExtensionGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(description));
            
            #line default
            #line hidden
            this.Write("</Description>\r\n    <Locale>");
            
            #line 51 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\Shell\SourceExtensionGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(localeId));
            
            #line default
            #line hidden
            this.Write(@"</Locale>
    <MoreInfoUrl></MoreInfoUrl>
    <GettingStartedGuide></GettingStartedGuide>
    <Icon></Icon>
    <PreviewImage></PreviewImage>
    <SupportedProducts>
      <VisualStudio Version=""10.0"">
        <Edition>Ultimate</Edition>
        <Edition>Premium</Edition>
        <Edition>Pro</Edition>
      </VisualStudio>
    </SupportedProducts>
    <SupportedFrameworkRuntimeEdition MinVersion=""4.0"" MaxVersion=""4.0"" />
  </Identifier>
  <References/>
  <Content>
    <VsPackage>|%CurrentProject%;PkgdefProjectOutputGroup|</VsPackage>
    <MefComponent>|%CurrentProject%|</MefComponent>
  </Content>
</Vsix>");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}