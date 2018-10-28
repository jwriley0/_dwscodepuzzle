using System;
using System.Runtime.Serialization;

namespace Dws.CodePuzzle.Core
{
    [Serializable]
    internal class InvalidShapeException : Exception
    {
        public InvalidShapeException()
        {
        }

        public InvalidShapeException(string message) : base(message)
        {
        }

        public InvalidShapeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidShapeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}