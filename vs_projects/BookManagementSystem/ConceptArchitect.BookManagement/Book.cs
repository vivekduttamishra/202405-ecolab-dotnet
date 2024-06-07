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
        public string Price { get; set; }

        public virtual Author Author { get; set; }

        public string Description { get; set; }

        public string CoverPage { get; set; }

        public double Rating { get; set; }  


    }
}
