using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }

        [Range(0,5000)]
        public string Price { get; set; }

        public virtual Author Author { get; set; }

        [StringLength(2000,MinimumLength =50)]
        public string Description { get; set; }

        public string CoverPhoto { get; set; }

        [Range(1,5)]
        public double Rating { get; set; }

        public IList<Review> Reviews { get; set; }

        public IList<BookNote> Notes { get; set; }
    }
}
