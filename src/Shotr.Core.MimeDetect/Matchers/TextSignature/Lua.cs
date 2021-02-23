namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Lua : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "/usr/bin/lua",
            "/usr/local/bin/lua",
            "/usr/bin/env lua",
        };

        public override LangTypes Lang => LangTypes.Lua;
    }
}