namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Js : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "/bin/node",
            "/usr/bin/node",
            "/bin/nodejs",
            "/usr/bin/nodejs",
            "/usr/bin/env node",
            "/usr/bin/env nodejs",
        };

        public override LangTypes Lang => LangTypes.Js;
    }
}