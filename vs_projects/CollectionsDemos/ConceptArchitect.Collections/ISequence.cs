namespace ConceptArchitect.Collections
{
    public interface ISequence<X>
    {
        X this[int index] { get; set; }

        int Count { get; }

        void Add(X value);
    }
}