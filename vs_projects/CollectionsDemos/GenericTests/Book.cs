using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTests
{
    public class Book:ISellable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public double Rating { get; set; }
    }
}
