using GenericTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class Book:ISellable
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
        public int Price { get; set; }
        public double Rating { get; set; }
    }
}
