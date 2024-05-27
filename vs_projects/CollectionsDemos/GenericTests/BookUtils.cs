using ConceptArchitect.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public static class BookUtils
    {
        public static ISequence<Book> FindByAuthor(this ISequence<Book>books, string authorName)
        {
            var result = new DblList<Book>();

            for(var i=0;  i<books.Count; i++)
            {
                if (books[i].Author==authorName)
                    result.Add(books[i]);
            }

            return result;
        }

        public static ISequence<Book> FindInPriceRange(this ISequence<Book> books, int min, int max )
        {
            var result = new DblList<Book>();
            for(var i=0;i<books.Count;i++)
            {
                if (books[i].Price>=min  && books[i].Price<max)
                    result.Add(books[i]);
            }
            return result;
        }
    }
}
