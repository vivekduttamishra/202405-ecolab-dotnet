namespace ConceptArchitect.BookManagement
{
    public class Author
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Photograph { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }

        

        public virtual IList<Book> Books { get; set; }

    }
}
