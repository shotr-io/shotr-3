namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Java : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "package ",
            "import java.",
            "System.out.println"
        };

        public override LangTypes Lang => LangTypes.Java;
    }
}