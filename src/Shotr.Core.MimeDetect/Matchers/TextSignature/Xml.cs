namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Xml : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "<?XML",
        };

        public override LangTypes Lang => LangTypes.Xml;
    }
}