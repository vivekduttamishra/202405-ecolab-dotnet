using System.Runtime.Serialization;

namespace HelloWeb.Services
{
    [Serializable]
    internal class EntityNotFoundException : Exception
    {
        private string id;
        private string message;

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string? message) : base(message)
        {
        }

        public EntityNotFoundException(string id, string message):base(message)
        {
            this.id = id;
           
        }

        public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}