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
    internal class LINQTests
    {

        ISequence<Book> books;
        [SetUp]
        public void Init()
        {
            var db = new BookDb();
            books = db.Books;
        }

        [Test]
        public void ConverterCanConvertListOfBooksToListOfTitles()
        {
            // var result = books.Select(b => b.Title);

            var result = from b in books select b.Title;


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
            //var result = books.Select(book => new 
            //{ 
            //    Title = book.Title.ToUpper(), 
            //    Price = book.Price 
            //});

            var discountedBooks = from b in books
                         select new { Title = b.Title.ToUpper(), Price = b.Price*.8 };


            Assert.That(discountedBooks[0].GetType() != typeof(Book));
            for (var i = 0; i < discountedBooks.Count; i++)
            {
                Assert.That(discountedBooks[i].Title, Is.EqualTo(books[i].Title.ToUpper()));
                Assert.That(discountedBooks[i].Price, Is.EqualTo(books[i].Price * 0.8));
            }
        }

        [Test]
        public void WeCanFindThePriceOfAllBooksByAGivenAuthor()
        {
            //var result = books
            //                .Where(b => b.Author == "Vivek Dutta Mishra") //get books by author
            //                .Select(b => b.Price); //convert to sequence of double


            var result = from b in books
                         where b.Author == "Vivek Dutta Mishra"
                         select b.Price;



            Assert.That(result[0], Is.EqualTo(399)); //The Accursed God
            Assert.That(result[1], Is.EqualTo(199)); //Manas


        }


        [Test]
        public void WeCanFindTheAveragePriceOfBooksByAParticularAuthor()
        {
            //var result = books
            //                .Where(b => b.Author == "Vivek Dutta Mishra") //get books by author
            //                .Select(b => b.Price) //convert to sequence of double
            //                .Average();                  //average double using standard /*mechanism*/

            var result = (from b in books
                          where b.Author == "Vivek Dutta Mishra"
                          select b.Price).Average();
                         

            Assert.That(result, Is.EqualTo(299));


        }
    }
}
