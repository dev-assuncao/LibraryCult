using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCult.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public Author()
        {
        }

        public Author(int idAuthor, string name, DateTime birthDate, string descrition)
        {
            AuthorId = idAuthor;
            Name = name;
            BirthDate = birthDate;
            Description = descrition;
        }

        public int TotalBooks(string name)
        {
            return Books.Where(x => x.Author.Name == name).Sum(x => x.Amount);
        }
    }
}
