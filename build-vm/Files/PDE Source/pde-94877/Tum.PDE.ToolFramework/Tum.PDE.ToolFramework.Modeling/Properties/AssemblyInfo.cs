using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ToolFramework.Modeling")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("TU Muenchen")]
[assembly: AssemblyProduct("ToolFramework.Modeling")]
[assembly: AssemblyCopyright("Copyright © TU Muenchen 2011")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

//In order to begin building localizable applications, set 
//<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
//inside a <PropertyGroup>.  For example, if you are using US english
//in your source files, set the <UICulture> to en-US.  Then uncomment
//the NeutralResourceLanguage attribute below.  Update the "en-US" in
//the line below to match the UICulture setting in the project file.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
    //(used if a resource is not found in the page, 
    // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
    //(used if a resource is not found in the page, 
    // app, or any theme specific resource dictionaries)
)]


// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.9.9")]
[assembly: AssemblyFileVersion("0.9.9")]

//
// Make the Modeling project internally visible to the Modeling.Shell assembly
//
[assembly: InternalsVisibleTo(@"Tum.PDE.ToolFramework.Modeling.Shell, PublicKey=0024000004800000940000000602000000240000525341310004000001000100839b4b4eca845ca5a4f8ed51f7e4f03bc51f1b145a5dc688729b5d9a7898f196dac0884b7b28136fd6fa56138a7775470a46d22e70942addd1733876ccc7c4cca3f6c1eb03d9fc5dd2f7fa8a1bad4e86797f627bb65ca4c58f257b960d9358fdd686408e9f311397df80a2d27470a88408979252a56779d5c5caf2fbe805a1b3")]
