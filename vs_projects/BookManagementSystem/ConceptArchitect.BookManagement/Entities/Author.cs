using ConceptArchitect.BookManagement;
using ConceptArchitect.Utils;
using System.ComponentModel.DataAnnotations;

namespace ConceptArchitect.BookManagement
{
    public class Author
    {
        [UniqueAuthorId]
        public string? Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(5000,MinimumLength =50)]
        [WordCount(10)] 
        public string Biography { get; set; }
        public string Photograph { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }

        public DateTime? DeathDate { get; set; } //optional

        public virtual IList<Book> Books { get; set; } = new List<Book>();

    }
}
