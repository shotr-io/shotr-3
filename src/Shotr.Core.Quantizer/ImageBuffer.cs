using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Shotr.Core.Quantizer
{
    class ImageBuffer
    {
        public ImageBuffer(Bitmap image)
        {
            Image = image;
        }

        public Bitmap Image { get; private set; }

        public IEnumerable<Pixel[]> PixelLines
        {
            get
            {
                var bitDepth = System.Drawing.Image.GetPixelFormatSize(Image.PixelFormat);
                if (bitDepth != 32)
                    throw new QuantizationException(string.Format("The image you are attempting to quantize does not contain a 32 bit ARGB palette. This image has a bit depth of {0} with {1} colors.", bitDepth, Image.Palette.Entries.Length));

                var width = Image.Width;
                var height = Image.Height;
                var buffer = new int[width];
                var pixels = new Pixel[width];
                for (var rowIndex = 0; rowIndex < height; rowIndex++)
                {
                    var data = Image.LockBits(Rectangle.FromLTRB(0, rowIndex, width, rowIndex + 1), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                    try
                    {
                        Marshal.Copy(data.Scan0, buffer, 0, width);
                        for(var pixelIndex = 0; pixelIndex < buffer.Length; pixelIndex++)
                        {
                            pixels[pixelIndex] = new Pixel(buffer[pixelIndex]);
                        }
                    }
                    finally
                    {
                        Image.UnlockBits(data);
                    }
                    yield return pixels;
                }
            }
        }

        public void UpdatePixelIndexes(IEnumerable<byte[]> lineIndexes)
        {
            var width = Image.Width;
            var height = Image.Height;
            var indexesIterator = lineIndexes.GetEnumerator();
            for (var rowIndex = 0; rowIndex < height; rowIndex++)
            {
                indexesIterator.MoveNext();
                var data = Image.LockBits(Rectangle.FromLTRB(0, rowIndex, width, rowIndex + 1), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
                try
                {
                    Marshal.Copy(indexesIterator.Current, 0, data.Scan0, width);
                }
                finally
                {
                    Image.UnlockBits(data);
                }
            }
        }
    }
}
 
