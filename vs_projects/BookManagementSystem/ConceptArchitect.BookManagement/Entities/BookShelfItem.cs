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
        public virtual Book Book { get; set; }

        public ReadingStatus Status { get; set; }

        public int?Rating { get; set; }

        public virtual IList<BookNote> Notes { get; set; }= new List<BookNote>();
    }

    public class BookNote
    {
        public int Id { get; set; }
        
        public string Note { get; set; }

        //public virtual Book Book{ get; set; }

        public string? Location { get; set; }

    }
}
