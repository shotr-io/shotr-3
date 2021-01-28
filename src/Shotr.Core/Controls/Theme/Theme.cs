using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Shotr.Core.Controls.DpiScaling;
using Shotr.Core.Properties;

namespace Shotr.Core.Controls.Theme
{
    public static class Theme
    {
        private static PrivateFontCollection _privateFontCollection = new PrivateFontCollection();
        public static void LoadFonts()
        {
            var data = Marshal.AllocCoTaskMem(Resources.Inter_Regular.Length);
            Marshal.Copy(Resources.Inter_Regular, 0, data, Resources.Inter_Regular.Length);
            _privateFontCollection.AddMemoryFont(data, Resources.Inter_Regular.Length);
            Marshal.FreeCoTaskMem(data);
        }

        public static Font Font(float emSize) => new Font(_privateFontCollection.Families.FirstOrDefault(p => p.Name == "Inter") ?? new FontFamily("Inter"), emSize, FontStyle.Regular, GraphicsUnit.Pixel);
        public static Font Font(Font font, Control control) => DpiScaler.ScaleFont(font, control);

        public static Color FormBackColor = Color.FromArgb(19, 19, 48);
        public static Color FormHighlightColor = Color.FromArgb(79, 72, 165);

        public static Color TabPageBackColor = Color.FromArgb(19, 19, 48);

        public static Color ButtonBackColor = Color.FromArgb(79, 72, 165);
        public static Color ButtonDisabledColor = Color.FromArgb(126, 126, 126);
        public static Color ButtonForeColor = Color.FromArgb(255, 255, 255);
        public static Color ButtonHighlightColor = Color.FromArgb(255, 255, 255);
        public static Color ButtonBorderColor = Color.FromArgb(100, 100, 100);
        public static Color ButtonHoverColor = Color.FromArgb(150, 150, 150);
        public static Color ButtonClickColor = Color.FromArgb(204, 204, 204);

        public static Color LabelForeColor = Color.FromArgb(255, 255, 255);

        public static Color LinkLabelBackColor = Color.FromArgb(19, 19, 48);
        public static Color LinkLabelForeColor = Color.FromArgb(255, 255, 255);

        public static Color ToggleBackColor = Color.FromArgb(19, 19, 48);
        public static Color ToggleHoverColor = Color.FromArgb(204, 204, 204);
        public static Color ToggleBorderColor = Color.FromArgb(51, 45, 68);
        public static Color ToggleBarColor = Color.FromArgb(204, 204, 204);
        public static Color ToggleOnColor = Color.FromArgb(79, 72, 165);
        public static Color ToggleOffColor = Color.FromArgb(51, 45, 68);

        public static Color ProgressBarBackColor = Color.FromArgb(19, 19, 48);
        public static Color ProgressBarForeColor = Color.FromArgb(255, 255, 255);
        public static Color ProgressBarBorderColor = Color.FromArgb(51, 45, 68);
        public static Color ProgressBarColor = Color.FromArgb(79, 72, 165);

        public static Color PanelBackColor = Color.FromArgb(19, 19, 48);
        public static Color PanelBorderColor = Color.FromArgb(51, 45, 68);

        public static Color TextBoxBackColor = Color.FromArgb(24, 24, 62);
        public static Color TextBoxForeColor = Color.FromArgb(255, 255, 255);
        public static Color TextBoxBorderColor = Color.FromArgb(51, 45, 68);

        public static Color ComboBoxBackColor = Color.FromArgb(24, 24, 62);
        public static Color ComboBoxForeColor = Color.FromArgb(255, 255, 255);
        public static Color ComboBoxBorderColor = Color.FromArgb(51, 45, 68);
        public static Color ComboBoxFocusedColor = Color.FromArgb(79, 72, 165);

        public static Color TabControlBackColor = Color.FromArgb(19, 19, 48);
        public static Color TabControlForeColor = Color.FromArgb(255, 255, 255);
        public static Color TabControlBorderColor = Color.FromArgb(51, 45, 68);
        public static Color TabControlHighlightColor = Color.FromArgb(79, 72, 165);
    }
}
