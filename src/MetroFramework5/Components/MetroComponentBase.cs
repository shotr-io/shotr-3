﻿ 
 
 
/**************************************************************************************

                        GENERATED FILE - DO NOT EDIT

 **************************************************************************************/
  /*
 
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
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using MetroFramework5.Components;
using MetroFramework5.Drawing;
using MetroFramework5.Interfaces;

namespace MetroFramework5.Components
{


	[EditorBrowsable(EditorBrowsableState.Advanced)]
    public abstract class MetroComponentBase : Component, IMetroComponent, IMetroStyledComponent
    {

		#region Fields, Constructor & IDisposable

        private readonly MetroStyleManager _styleManager;

	    protected MetroComponentBase()
        {
            _styleManager = new MetroStyleManager();
            _styleManager.MetroStyleChanged += OnMetroStyleChanged;
        }
                   
        protected override void Dispose(bool disposing)
        {
            if (disposing) _styleManager.Dispose();
            base.Dispose(disposing);
        }

		#endregion

        #region Style Manager Interface

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        MetroStyleManager IMetroStyledComponent.InternalStyleManager
        {
            get { return _styleManager; }
            // NOTE: we don't replace our style manager, but instead assign the style manager a new manager
            set { ((IMetroStyledComponent)_styleManager).InternalStyleManager = value; }
        }

        // Event handler for our style manager's updates
        // NOTE: The event may have been triggered from a different thread.
		protected abstract void OnMetroStyleChanged(object sender, EventArgs e);

        // Override Site property to set the style manager into design mode, too.
        public override ISite Site
        {
            get { return base.Site; }
            set { base.Site = _styleManager.Site = value; }
        }

        #endregion

		#region Properties

        [DefaultValue(MetroStyleManager.AMBIENT_VALUE)]
        [Category(MetroDefaults.CatAppearance)]
        public string Theme
        {
            get { return _styleManager.Theme; }
            set { _styleManager.Theme = value; }
        }

		[DefaultValue(MetroStyleManager.AMBIENT_VALUE)]
        [Category(MetroDefaults.CatAppearance)]
        public string Style
        {
            get { return _styleManager.Style; }
            set { _styleManager.Style = value; }
        }

		#endregion

		protected virtual string MetroControlCategory { get { return "Component"; } }

		protected virtual string MetroControlState { get { return "Normal"; } }

		protected virtual bool TryGetThemeProperty<T>(string property, out T value, string state = null, string category = null) 
		{
			return _styleManager.TryGetThemeProperty(property, out value, state ?? MetroControlState, category ?? MetroControlCategory);
		}

		[Obsolete]
		protected virtual object GetThemeProperty(string property) 
		{
			return _styleManager.GetThemeProperty(property, MetroControlState, MetroControlCategory);
		}

		protected virtual Color GetThemeColor(string property)
		{
			return _styleManager.GetThemeColor(property, MetroControlState, MetroControlCategory);
		}

        protected virtual Font GetThemeFont()
        {
			return GetThemeFont(MetroFontSize.Default, MetroFontWeight.Default);
		}

        protected Font GetThemeFont(MetroFontSize size, MetroFontWeight weight)
        {
            if (size == MetroFontSize.Default && !TryGetThemeProperty("MetroFontSize", out size) )
                size = MetroDefaults.MetroFontSize;

            if (weight == MetroFontWeight.Default && !TryGetThemeProperty("MetroFontWeight", out weight))
                weight = MetroDefaults.MetroFontWeight;

            return _styleManager.GetThemeFont(size, weight, MetroControlCategory);
        }
		
		protected virtual Color GetStyleColor()
		{
			return _styleManager.GetStyleColor();
		}

    }


	[EditorBrowsable(EditorBrowsableState.Advanced)]
    public abstract class MetroToolTipBase : ToolTip, IMetroComponent, IMetroStyledComponent
    {

		#region Fields, Constructor & IDisposable

        private readonly MetroStyleManager _styleManager;

	    protected MetroToolTipBase()
        {
            _styleManager = new MetroStyleManager();
            _styleManager.MetroStyleChanged += OnMetroStyleChanged;
        }
                   
        protected override void Dispose(bool disposing)
        {
            if (disposing) _styleManager.Dispose();
            base.Dispose(disposing);
        }

		#endregion

        #region Style Manager Interface

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        MetroStyleManager IMetroStyledComponent.InternalStyleManager
        {
            get { return _styleManager; }
            // NOTE: we don't replace our style manager, but instead assign the style manager a new manager
            set { ((IMetroStyledComponent)_styleManager).InternalStyleManager = value; }
        }

        // Event handler for our style manager's updates
        // NOTE: The event may have been triggered from a different thread.
		protected abstract void OnMetroStyleChanged(object sender, EventArgs e);

        // Override Site property to set the style manager into design mode, too.
        public override ISite Site
        {
            get { return base.Site; }
            set { base.Site = _styleManager.Site = value; }
        }

        #endregion

		#region Properties

        [DefaultValue(MetroStyleManager.AMBIENT_VALUE)]
        [Category(MetroDefaults.CatAppearance)]
        public string Theme
        {
            get { return _styleManager.Theme; }
            set { _styleManager.Theme = value; }
        }

		[DefaultValue(MetroStyleManager.AMBIENT_VALUE)]
        [Category(MetroDefaults.CatAppearance)]
        public string Style
        {
            get { return _styleManager.Style; }
            set { _styleManager.Style = value; }
        }

		#endregion

		protected virtual string MetroControlCategory { get { return "ToolTip"; } }

		protected virtual string MetroControlState { get { return "Normal"; } }

		protected virtual bool TryGetThemeProperty<T>(string property, out T value, string state = null, string category = null) 
		{
			return _styleManager.TryGetThemeProperty(property, out value, state ?? MetroControlState, category ?? MetroControlCategory);
		}

		[Obsolete]
		protected virtual object GetThemeProperty(string property) 
		{
			return _styleManager.GetThemeProperty(property, MetroControlState, MetroControlCategory);
		}

		protected virtual Color GetThemeColor(string property)
		{
			return _styleManager.GetThemeColor(property, MetroControlState, MetroControlCategory);
		}

        protected virtual Font GetThemeFont()
        {
			return GetThemeFont(MetroFontSize.Default, MetroFontWeight.Default);
		}

        protected Font GetThemeFont(MetroFontSize size, MetroFontWeight weight)
        {
            if (size == MetroFontSize.Default && !TryGetThemeProperty("MetroFontSize", out size) )
                size = MetroDefaults.MetroFontSize;

            if (weight == MetroFontWeight.Default && !TryGetThemeProperty("MetroFontWeight", out weight))
                weight = MetroDefaults.MetroFontWeight;

            return _styleManager.GetThemeFont(size, weight, MetroControlCategory);
        }
		
		protected virtual Color GetStyleColor()
		{
			return _styleManager.GetStyleColor();
		}

    }


}
 
