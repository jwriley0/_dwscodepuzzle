using System;
using System.Runtime.Serialization;

namespace Dws.CodePuzzle.Core
{
    [Serializable]
    internal class InvalidPropertyActionException : Exception
    {
        public InvalidPropertyActionException()
        {
        }

        public InvalidPropertyActionException(string message) : base(message)
        {
        }

        public InvalidPropertyActionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPropertyActionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}