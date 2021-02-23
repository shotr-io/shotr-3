namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Perl : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "/usr/bin/perl",
            "/usr/bin/env perl",
            "/usr/bin/env perl",
        };

        public override LangTypes Lang => LangTypes.Perl;
    }
}