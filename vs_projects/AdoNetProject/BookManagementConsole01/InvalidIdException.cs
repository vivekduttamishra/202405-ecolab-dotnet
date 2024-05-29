using System.Runtime.Serialization;

namespace BookManagementConsole01
{
    [Serializable]
    internal class InvalidIdException<T> : Exception
    {
        public T Id { get; set; }
        
        public InvalidIdException(T id,string? message) : base(message)
        {
            Id = id;
        }

       
    }
}