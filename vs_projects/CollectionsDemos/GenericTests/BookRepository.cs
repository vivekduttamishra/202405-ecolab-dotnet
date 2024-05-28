using ConceptArchitect.Collections;
using ConceptArchitect.Collections.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    class BookRepository
    {
        public ISequence<Book> Books { get; private set; }

        public BookRepository()
        {
            Books = new DblList<Book>();

            Add(new Book()
            {
                Title = "The Accursed God",
                Author = "Vivek Dutta Mishra",
                Price = 399,
                Rating = 4.6
            }) //returns Books
            .Add(new Book()
            {
                Title = "Manas",
                Author = "Vivek Dutta Mishra",
                Price = 199,
                Rating = 4.5
            })
            .Add(new Book()
            {
                Title = "Asura",
                Author = "Anant Neelkanthan",
                Price = 299,
                Rating = 3.8
            })
            .Add(new Book()
            {
                Title = "Ajaya",
                Author = "Anant Neelkanthan",
                Price = 249,
                Rating = 3.4
            })                   
            .Add(new Book()
            {
                Title = "Rashmirathi",
                Author = "Ramdhari Singh Dinkar",
                Price = 99,
                Rating = 4.8
            });

           



        }
    
        public BookRepository Add(params Book[] books)
        {
            foreach (var book in books)
            {
                if (string.IsNullOrEmpty(book.Id))
                    book.Id =string.Join('-', book.Title.ToLower().Split(' '));
                Books.Add(book);
            }
            return this;
        }

        public Book GetById(string id)
        {
            return (
                    from b in Books
                    where b.Id == id
                    select b
                   ).FirstOrDefault(); //default-->null if not found
        }

        public Book GetBookByTitle(string title)
        {
            return Books.FirstOrDefault(b=>b.Title.ToLower()==title.ToLower());
        }

       
    
    
    }
}
