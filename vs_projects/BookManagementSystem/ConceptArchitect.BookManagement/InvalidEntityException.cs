﻿using System.Runtime.Serialization;

namespace ConceptArchitect.BookManagement
{
    [Serializable]
    internal class InvalidEntityException : Exception
    {
        public InvalidEntityException()
        {
        }

        public InvalidEntityException(string? message) : base(message)
        {
        }

        public InvalidEntityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}