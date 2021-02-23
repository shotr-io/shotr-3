namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Cpp : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "#include <iostream>",
            "std::cout",
            "cout <<",
        };

        public override LangTypes Lang => LangTypes.Cpp;
    }
}