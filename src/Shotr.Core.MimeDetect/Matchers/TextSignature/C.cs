namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class C : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "#include <stdio.h>",
            "#include <stdlib.h>",
            "int main(int argc, char *argv[])",
            "int main("
        };

        public override LangTypes Lang => LangTypes.C;
    }
}