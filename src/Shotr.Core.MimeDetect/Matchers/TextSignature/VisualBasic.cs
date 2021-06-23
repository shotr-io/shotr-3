namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class VisualBasic : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "Imports System",
            "Public Class Program",
            "Dim ",
        };

        public override LangTypes Lang => LangTypes.VisualBasic;
    }
}