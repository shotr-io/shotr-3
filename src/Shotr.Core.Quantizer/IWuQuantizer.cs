using System.Drawing;

namespace Shotr.Core.Quantizer
{
    public interface IWuQuantizer
    {
        Image QuantizeImage(Bitmap image, int alphaThreshold, int alphaFader);
    }
}