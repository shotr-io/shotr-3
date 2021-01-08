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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using MetroFramework5;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

[assembly: CLSCompliant(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("9559a6f3-8cce-4644-a571-8aeeeb526094")]

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
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly:AllowPartiallyTrustedCallers]

[assembly: InternalsVisibleTo(AssemblyRef.MetroFrameworkDesignIVT)]
[assembly: InternalsVisibleTo(AssemblyRef.MetroFrameworkFontsIVT)]

#if DEBUG
[assembly: InternalsVisibleTo("XmlHelper, PublicKey=" + AssemblyRef.MetroFrameworkKeyFull)]

#endif

internal static class MetroFrameworkAssembly
{
    internal const string Title = "MetroFramework.dll";
    internal const string Version = "1.2.0.3";
    internal const string Description = "Metro UI Framework for .NET WinForms";
    internal const string Copyright = "Copyright \x00a9 2013 Jens Thiel.  All rights reserved.";
    internal const string Company = "Jens Thiel";
    internal const string Product = "MetroFramework";
}
namespace MetroFramework5
{
    internal static class AssemblyRef
    {

        // Design

        internal const string MetroFrameworkDesign_ = "MetroFramework5.Design";

        internal const string MetroFrameworkDesignSN = "MetroFramework5.Design, Version=" + MetroFrameworkAssembly.Version
                                                     + ", Culture=neutral, PublicKeyToken=" + MetroFrameworkKeyToken;

        internal const string MetroFrameworkDesignIVT = "MetroFramework5.Design, PublicKey=" + MetroFrameworkKeyFull;

        // Fonts

        internal const string MetroFrameworkFonts_ = "MetroFramework5.Fonts";

        internal const string MetroFrameworkFontsSN = "MetroFramework5.Fonts, Version=" + MetroFrameworkAssembly.Version
                                                    + ", Culture=neutral, PublicKeyToken=" + MetroFrameworkKeyToken;

        internal const string MetroFrameworkFontsIVT = "MetroFramework5.Fonts, PublicKey=" + MetroFrameworkKeyFull;

        internal const string MetroFrameworkFontResolver = "MetroFramework5.Fonts.FontResolver, " + MetroFrameworkFontsSN;

        // Strong Name Key

        internal const string MetroFrameworkKey = "5f91a84759bf584a";

        internal const string MetroFrameworkKeyFull =
            "00240000048000009400000006020000002400005253413100040000010001004d3b6f2adab21d" +
            "00d59de966f5d7f4d8325296ded578ac35bca529580b534443bb4090600ff1f057136d58f20a22" +
            "5e0d025119aec656e9b6ac5691e12689c0b03d55c8b8822fd84e2acbde80a2d9124009d20f5adf" +
            "05d36cfa95ba164a0d6ab348a9f8e3a00f066f4d32c0b71b5be6d7f86616491f6dd0630e49ec15" +
            "a0c8f9c9";

        internal const string MetroFrameworkKeyToken = "5f91a84759bf584a";
    }
}