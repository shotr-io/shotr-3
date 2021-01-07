﻿/*
 
MetroFramework - Modern UI for WinForms

Copyright (c) 2013 Jens Thiel, http://thielj.github.io/MetroFramework
Portions of this software are Copyright (c) 2011 Sven Walter, http://github.com/viperneo

Permission is hereby granted, free of charge, to any person obtaining a copy of 
this software and associated documentation files (the "Software"), to deal in the 
Software without restriction, including without limitation the rights to use, copy, 
modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
and to permit persons to whom the Software is furnished to do so, subject to the 
following conditions:

The above copyright notice and this permission notice shall be included in 
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 
 */

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using MetroFramework5.Design.Properties;

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
[assembly: Guid("ae7e4b21-8ea9-4055-b81a-32f1ec123953")]

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

namespace MetroFramework5.Design.Properties
{
    internal static class MetroFrameworkDesignAssembly
    {
        internal const string Title = "MetroFramework5.Design.dll";
        // JT: Use same information as main MetroFramework.dll
        internal const string Version = MetroFrameworkAssembly.Version;
        internal const string Description = MetroFrameworkAssembly.Description;
        internal const string Copyright = MetroFrameworkAssembly.Copyright;
        internal const string Company = MetroFrameworkAssembly.Company;
        internal const string Product = MetroFrameworkAssembly.Product;
    }
}
