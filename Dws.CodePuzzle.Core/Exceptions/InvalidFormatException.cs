﻿using System;
using System.Runtime.Serialization;

namespace Dws.CodePuzzle.Core
{
    [Serializable]
    internal class InvalidFormatException : Exception
    {
        public InvalidFormatException()
        {
        }

        public InvalidFormatException(string message) : base(message)
        {
        }

        public InvalidFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}