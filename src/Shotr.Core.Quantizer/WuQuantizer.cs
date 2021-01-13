﻿using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Shotr.Core.Quantizer
{
    public class WuQuantizer : WuQuantizerBase, IWuQuantizer
    {
        private static IEnumerable<byte[]> IndexedPixels(ImageBuffer image, Pixel[] lookups, int alphaThreshold, PaletteColorHistory[] paletteHistogram)
        {
            var lineIndexes = new byte[image.Image.Width];
            var lookup = new PaletteLookup(lookups);
            foreach (var pixelLine in image.PixelLines)
            {
                for (var pixelIndex = 0; pixelIndex < pixelLine.Length; pixelIndex++)
                {
                    var pixel = pixelLine[pixelIndex];
                    var bestMatch = AlphaColor;
                    if (pixel.Alpha > alphaThreshold)
                    {
                        bestMatch = lookup.GetPaletteIndex(pixel);
                        paletteHistogram[bestMatch].AddPixel(pixel);
                    }
                    lineIndexes[pixelIndex] = bestMatch;
                }
                yield return lineIndexes;
            }
        }

        internal override Image GetQuantizedImage(ImageBuffer image, int colorCount, Pixel[] lookups, int alphaThreshold)
        {
            var result = new Bitmap(image.Image.Width, image.Image.Height, PixelFormat.Format8bppIndexed);
            var resultBuffer = new ImageBuffer(result);
            var paletteHistogram = new PaletteColorHistory[colorCount + 1];
            resultBuffer.UpdatePixelIndexes(IndexedPixels(image, lookups, alphaThreshold, paletteHistogram));
            result.Palette = BuildPalette(result.Palette, paletteHistogram);
            paletteHistogram = null;
            resultBuffer = null;
            return result;
        }

        private static ColorPalette BuildPalette(ColorPalette palette, PaletteColorHistory[] paletteHistogram)
        {
            for (var paletteColorIndex = 0; paletteColorIndex < paletteHistogram.Length; paletteColorIndex++)
            {
                palette.Entries[paletteColorIndex] = paletteHistogram[paletteColorIndex].ToNormalizedColor();
            }
            return palette;
        }
    }
}
