using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public enum ReadingStatus { WantToRead, Reading, Read, Abandoned}
    public class BookShelfItem
    {
        public int Id { get; set; }
        public Book Book { get; set; }

        public ReadingStatus Status { get; set; }

        public int?Rating { get; set; }

        public IList<BookNote> Notes { get; set; }
    }

    public class BookNote
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Note { get; set; }

        public string? Location { get; set; }

    }
}
