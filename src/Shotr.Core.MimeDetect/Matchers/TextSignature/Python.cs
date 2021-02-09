namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Python : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "/usr/bin/python",
            "/usr/local/bin/python",
            "/usr/bin/env python",
            "/usr/bin/env python",
            "def ",
        };

        public override LangTypes Lang => LangTypes.Python;
    }
}