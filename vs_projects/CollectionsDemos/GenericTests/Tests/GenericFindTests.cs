using ConceptArchitect.BookManagement;
using ConceptArchitect.Collections;
using ConceptArchitect.Collections.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace GenericTests.Tests
{
    public class GernicFindTests
    {
        ISequence<Book> books;
        BookDb db;
        DblList<int> numbers;

        [SetUp]
        public void Setup()
        {
            db = new BookDb();
            books = db.Books;
            numbers = new DblList<int>();
            for(var i=0;i<100;i++)
                numbers.Add(i);
        }

        public Criteria<Book> ByAuthor(string author)
        {
            return book=> book.Author.ToLower().Contains(author.ToLower());
        }

		[Test]
        public void SearchBooksByAuthorReturnsMatchingBooks()
		{
            var authorName = "VIVEK";

            //var result1 = books.Find(book => book.Author.ToLower().Contains(authorName.ToLower());
            
            var result = books.Where(ByAuthor(authorName));

            for(int i=0;i<result.Count;i++)
            {
                //Assert.That(result[i].Author, Is.EqualTo(authorName));
                Assert.That(result[i].Author.ToLower().Contains("vivek"));
            }
		}


        [Test]
        public void SearchBooksByInvalidAuthorReturnsEmptyResult()
        {
            var authorName = "Invalid Author";

            var result = books.Where(ByAuthor(authorName));

            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
		public void BooksInPriceRangeReturnsMatchingBooks()
		{
            var result = books.Where(b => b.Price > 200 && b.Price < 300);

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void BooksInPriceRangeReturnsEmptyListIfNoBooksAreInRange()
        {
            var result = books.FindInPriceRange(500, 600);

            Assert.That(result.Count, Is.EqualTo(0));
        }


        [Test]
        
        public void BooksInRatingRangeReturnsMatchingBooks()
        {
            var result = books.Where(b => b.Rating < 4);

            Assert.That(result.Count, Is.EqualTo(2));
        }


        [Test]
        public void FindCanFindAllEvenNumbers()
        {
            var result = numbers.Where(n => n % 2 == 0);

            Assert.That(result.Count, Is.EqualTo(50));
        }

        [Test]
        public void FindCanFindAllPrimeNumbers()
        {
            var result = numbers.Where(NumberUtils.IsPrime);

            Assert.That(result.Count, Is.EqualTo(25));
        }

        [Test]
        public void FindCanFindAllNumbersDivisibleBy3Or5()
        {
            Criteria<int> c = n => n % 3 == 0 || n % 5 == 0;
            
            var result = numbers.Where(c);
            for (int i = 0; i < result.Count; i++)
                Assert.True(c(result[i]));
        }
    }
}
