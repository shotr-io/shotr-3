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
 
Portions of this software are (c) 2011 Sven Walter, http://github.com/viperneo

 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework5.Localization;

namespace MetroFramework5.Controls
{
    [ToolboxBitmap(typeof (CheckBox))]
    //[Designer("MetroFramework.Design.MetroToggleDesigner, " + AssemblyRef.MetroFrameworkDesignSN)]
    public partial class MetroToggle : MetroCheckBoxBase
    {

        #region Properties

        private bool displayStatus = true;

        [DefaultValue(true)]
        [Category(MetroDefaults.CatAppearance)]
        public bool DisplayStatus
        {
            get { return displayStatus; }
            set { displayStatus = value; }
        }

        private readonly MetroLocalize metroLocalize;

        [Browsable(false)]
        public override string Text
        {
            get { return metroLocalize.translate(Checked ? "StatusOn" : "StatusOff"); }
        }

        #endregion

        public MetroToggle()
        {
            SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            UseTransparency();
            UseSelectable();
            UseStyleColor();
            UseFontStyle();

            metroLocalize = new MetroLocalize(this);
        }

        protected override void OnPaintForeground(PaintEventArgs e)
        {
            using (var p = new Pen(GetThemeColor("BorderColor")))
            {
                var width = ClientRectangle.Width - (DisplayStatus ? 31 : 1);
                var boxRect = new Rectangle((DisplayStatus ? 30 : 0), 0, width, ClientRectangle.Height - 1);
                e.Graphics.DrawRectangle(p, boxRect);
            }

            var fillColor = Checked ? GetStyleColor() : GetThemeColor("CheckBox.BorderColor.Normal");
            using (var b = new SolidBrush(fillColor))
            {
                var width = ClientRectangle.Width - (DisplayStatus ? 34 : 4);
                var boxRect = new Rectangle(DisplayStatus ? 32 : 2, 2, width, ClientRectangle.Height - 4);
                e.Graphics.FillRectangle(b, boxRect);
            }

            using (var b = new SolidBrush(EffectiveBackColor)) // TODO: ????
            {
                var left = Checked ? Width - 11 : (DisplayStatus ? 30 : 0);
                var boxRect = new Rectangle(left, 0, 11, ClientRectangle.Height);
                e.Graphics.FillRectangle(b, boxRect);
            }

            using (var b = new SolidBrush(GetThemeColor("CheckBox.BorderColor.Hover")))
            {
                var left = Checked ? Width - 10 : (DisplayStatus ? 30 : 0);
                var boxRect = new Rectangle(left, 0, 10, ClientRectangle.Height);
                e.Graphics.FillRectangle(b, boxRect);
            }

            if (DisplayStatus)
            {
                var textRect = new Rectangle(0, 0, 30, ClientRectangle.Height);
                TextRenderer.DrawText(e.Graphics, Text, EffectiveFont, textRect, EffectiveForeColor, TextAlign.AsTextFormatFlags() | TextFormatFlags.EndEllipsis);
            }
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            Invalidate();
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var preferredSize = base.GetPreferredSize(proposedSize);
            preferredSize.Width = DisplayStatus ? 80 : 50;
            return preferredSize;
        }
    }
}
