using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    [Table("Members")]
    public class User
    {
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string? ProfilePicture { get; set; }

        public IList<BookShelfItem> BookShelf { get; set; }

        public IList<Review> Reviews { get; set; }
    }
}
