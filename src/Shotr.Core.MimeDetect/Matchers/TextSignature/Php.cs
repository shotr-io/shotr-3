namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Php : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "<?PHP",
            "<?\n",
            "<?\r",
            "<? ",
            "/usr/local/bin/php",
            "/usr/bin/php",
            "/usr/bin/env php",
            "require_once ",
            "require_once(",
            "require_once (",
            "private $",
            "public $"
        };

        public override LangTypes Lang => LangTypes.Php;
    }
}