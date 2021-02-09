namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Css : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "body {",
            "body\n{",
            "html {",
            "html\n{",
            "@font-face ",
            "@media ",
            "@import ",
            "font-family: ",
        };

        public override LangTypes Lang => LangTypes.Css;
    }
}