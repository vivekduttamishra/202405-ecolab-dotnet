namespace ConceptArchitect.Collections
{
    public class DynamicArray<T> : ISequence<T>
    {
        private int factor;
        public int Capacity => array.Length;

        T[] array; 

        public DynamicArray(int capacity)
        {
            factor = capacity;
            
            array = new T[capacity];
            Count = 0;
        }

        public T this[int index] 
        {
            get 
            {
                ValidateIndex(index);
                return array[index];
            }
            set
            {
                ValidateIndex(index);
                array[index] = value;
            } 
        
        }

        void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
        }

        public int Count { get; private set; }

        public bool IsFull => Count == Capacity;

        public void Add(T value)
        {
            EnsureCapacity();
            array[Count] = value;
            Count++;
        }

        private void EnsureCapacity()
        {
            if(IsFull)
            {
                var newArray = new T[Capacity + factor];
                Array.Copy(array, newArray, Count);
                array= newArray;
                
            }
        }

        //public ISequence<int> FindIncides(X item)
        //{
        //    DblList<int> result = new DblList<int>();
        //    int i = 0;
        //    for (; i<Count;i++)
        //    {
        //        if (array[i].Equals(item))
        //            result.Add(i);
        //        i++;
        //    }

        //    return result;
        //}
    }
}