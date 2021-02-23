using System.Collections.Generic;

namespace Shotr.Core.MimeDetect.Matchers.TextSignature
{
    public class Signature
    {
        public LangTypes LangType => _langType;
        public List<string> Signatures => _signatures;
        
        private readonly List<string> _signatures;
        private readonly LangTypes _langType;
        
        public Signature(List<string> signatures, LangTypes langType)
        {
            _signatures = signatures;
            _langType = langType;
        }
    }
}