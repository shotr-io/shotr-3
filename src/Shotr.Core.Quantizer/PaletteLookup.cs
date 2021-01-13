using System;
using System.Collections.Generic;
using System.Linq;

namespace Shotr.Core.Quantizer
{
    class PaletteLookup
    {
        private int mMask;
        private Dictionary<int, LookupNode[]> mLookup;
        private LookupNode[] Palette { get; set; }

        public PaletteLookup(Pixel[] palette)
        {
            Palette = new LookupNode[palette.Length];
            for(var paletteIndex = 0; paletteIndex < palette.Length; paletteIndex++)
            {
                Palette[paletteIndex] = new LookupNode{Pixel = palette[paletteIndex], PaletteIndex = (byte)paletteIndex};
            }
            BuildLookup(palette);
        }

        public byte GetPaletteIndex(Pixel pixel)
        {
            var pixelKey = pixel.Argb & mMask;
            LookupNode[] bucket;
            if (!mLookup.TryGetValue(pixelKey, out bucket))
            {
                bucket = Palette;
            }

            if (bucket.Length == 1)
            {
                return bucket[0].PaletteIndex;
            }

            var bestDistance = int.MaxValue;
            byte bestMatch = 0;
            foreach(var lookup in bucket)
            {
                var lookupPixel = lookup.Pixel;

                var deltaAlpha = pixel.Alpha - lookupPixel.Alpha;
                var distance = deltaAlpha * deltaAlpha;

                var deltaRed = pixel.Red - lookupPixel.Red;
                distance += deltaRed * deltaRed;

                var deltaGreen = pixel.Green - lookupPixel.Green;
                distance += deltaGreen * deltaGreen;

                var deltaBlue = pixel.Blue - lookupPixel.Blue;
                distance += deltaBlue * deltaBlue;

                if (distance >= bestDistance)
                    continue;

                bestDistance = distance;
                bestMatch = lookup.PaletteIndex;
            }

            if ((bucket == Palette) && (pixelKey != 0))
            {
                mLookup[pixelKey] = new[] { bucket[bestMatch] };
            }
            
            return bestMatch;
        }

        private void BuildLookup(Pixel[] palette)
        {
            var mask = GetMask(palette);
            var tempLookup = new Dictionary<int, List<LookupNode>>();
            foreach (var lookup in Palette)
            {
                var pixelKey = lookup.Pixel.Argb & mask;

                List<LookupNode> bucket;
                if (!tempLookup.TryGetValue(pixelKey, out bucket))
                {
                    bucket = new List<LookupNode>();
                    tempLookup[pixelKey] = bucket;
                }
                bucket.Add(lookup);
            }

            mLookup = new Dictionary<int, LookupNode[]>(tempLookup.Count);
            foreach (var key in tempLookup.Keys)
            {
                mLookup[key] = tempLookup[key].ToArray();
            }
            mMask = mask;
        }

        private static int GetMask(Pixel[] palette)
        {
            var alphas = from pixel in palette
                         select pixel.Alpha;
            var maxAlpha = alphas.Max();
            var uniqueAlphas = alphas.Distinct().Count();

            var reds = from pixel in palette
                       select pixel.Red;
            var maxRed = reds.Max();
            var uniqueReds = reds.Distinct().Count();

            var greens = from pixel in palette
                         select pixel.Green;
            var maxGreen = greens.Max();
            var uniqueGreens = greens.Distinct().Count();

            var blues = from pixel in palette
                        select pixel.Blue;
            var maxBlue = blues.Max();
            var uniqueBlues = blues.Distinct().Count();

            double totalUniques = uniqueAlphas + uniqueReds + uniqueGreens + uniqueBlues;

            var AvailableBits = 1.0 + Math.Log(uniqueAlphas * uniqueReds * uniqueGreens * uniqueBlues);

            var alphaMask = ComputeBitMask(maxAlpha, Convert.ToInt32(Math.Round(uniqueAlphas / totalUniques * AvailableBits)));
            var redMask = ComputeBitMask(maxRed, Convert.ToInt32(Math.Round(uniqueReds / totalUniques * AvailableBits)));
            var greenMask = ComputeBitMask(maxGreen, Convert.ToInt32(Math.Round(uniqueGreens / totalUniques * AvailableBits)));
            var blueMask = ComputeBitMask(maxAlpha, Convert.ToInt32(Math.Round(uniqueBlues / totalUniques * AvailableBits)));

            var maskedPixel = new Pixel(alphaMask, redMask, greenMask, blueMask);
            return maskedPixel.Argb;
        }

        private static byte ComputeBitMask(byte max, int bits)
        {
            byte mask = 0;

            if (bits != 0)
            {
                var highestSetBitIndex = HighestSetBitIndex(max);


                for (var i = 0; i < bits; i++)
                {
                    mask <<= 1;
                    mask++;
                }

                for (var i = 0; i <= highestSetBitIndex - bits; i++)
                {
                    mask <<= 1;
                }
            }
            return mask;
        }

        private static byte HighestSetBitIndex(byte value)
        {
            byte index = 0;
            for (var i = 0; i < 8; i++)
            {
                if (0 != (value & 1))
                {
                    index = (byte)i;
                }
                value >>= 1;
            }
            return index;
        }

        private struct LookupNode
        {
            public Pixel Pixel;
            public byte PaletteIndex;
        }
    }
}
