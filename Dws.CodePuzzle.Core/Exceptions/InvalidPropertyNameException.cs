using System;
using System.Runtime.Serialization;

namespace Dws.CodePuzzle.Core
{
    [Serializable]
    internal class InvalidPropertyNameException : Exception
    {
        public InvalidPropertyNameException()
        {
        }

        public InvalidPropertyNameException(string message) : base(message)
        {
        }

        public InvalidPropertyNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPropertyNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}