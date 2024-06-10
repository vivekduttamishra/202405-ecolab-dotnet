using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class Review
    {
        public int Id { get; set; }
        public User User { get; set; }

        public Book Book { get; set; }

        public int Rating { get; set; }

        public string ReviewTitle { get; set; }

        public string ReviewDetails { get; set;}
    }
}
