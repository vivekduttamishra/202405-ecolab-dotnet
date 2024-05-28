using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.Csv
{
    public static class CSVWriter
    {

        public static void SaveCSV(this BookRepository repository,string filename)
        {
            using (var file = new StreamWriter(filename))
            {
                file.WriteLine($"Id,Title,Author,Price,Rating");
                var books = repository.GetAllBooks();

                for (int i = 0; i < books.Count; i++)
                {
                    var b = books[i];
                    file.WriteLine($"{b.Id},{b.Title},{b.Author},{b.Price},{b.Rating}");
                } //file is automatically closed.
            }
        }

        public static BookRepository LoadCSV(this BookRepository repository, string filename)
        {
            try
            {
                using (var file = new StreamReader(filename))
                {
                    var line = file.ReadLine(); //reads and ignore header line

                    while(true)
                    {
                        line=file.ReadLine();
                        if (line==null || line.Trim()=="")
                            break;
                        var data=line.Trim().Split(",");
                        var book = new Book()
                        {
                            Id = data[0],
                            Title = data[1],
                            Author = data[2],
                            Price = int.Parse(data[3]),
                            Rating = double.Parse(data[4])
                        };

                        repository.Add(book);


                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                //ignore if fiel doesn' exist
            }

            return repository;
        }
    }
}
