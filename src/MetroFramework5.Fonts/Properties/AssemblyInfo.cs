using System;
using System.Reflection;
using System.Runtime.InteropServices;
using MetroFramework5.Fonts.Properties;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle(MetroFrameworkDesignAssembly.Title)]
[assembly: AssemblyDescription(MetroFrameworkDesignAssembly.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(MetroFrameworkDesignAssembly.Company)]
[assembly: AssemblyProduct(MetroFrameworkDesignAssembly.Product)]
[assembly: AssemblyCopyright(MetroFrameworkDesignAssembly.Copyright)]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// JT: Ensure API compatibility
[assembly: CLSCompliant(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("639b45e3-11f9-4e52-8479-7b6f20a5ce98")]

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
[assembly: AssemblyVersion(MetroFrameworkDesignAssembly.Version)]
[assembly: AssemblyFileVersion(MetroFrameworkDesignAssembly.Version)]

namespace MetroFramework5.Fonts.Properties
{
    internal static class MetroFrameworkDesignAssembly
    {
        internal const string Title = "MetroFramework5.Fonts.dll";
        // JT: Use same information as main MetroFramework.dll
        internal const string Version = MetroFrameworkAssembly.Version;
        internal const string Description = MetroFrameworkAssembly.Description;
        internal const string Copyright = MetroFrameworkAssembly.Copyright;
        internal const string Company = MetroFrameworkAssembly.Company;
        internal const string Product = MetroFrameworkAssembly.Product;
    }
}
