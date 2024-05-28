
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public double Rating { get; set; }

        public override bool Equals(object? obj)
        {
            var b2= obj as Book;
            if (b2==null)
                return false;
            
            return  Id==b2.Id && 
                    Title==b2.Title && 
                    Author==b2.Author && 
                    Price==b2.Price && 
                    Rating==b2.Rating;
        }
    }
}
