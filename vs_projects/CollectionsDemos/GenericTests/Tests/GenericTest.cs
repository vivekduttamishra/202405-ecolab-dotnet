using ConceptArchitect.BookManagement;

namespace GenericTests.Tests
{
    public class GenericTests
    {
        Book book = new Book()
        {
            Title = "The Accursed God",
            Author = "Vivek Dutta Mishra",
            Price = 399,
            Rating = 4.6
        };

        Bike bike = new Bike("Honda", "Splendor", 45000);

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetIdReturnsTheHashCodeOfAnObject()
        {


            var id = GenericHelper.GetId(book);

            Assert.That(id, Is.EqualTo(book.GetHashCode()));
        }

        [Test]
        public void GetDescriptionReturnsToStringOfObject()
        {
            var description = GenericHelper.GetDescription(book);
        }

        [Test]
        public void EqualsComparesTwoObjectsForEquality()
        {
            Assert.True(GenericHelper.Equals(20, 20));
        }

        [Test]
        public void EqualsCanComparesIntAndDoubleWithDifferentValues()
        {
            Assert.False(GenericHelper.Equals(20, 20.5));
        }

        [Test]
        public void EqualsCantComparesDiffentTypeOfObject()
        {

            Assert.False(Equals(bike, book));
        }

        [Test]
        public void CreateObjectCreatesTheObjectOfClassesWithZeroArgumentConstructor()
        {
            var book = GenericHelper.CreateObject<Book>();

            Assert.That(book, Is.InstanceOf<Book>());
        }

        [Test]
        [Ignore("Will Not work. This is just documentation")]
        public void CreateObjectCanNotCreatesTheObjectOfClassesWithoutZeroArgumentConstructor()
        {
            // var bike = GenericHelper.CreateObject<Bike>();


        }

        [Test]
        public void FindFirstInBudgetItemCanReturnFirstItemWithPriceLessOrEqualToBudget()
        {
            var budget = 200;

            var book = GenericHelper.FindFirstInBudget(budget,
                    new Book() { Title = "A", Price = 300 },
                    new Book() { Title = "B", Price = 190 },
                    new Book() { Title = "C", Price = 200 },
                    new Book() { Title = "D", Price = 90 },
                    new Book() { Title = "E", Price = 100 }
                    );


            Assert.That(book.Title, Is.EqualTo("B"));


        }


    }
}