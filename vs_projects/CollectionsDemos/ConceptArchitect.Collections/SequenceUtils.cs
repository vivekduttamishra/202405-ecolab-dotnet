using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Collections.Utils
{
    public delegate bool Criteria<T>(T item);
    public delegate double DoubleExtractor<T>(T item);

    public delegate O Converter<I,O>(I item);

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

        public static double Average<X>(this ISequence<X> items,DoubleExtractor<X> ToDouble=null)
        {
            if (ToDouble == null)
                ToDouble = x => Convert.ToDouble(x);

            double sum = 0;
            for (var i = 0; i < items.Count; i++)
                sum += ToDouble(items[i]); //items[i];

            return sum / items.Count;
        }

        public static ISequence<O> Select<I,O>(this ISequence<I> items,Converter<I,O> converter)
        {
            var result= new DblList<O>();
            for(int i=0; i<items.Count; i++)
            {
                O o = converter(items[i]); 
                result.Add(o);
            }

            return result;
        }

        
        public static ISequence<T> Where<T>(this ISequence<T> items, Criteria<T> match=null)
        {

            if (match == null)
                match = x => true;



            var result = new DblList<T>();
            for (var i = 0; i < items.Count; i++)
            {
                if (match(items[i]))
                    result.Add(items[i]);
            }                

            return result;
        }


    }
}
