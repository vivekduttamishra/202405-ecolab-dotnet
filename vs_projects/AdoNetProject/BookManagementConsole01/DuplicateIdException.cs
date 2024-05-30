namespace BookManagementConsole01
{
    internal class DuplicateIdException<T> : Exception
    {
        public T Id { get; private set; }

        public DuplicateIdException(T id, string message, Exception innerException) : base(message, innerException)
        {
            Id = id;
        }
    }
}