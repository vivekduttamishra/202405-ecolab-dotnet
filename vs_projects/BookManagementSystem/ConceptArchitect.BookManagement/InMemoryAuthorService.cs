using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class InMemoryAuthorService : IAuthorService
    {
        Dictionary<string,Author> authors= new Dictionary<string,Author>();

        public async Task<Author> AddAuthor(Author author)
        {
            await Task.CompletedTask;
            if (author == null)
                throw new InvalidEntityException("No Author Found");

            if (string.IsNullOrEmpty(author.Name))
                throw new InvalidEntityException("Name is Required");

            if(string.IsNullOrEmpty(author.Id))
                author.Id=string.Join("-",author.Name.ToLower().Split());
            else
                author.Id=author.Id.ToLower();

            if (authors.ContainsKey(author.Id))
                throw new DuplicateIdException($"Duplicate Id {author.Id}");

            authors[author.Id.ToLower()] = author;
            return author;
        }

        public async Task DeleteAuthor(string id)
        {
            await GetAuthorById(id);
            authors.Remove(id);
        }

        public async Task<Author> GetAuthorById(string id)
        {
            await Task.CompletedTask;

            if (authors.ContainsKey(id.ToLower()))
                return authors[id.ToLower()];
            else
                throw new InvalidEntityException($"Author Not found: {id}");
        }

        public async Task<IList<Author>> GetAuthors()
        {
            await Task.CompletedTask;
            return authors.Values.ToList();
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            var id = author.Id.ToLower();
            var a = await GetAuthorById(id);
            authors[id] = author;
            return author;
        }

    }
}
