namespace ConceptArchitect.Collections
{
    public interface ISequence<X>
    {
        X this[int index] { get; set; }

        int Count { get; }

        ISequence<X> Add(X value);
    }
}