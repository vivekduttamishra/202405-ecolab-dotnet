using ConceptArchitect.BookManagement;
using ConceptArchitect.Collections;
using ConceptArchitect.Collections.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTests.Tests
{
    internal class ExtensionMethodTests
    {

        ISequence<Book> books;
        [SetUp]
        public void Init()
        {
            var db = new BookRepository();
            books = db.Books;
        }

        [Test]
        public void ConverterCanConvertListOfBooksToListOfTitles()
        {
            var result = books.Select(b => b.Title);

            Assert.That(result, Is.InstanceOf<ISequence<string>>());
            Assert.That(result.Count, Is.EqualTo(books.Count));
            for(var i=0;i<books.Count;i++)
            {
                Assert.That(result[i], Is.EqualTo(books[i].Title));
            }
        }

        [Test]
        public void ConverterCanConvertListOfBooksToListOfCustomObjectHavingUpperTitleAndPrice()
        {
            var result = books.Select(book => new 
            { 
                Title = book.Title.ToUpper(), 
                Price = book.Price 
            });


            Assert.That(result[0].GetType() != typeof(Book));
            for (var i = 0; i < result.Count; i++)
                Assert.That(result[0].Title, Is.EqualTo(books[0].Title.ToUpper()));
        }

        [Test]
        public void WeCanFindThePriceOfAllBooksByAGivenAuthor()
        {
            var result = books
                            .Where(b => b.Author == "Vivek Dutta Mishra") //get books by author
                            .Select(b => b.Price); //convert to sequence of double

            Assert.That(result[0], Is.EqualTo(399)); //The Accursed God
            Assert.That(result[1], Is.EqualTo(199)); //Manas


        }


        [Test]
        public void WeCanFindTheAveragePriceOfBooksByAParticularAuthor()
        {
            var result = books
                            .Where(b => b.Author == "Vivek Dutta Mishra") //get books by author
                            .Select(b => b.Price) //convert to sequence of double
                            .Average();                  //average double using standard mechanism

            Assert.That(result, Is.EqualTo(299));


        }
    }
}
