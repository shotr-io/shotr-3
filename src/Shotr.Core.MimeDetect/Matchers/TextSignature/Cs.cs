namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Cs : BaseTextSignature
    {
        public override string[] Signatures => new[]{
            "using System;",
            "using System",
            "public class ",
            "namespace ",
        };

        public override LangTypes Lang => LangTypes.Cs;
    }
}