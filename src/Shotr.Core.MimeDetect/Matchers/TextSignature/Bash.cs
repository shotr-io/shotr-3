namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Bash : BaseTextSignature
    {
        public override string[] Signatures => new[]
        {
            "/bin/sh",
            "/bin/bash",
            "/usr/bin/env sh",
            "/usr/bin/env bash"
        };
        public override LangTypes Lang => LangTypes.Bash;
    }
}