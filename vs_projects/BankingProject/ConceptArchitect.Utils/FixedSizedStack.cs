

using System.Data.SqlTypes;

namespace ConceptArchitect.Utils
{
    public class FixedSizedStack
    {
        int[] items;

        //bool empty = true;
        public  bool IsEmpty
        {
            get { return Count == 0; }
        }

        public bool IsFull
        {
            get { return Count == Size; }
        }

        public int Count
        {
            get; private set;
        }

        //public int Size { get; private set; }

        public int Size { get { return items.Length; } }

        public FixedSizedStack(int size)
        {
            //Size = size;
            items = new int[size];
        }

        int pushed;
        public bool Push(int value)
        {
            if (IsFull)
                return false;

            //empty = false;
            items[Count] = value;
            Count++;
            //pushed= value;
            return true;
        }

        public bool Pop(out int result)
        {
            result = 0;

            if (IsEmpty)
                return false;

            //result = pushed;

            Count--;
            result = items[Count];
            return true;
        }
    }
}