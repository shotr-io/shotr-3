namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Go : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "func Main(",
            "import fmt",
            "package ",
        };

        public override LangTypes Lang => LangTypes.Go;
    }
}