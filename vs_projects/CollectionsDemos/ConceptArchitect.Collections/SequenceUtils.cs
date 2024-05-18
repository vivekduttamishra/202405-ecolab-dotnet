using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Collections.Utils
{
    public static class SequenceUtils
    {
        public static ISequence<T> AddMany<T>(this ISequence<T> sequence, params T[] items)
        {
            foreach(var item in items) 
                sequence.Add(item);

            return sequence;
        }

        public static void Print(this object obj)
        {
            Console.WriteLine(obj);
        }

        public static void Print<X>(this ISequence<X> sequence)
        {
            for (var i=0; i<sequence.Count;i++)
                Console.WriteLine(sequence[i]);
        }

        public static T[] ToArray<T>(this ISequence<T> sequence)
        {
            T[] array = new T[sequence.Count];
            for(var i=0; i<sequence.Count; i++)
                array[i] = sequence[i];
            return array;
        }


        public static int IndexOf<X>(this ISequence<X> sequence, X item)
        {
            
            for (var i = 0; i < sequence.Count; i++)
                if (sequence[i].Equals(item))
                    return i;
                else
                    i++;

            return -1;
        }

        public static ISequence<X> FindItems<X>(this ISequence<X> sequence, X item)
        {
            DblList<X> result = new DblList<X>();
            for (var i = 0; i < sequence.Count; i++)
                if (sequence[i].Equals(item))
                    result.Add(sequence[i]);

            return result;
        }

        public static ISequence<int> FindIndices<X>(this ISequence<X> sequence, X item)
        {
            DblList<int> result = new DblList<int>();
            
            for (var i = 0; i < sequence.Count; i++)
            {
                if (sequence[i].Equals(item))
                    result.Add(i);

            }

            return result;
        }

        public static double Average<X>(this ISequence<X> sequence)
        {
            double sum = 0;
            for (var i = 0; i < sequence.Count; i++)
                sum += 1;// sequence[i];

            return sum / sequence.Count;
        }

        
    }
}
