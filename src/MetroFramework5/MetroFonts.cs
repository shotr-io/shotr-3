 #region Copyright (c) 2013 Jens Thiel, http://thielj.github.io/MetroFramework
/*
 
MetroFramework - Windows Modern UI for .NET WinForms applications

Copyright (c) 2013 Jens Thiel, http://thielj.github.io/MetroFramework

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
#endregion

 using System;
 using System.Collections.Generic;
 using System.Drawing;
 using System.Drawing.Text;
 using System.Linq;
 using System.Runtime.InteropServices;
 using System.Security;
 using MetroFramework5.Drawing;
 using MetroFramework5.Properties;

 namespace MetroFramework5
{
    internal static class MetroFonts
    {

        #region Font Resolver

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [In] ref uint pcFonts);

        [SecuritySafeCritical]
        internal interface IMetroFontResolver
        {
            [SecuritySafeCritical]
            Font ResolveFont(string familyName, float emSize, FontStyle fontStyle, GraphicsUnit unit);
        }

        [SecuritySafeCritical]
        private class DefaultFontResolver : IMetroFontResolver
        {
            private PrivateFontCollection _pfc;
            [SecuritySafeCritical]
            public DefaultFontResolver()
            {
                var resourceList = new List<byte[]>
                {
                    Resources.poppins_regular,
                    Resources.poppins_light,
                    Resources.poppins_extralight,
                    Resources.poppins_medium,
                };
                _pfc = new PrivateFontCollection();
                foreach (var item in resourceList)
                {
                    IntPtr data = Marshal.AllocCoTaskMem(item.Length);
                    Marshal.Copy(item, 0, data, item.Length);
                    uint dummy = 0;
                    AddFontMemResourceEx(data, (uint)item.Length, IntPtr.Zero, ref dummy);
                    _pfc.AddMemoryFont(data, item.Length);
                }
            }

            [SecuritySafeCritical]
            public Font ResolveFont(string familyName, float emSize, FontStyle fontStyle, GraphicsUnit unit)
            {
                familyName = familyName.Replace("Segoe UI", "Poppins");
                var font = _pfc.Families.FirstOrDefault(f => f.Name == familyName);
                if (font == null)
                {
                    Console.WriteLine("Cannot find font {0}, falling back to default font {1}.", familyName, _pfc.Families[0].Name);
                    return new Font(_pfc.Families[0], emSize, fontStyle, unit);
                }
                return new Font(font, emSize, fontStyle, unit);
            }
        }

        private static readonly IMetroFontResolver FontResolver;

        static MetroFonts()
        {
            FontResolver = new DefaultFontResolver();
        }

        #endregion

        public static Font ResolveFont(string familyName, float emSize, FontStyle fontStyle,
                                       GraphicsUnit unit = GraphicsUnit.Pixel)
        {
            return FontResolver.ResolveFont(familyName, emSize, fontStyle, unit);
        }

        #region OBSOLETE

        [Obsolete]
        public static Font DefaultLight(float size)
        {
            return FontResolver.ResolveFont("Segoe UI Light", size, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        [Obsolete]
        public static Font Default(float size)
        {
            return FontResolver.ResolveFont("Segoe UI", size, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        [Obsolete]
        public static Font DefaultBold(float size)
        {
            return FontResolver.ResolveFont("Segoe UI", size, FontStyle.Bold, GraphicsUnit.Pixel);
        }

        [Obsolete]
        public static Font Title
        {
            get { return DefaultLight(24f); }
        }

        [Obsolete]
        public static Font Subtitle
        {
            get { return Default(14f); }
        }

        [Obsolete]
        public static Font Button
        {
            get { return DefaultBold(11f); }
        }

        [Obsolete]
        public static Font Tile(MetroTileTextSize labelSize, MetroTileTextWeight labelWeight)
        {
            if (labelSize == MetroTileTextSize.Small)
            {
                if (labelWeight == MetroTileTextWeight.Light)
                    return DefaultLight(12f);
                if (labelWeight == MetroTileTextWeight.Regular)
                    return Default(12f);
                if (labelWeight == MetroTileTextWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (labelSize == MetroTileTextSize.Medium)
            {
                if (labelWeight == MetroTileTextWeight.Light)
                    return DefaultLight(14f);
                if (labelWeight == MetroTileTextWeight.Regular)
                    return Default(14f);
                if (labelWeight == MetroTileTextWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (labelSize == MetroTileTextSize.Tall)
            {
                if (labelWeight == MetroTileTextWeight.Light)
                    return DefaultLight(18f);
                if (labelWeight == MetroTileTextWeight.Regular)
                    return Default(18f);
                if (labelWeight == MetroTileTextWeight.Bold)
                    return DefaultBold(18f);
            }

            return DefaultLight(14f);
        }

        [Obsolete]
        public static Font TileCount
        {
            get { return Default(44f); }
        }

        [Obsolete]
        public static Font Link(MetroLinkSize linkSize, MetroLinkWeight linkWeight)
        {
            if (linkSize == MetroLinkSize.Small)
            {
                if (linkWeight == MetroLinkWeight.Light)
                    return DefaultLight(12f);
                if (linkWeight == MetroLinkWeight.Regular)
                    return Default(12f);
                if (linkWeight == MetroLinkWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (linkSize == MetroLinkSize.Medium)
            {
                if (linkWeight == MetroLinkWeight.Light)
                    return DefaultLight(14f);
                if (linkWeight == MetroLinkWeight.Regular)
                    return Default(14f);
                if (linkWeight == MetroLinkWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (linkSize == MetroLinkSize.Tall)
            {
                if (linkWeight == MetroLinkWeight.Light)
                    return DefaultLight(18f);
                if (linkWeight == MetroLinkWeight.Regular)
                    return Default(18f);
                if (linkWeight == MetroLinkWeight.Bold)
                    return DefaultBold(18f);
            }

            return Default(12f);
        }

        [Obsolete]
        public static Font Label(MetroFontSize labelSize, MetroFontWeight labelWeight)
        {
            if (labelSize == MetroFontSize.Small)
            {
                if (labelWeight == MetroFontWeight.Light)
                    return DefaultLight(12f);
                if (labelWeight == MetroFontWeight.Regular)
                    return Default(12f);
                if (labelWeight == MetroFontWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (labelSize == MetroFontSize.Medium)
            {
                if (labelWeight == MetroFontWeight.Light)
                    return DefaultLight(14f);
                if (labelWeight == MetroFontWeight.Regular)
                    return Default(14f);
                if (labelWeight == MetroFontWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (labelSize == MetroFontSize.Large)
            {
                if (labelWeight == MetroFontWeight.Light)
                    return DefaultLight(18f);
                if (labelWeight == MetroFontWeight.Regular)
                    return Default(18f);
                if (labelWeight == MetroFontWeight.Bold)
                    return DefaultBold(18f);
            }

            return DefaultLight(14f);
        }

        [Obsolete]
        public static Font TextBox(MetroTextBoxSize linkSize, MetroTextBoxWeight linkWeight)
        {
            if (linkSize == MetroTextBoxSize.Small)
            {
                if (linkWeight == MetroTextBoxWeight.Light)
                    return DefaultLight(12f);
                if (linkWeight == MetroTextBoxWeight.Regular)
                    return Default(12f);
                if (linkWeight == MetroTextBoxWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (linkSize == MetroTextBoxSize.Medium)
            {
                if (linkWeight == MetroTextBoxWeight.Light)
                    return DefaultLight(14f);
                if (linkWeight == MetroTextBoxWeight.Regular)
                    return Default(14f);
                if (linkWeight == MetroTextBoxWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (linkSize == MetroTextBoxSize.Tall)
            {
                if (linkWeight == MetroTextBoxWeight.Light)
                    return DefaultLight(18f);
                if (linkWeight == MetroTextBoxWeight.Regular)
                    return Default(18f);
                if (linkWeight == MetroTextBoxWeight.Bold)
                    return DefaultBold(18f);
            }

            return Default(12f);
        }

        [Obsolete]
        public static Font ProgressBar(MetroProgressBarSize labelSize, MetroProgressBarWeight labelWeight)
        {
            if (labelSize == MetroProgressBarSize.Small)
            {
                if (labelWeight == MetroProgressBarWeight.Light)
                    return DefaultLight(12f);
                if (labelWeight == MetroProgressBarWeight.Regular)
                    return Default(12f);
                if (labelWeight == MetroProgressBarWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (labelSize == MetroProgressBarSize.Medium)
            {
                if (labelWeight == MetroProgressBarWeight.Light)
                    return DefaultLight(14f);
                if (labelWeight == MetroProgressBarWeight.Regular)
                    return Default(14f);
                if (labelWeight == MetroProgressBarWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (labelSize == MetroProgressBarSize.Tall)
            {
                if (labelWeight == MetroProgressBarWeight.Light)
                    return DefaultLight(18f);
                if (labelWeight == MetroProgressBarWeight.Regular)
                    return Default(18f);
                if (labelWeight == MetroProgressBarWeight.Bold)
                    return DefaultBold(18f);
            }

            return DefaultLight(14f);
        }

        [Obsolete]
        public static Font TabControl(MetroTabControlSize labelSize, MetroTabControlWeight labelWeight)
        {
            if (labelSize == MetroTabControlSize.Small)
            {
                if (labelWeight == MetroTabControlWeight.Light)
                    return DefaultLight(12f);
                if (labelWeight == MetroTabControlWeight.Regular)
                    return Default(12f);
                if (labelWeight == MetroTabControlWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (labelSize == MetroTabControlSize.Medium)
            {
                if (labelWeight == MetroTabControlWeight.Light)
                    return DefaultLight(14f);
                if (labelWeight == MetroTabControlWeight.Regular)
                    return Default(14f);
                if (labelWeight == MetroTabControlWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (labelSize == MetroTabControlSize.Tall)
            {
                if (labelWeight == MetroTabControlWeight.Light)
                    return DefaultLight(18f);
                if (labelWeight == MetroTabControlWeight.Regular)
                    return Default(18f);
                if (labelWeight == MetroTabControlWeight.Bold)
                    return DefaultBold(18f);
            }

            return DefaultLight(14f);
        }

        #endregion

    }

    #region OBSOLETE

    [Obsolete]
    public enum MetroTileTextSize
    {
        Small,
        Medium,
        Tall
    }

    [Obsolete]
    public enum MetroTileTextWeight
    {
        Light,
        Regular,
        Bold
    }

    [Obsolete]
    public enum MetroLinkSize
    {
        Small,
        Medium,
        Tall
    }

    [Obsolete]
    public enum MetroLinkWeight
    {
        Light,
        Regular,
        Bold
    }

    [Obsolete]
    public enum MetroTextBoxSize
    {
        Small,
        Medium,
        Tall
    }

    [Obsolete]
    public enum MetroTextBoxWeight
    {
        Light,
        Regular,
        Bold
    }

    [Obsolete]
    public enum MetroProgressBarSize
    {
        Small,
        Medium,
        Tall
    }

    [Obsolete]
    public enum MetroProgressBarWeight
    {
        Light,
        Regular,
        Bold
    }

    [Obsolete]
    public enum MetroTabControlSize
    {
        Small,
        Medium,
        Tall
    }

    [Obsolete]
    public enum MetroTabControlWeight
    {
        Light,
        Regular,
        Bold
    }

    #endregion


}
