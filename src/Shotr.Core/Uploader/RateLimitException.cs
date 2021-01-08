using System;
using System.Runtime.Serialization;

namespace Shotr.Core.Uploader
{
    [Serializable]
    internal class RateLimitException : Exception
    {
        public RateLimitException()
        {
        }

        public RateLimitException(string message) : base(message)
        {
        }

        public RateLimitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RateLimitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}