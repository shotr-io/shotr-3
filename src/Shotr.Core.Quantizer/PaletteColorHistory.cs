﻿using System.Drawing;

namespace Shotr.Core.Quantizer
{
    struct PaletteColorHistory
    {
        public int Alpha;
        public int Red;
        public int Green;
        public int Blue;
        public int Sum;

        public Color ToNormalizedColor()
        {
            return (Sum != 0) ? Color.FromArgb(Alpha /= Sum, Red /= Sum, Green /= Sum, Blue /= Sum) : Color.Empty;
        }

        public void AddPixel(Pixel pixel)
        {
            Alpha += pixel.Alpha;
            Red += pixel.Red;
            Green += pixel.Green;
            Blue += pixel.Blue;
            Sum++;
        }
    }
}
