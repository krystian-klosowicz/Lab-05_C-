using System.Runtime.Serialization;

namespace lab5
{
    [Serializable]
    internal class Exception2 : Exception
    {
        public Exception2()
        {
        }

        public Exception2(string? message) : base(message)
        {
        }

        public Exception2(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected Exception2(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}