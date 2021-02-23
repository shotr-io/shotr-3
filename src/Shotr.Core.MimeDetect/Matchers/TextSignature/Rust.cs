namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Rust : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "#[derive(Debug)]",
            "pub enum",
            "match ",
            "&'a ",
            " -> Self",
            "fn main()",
        };

        public override LangTypes Lang => LangTypes.Rust;
    }
}