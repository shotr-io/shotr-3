namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public abstract class BaseTextSignature
    {
        public abstract string[] Signatures { get; }
        public abstract LangTypes Lang { get; }
    }

    public enum LangTypes
    {
        Bash,
        Cpp,
        C,
        Cs,
        Css,
        Go,
        Html,
        Java,
        Js,
        Lua,
        Perl,
        Php,
        Python,
        Rust,
        VisualBasic,
        Xml,
    }
}