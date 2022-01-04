﻿using System.Drawing;
using System.Drawing.Text;
using Shotr.Core.Properties;

namespace Shotr.Core.Image
{
    public class ImageManipulation
    {
		private const int minSize = 16;
        public static Icon ImageStatus(int progress, float dpiScalingFactor)
        {
			var size = (int)(minSize * dpiScalingFactor);
			try {
	            using (var bmp = new Bitmap(size, size))
	            using (var g = Graphics.FromImage(bmp))
	            {
	                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

	                g.Clear(Color.FromArgb(0, 174, 219));

	                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
	                {
	                    g.DrawString(progress.ToString(), new Font("Arial", 7, FontStyle.Bold), Brushes.White, 8, 8, sf);
	                }

	                try
	                {
	                    return Icon.FromHandle(bmp.GetHicon());
	                }
	                catch
	                {
	                    bmp.Dispose();
	                    return Resources.shotr_icon;
	                }
	            }
			}
			catch {
                return Resources.shotr_icon;
			}
        }

        public static Icon DefaultImage()
        {
            return Resources.shotr_icon;
        }
    }
}
