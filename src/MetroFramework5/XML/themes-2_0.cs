﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.17929.
// 

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MetroFramework.XML {
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.17929")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType=true, Namespace="http://thielj.github.io/MetroFramework/themes-2_0.xsd")]
    [XmlRoot(Namespace="http://thielj.github.io/MetroFramework/themes-2_0.xsd", IsNullable=false)]
    public partial class metroframework {
        
        /// <remarks/>
        public metroframeworkThemes themes;
        
        /// <remarks/>
        public metroframeworkStyles styles;
    }
    
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.17929")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType=true, Namespace="http://thielj.github.io/MetroFramework/themes-2_0.xsd")]
    public partial class metroframeworkThemes {
        
        /// <remarks/>
        [XmlElement("theme")]
        public metroframeworkThemesTheme[] theme;
        
        /// <remarks/>
        [XmlAttribute()]
        public string @default;
    }
    
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.17929")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType=true, Namespace="http://thielj.github.io/MetroFramework/themes-2_0.xsd")]
    public partial class metroframeworkThemesTheme {
        
        /// <remarks/>
        [XmlElement("property")]
        public metroframeworkThemesThemeProperty[] property;
        
        /// <remarks/>
        [XmlAttribute()]
        public string name;
    }
    
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.17929")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType=true, Namespace="http://thielj.github.io/MetroFramework/themes-2_0.xsd")]
    public partial class metroframeworkThemesThemeProperty {
        
        /// <remarks/>
        [XmlAttribute()]
        public string name;
        
        /// <remarks/>
        [XmlAttribute()]
        public string value;
        
        /// <remarks/>
        [XmlAttribute()]
        public string type;
    }
    
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.17929")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType=true, Namespace="http://thielj.github.io/MetroFramework/themes-2_0.xsd")]
    public partial class metroframeworkStyles {
        
        /// <remarks/>
        [XmlElement("color")]
        public metroframeworkStylesColor[] color;
        
        /// <remarks/>
        [XmlAttribute()]
        public string @default;
    }
    
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.17929")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType=true, Namespace="http://thielj.github.io/MetroFramework/themes-2_0.xsd")]
    public partial class metroframeworkStylesColor {
        
        /// <remarks/>
        [XmlAttribute()]
        public string name;
        
        /// <remarks/>
        [XmlAttribute()]
        public string value;
        
        /// <remarks/>
        [XmlAttribute()]
        public string type;
    }
}
