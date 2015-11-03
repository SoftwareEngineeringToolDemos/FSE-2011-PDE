using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public sealed partial class LanguageDSLDirectiveProcessor
    {
        private const string defaultGeneratedNamespaceNameParameter = "GeneratedNamespace";
        private const string providesGeneratedNamespaceNameParameter = "GeneratedNamespace";
        private const string providesGeneratedResourceNameParameter = "GeneratedResourceName";
        private const string requiresGeneratedCodeFolderParameter = "GeneratedCodeFolder";
        private const string requiresGeneratedResourceFileParameter = "GeneratedResourceFile";
        private const string requiresProjectDefaultNamespaceParameter = "ProjectDefaultNamespace";

        protected override void GenerateTransformCode(string directiveName, System.Text.StringBuilder codeBuffer, System.CodeDom.Compiler.CodeDomProvider languageProvider, System.Collections.Generic.IDictionary<string, string> requiresArguments, System.Collections.Generic.IDictionary<string, string> providesArguments)
        {
            base.GenerateTransformCode(directiveName, codeBuffer, languageProvider, requiresArguments, providesArguments);

            System.CodeDom.CodeMemberField codeMemberField = null;
            if (!System.String.IsNullOrEmpty(providesArguments["GeneratedResourceName"]))
            {
                codeMemberField = new System.CodeDom.CodeMemberField(new System.CodeDom.CodeTypeReference(typeof(string)), providesArguments["GeneratedResourceName"]);
                codeMemberField.Attributes = System.CodeDom.MemberAttributes.Abstract | System.CodeDom.MemberAttributes.Override | System.CodeDom.MemberAttributes.FamilyAndAssembly | System.CodeDom.MemberAttributes.FamilyOrAssembly;
                string s = requiresArguments["ProjectDefaultNamespace"];
                if (!System.String.IsNullOrEmpty(requiresArguments["GeneratedCodeFolder"]))
                {
                    if (!System.String.IsNullOrEmpty(s))
                        s += ".";
                    s += requiresArguments["GeneratedCodeFolder"];
                }
                if (!System.String.IsNullOrEmpty(requiresArguments["GeneratedResourceFile"]))
                {
                    if (!System.String.IsNullOrEmpty(s))
                        s += ".";
                    s += requiresArguments["GeneratedResourceFile"];
                }
                codeMemberField.InitExpression = new System.CodeDom.CodePrimitiveExpression(s);

                System.CodeDom.Compiler.CodeGeneratorOptions codeGeneratorOptions = new System.CodeDom.Compiler.CodeGeneratorOptions();
                codeGeneratorOptions.BlankLinesBetweenMembers = true;
                codeGeneratorOptions.IndentString = "    ";
                codeGeneratorOptions.VerbatimOrder = true;
                codeGeneratorOptions.BracingStyle = "C";
                using (System.IO.StringWriter stringWriter = new System.IO.StringWriter(codeBuffer, System.Globalization.CultureInfo.InvariantCulture))
                {
                    if (codeMemberField != null)
                        languageProvider.GenerateCodeFromMember(codeMemberField, stringWriter, codeGeneratorOptions);
                }
            }
            if (!System.String.IsNullOrEmpty(providesArguments["GeneratedNamespace"]))
            {
                codeMemberField = new System.CodeDom.CodeMemberField(new System.CodeDom.CodeTypeReference(typeof(string)), providesArguments["GeneratedNamespace"]);
                codeMemberField.Attributes = System.CodeDom.MemberAttributes.Abstract | System.CodeDom.MemberAttributes.Override | System.CodeDom.MemberAttributes.FamilyAndAssembly | System.CodeDom.MemberAttributes.FamilyOrAssembly;
                string s = requiresArguments["ProjectDefaultNamespace"];
                codeMemberField.InitExpression = new System.CodeDom.CodePrimitiveExpression(s);

                System.CodeDom.Compiler.CodeGeneratorOptions codeGeneratorOptions = new System.CodeDom.Compiler.CodeGeneratorOptions();
                codeGeneratorOptions.BlankLinesBetweenMembers = true;
                codeGeneratorOptions.IndentString = "    ";
                codeGeneratorOptions.VerbatimOrder = true;
                codeGeneratorOptions.BracingStyle = "C";
                using (System.IO.StringWriter stringWriter = new System.IO.StringWriter(codeBuffer, System.Globalization.CultureInfo.InvariantCulture))
                {
                    if (codeMemberField != null)
                        languageProvider.GenerateCodeFromMember(codeMemberField, stringWriter, codeGeneratorOptions);
                }
            }

        }

        protected override void InitializeProvidesDictionary(string directiveName, System.Collections.Generic.IDictionary<string, string> providesDictionary)
        {
            base.InitializeProvidesDictionary(directiveName, providesDictionary);
            providesDictionary.Add("GeneratedResourceName", "GeneratedResourceName");
            providesDictionary.Add("GeneratedNamespace", "GeneratedNamespace");
        }

        protected override void InitializeRequiresDictionary(string directiveName, System.Collections.Generic.IDictionary<string, string> requiresDictionary)
        {
            base.InitializeRequiresDictionary(directiveName, requiresDictionary);
            requiresDictionary.Add("GeneratedCodeFolder", "GeneratedCode");
            requiresDictionary.Add("GeneratedResourceFile", "DomainModelResx");
            requiresDictionary.Add("ProjectDefaultNamespace", System.String.Empty);
        }
    }
}
