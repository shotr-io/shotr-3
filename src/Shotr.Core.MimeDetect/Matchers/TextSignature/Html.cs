namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Html : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "<!DOCTYPE HTML",
            "<HTML",
            "<HEAD",
            "<SCRIPT",
            "<IFRAME",
            "<H1",
            "<DIV",
            "<FONT",
            "<TABLE",
            "<A",
            "<STYLE",
            "<TITLE",
            "<B",
            "<BODY",
            "<BR",
            "<P",
            "<!--",
        };

        public override LangTypes Lang => LangTypes.Html;
    }
}