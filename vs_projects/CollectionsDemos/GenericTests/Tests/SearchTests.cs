using ConceptArchitect.BookManagement;
using ConceptArchitect.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace GenericTests.Tests
{
    public class SearchTests
    {
        ISequence<Book> books;
        BookRepository db;
        DblList<int> numbers;

        [SetUp]
        public void Setup()
        {
            db = new BookRepository();
            books = db.Books;
            numbers = new DblList<int>();
            for(var i=0;i<100;i++)
                numbers.Add(i);
        }


		[Test]
        public void SearchBooksByAuthorReturnsMatchingBooks()
		{
            var authorName = "Vivek Dutta Mishra";

            var result = books.FindByAuthor( authorName);

            for(int i=0;i<result.Count;i++)
            {
                Assert.That(result[i].Author, Is.EqualTo(authorName));
            }
		}


        [Test]
        public void SearchBooksByInvalidAuthorReturnsEmptyResult()
        {
            var authorName = "Invalid Author";

            var result = books.FindByAuthor( authorName);

            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
		public void BooksInPriceRangeReturnsMatchingBooks()
		{
            var result = books.FindInPriceRange(200, 300);

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void BooksInPriceRangeReturnsEmptyListIfNoBooksAreInRange()
        {
            var result = books.FindInPriceRange(500, 600);

            Assert.That(result.Count, Is.EqualTo(0));
        }


        [Test]
        [Ignore("Not Yet Implemented")]
        public void BooksInRatingRangeReturnsMatchingBooks()
        {
            Assert.Fail("Not Yet Implemented");
        }


        [Test]
        public void FindCanFindAllEvenNumbers()
        {
            var result = numbers.FindEvens();

            Assert.That(result.Count, Is.EqualTo(50));
        }

        [Test]
        public void FindCanFindAllPrimeNumbers()
        {
            var result = numbers.FindPrimes();

            Assert.That(result.Count, Is.EqualTo(25));
        }

        [Test]
        public void FindCanFindAllNumbersDivisibleBy3Or5()
        {
            var result = numbers.FindDivisibleBy3Or5();
            for (int i = 0; i < result.Count; i++)
                Assert.True(result[i] % 3 == 0 || result[i] % 5 == 0);
        }
    }
}
