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
   

    public class AverageTests
    {
        ISequence<int> numbers;
        ISequence<Book> books;
        ISequence<Horse> horses;

        [SetUp]
        public void Init()
        {
            numbers = new DblList<int>().AddMany(1, 2, 3, 4);
            var db = new BookDb();
            books = db.Books;
            horses = new DblList<Horse>()
                    .AddMany(
                        new Horse() { Speed=40, Age=10, Price=200000},
                        new Horse() { Speed=50, Age=12, Price=150000},
                        new Horse() { Speed=60, Age=8, Price=250000}
                    );


        }

        [Test]
        public void WeCanAverageHorsesOnPrice()
        {
            var avgPrice = horses.Average(h => h.Price);

            Assert.That(avgPrice, Is.EqualTo(200000));
        }

        [Test]
        public void WeCanAverageHorsesOnAge()
        {
            var avgPrice = horses.Average(h => h.Age);

            Assert.That(avgPrice, Is.EqualTo(10));
        }

        [Test]
        public void WeCanAverageHorsesOnSpeed()
        {
            var avgPrice = horses.Average(h => h.Speed);

            Assert.That(avgPrice, Is.EqualTo(50));
        }

        [Test]
        public void WeCanAverageBookOnPrice()
        {
            var avgPrice = books.Average(b => b.Price);

            Assert.That(avgPrice, Is.EqualTo(249));
        }

        [Test]
        public void WeCanAverageBooksOnRating()
        {
            var avgPrice = books.Average(b => b.Rating);

            Assert.That(avgPrice, Is.EqualTo(4.22));
        }


        [Test]
        public void WeCanAverageListOfNumbers()
        {
            var avg = numbers.Average(n=>n);

            Assert.That(avg, Is.EqualTo(2.5));
        }
    }
}
