using ConceptArchitect.BookManagement.Csv;
using System.ComponentModel.DataAnnotations;

namespace ConceptArchitect.BookManagement
{
    public class CSVRepositoryTests
    {
        BookRepository rep;
        string filename = "books_test.csv";

        [SetUp]
        public void Setup()
        {
            rep = new BookRepository();
            var f= new FileInfo(filename);
            if(f.Exists)
            {
                f.Delete();
            }
        }

        [Test]
        public void NewRepositoryShouldBeEmpty()
        {
            Assert.That(rep.Count, Is.EqualTo(0));
        }


        [Test]
        public void AddSampleDataCanAddSampleBooks()
        {
            rep.AddSampleData();
            Assert.That(rep.Count,Is.GreaterThan(0));
        }

        [Test]
        public void LoadCsvWorksEvenWithNonExistingFile()
        {
            Assume.That(File.Exists(filename), Is.False);

            rep.LoadCSV(filename);
            Assert.That(rep.Count, Is.EqualTo(0));
        }

        [Test]
        public void SaveCsvCanSaveTheRecordInAFile()
        {
            rep.AddSampleData();
            rep.SaveCSV(filename);
            
            //What should be our assert
            //Check if the file is created

            Assert.That(File.Exists(filename));

        }

        [Test]
        public void LoadCanLoadBooksFromExistingRepository()
        {
            //Arrange
            rep.AddSampleData();
            rep.SaveCSV(filename);

            //Act
            var rep2=new BookRepository();
            Assume.That(rep2.Count == 0);
            rep2.LoadCSV(filename); //load records

            var originalBooks = rep.GetAllBooks();
            var loadedBooks = rep2.GetAllBooks();

            for(int i = 0; i < rep.Count; i++) 
            {
                Assert.That(loadedBooks[i], Is.EqualTo(originalBooks[i]));
            }

        }
    }
}