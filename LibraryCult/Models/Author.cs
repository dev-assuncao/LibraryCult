using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCult.Models
{
    public class Author
    {
        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

        public Author()
        {
        }

        public Author(int idAuthor, string name, DateTime birthDate, string descrition)
        {
            IdAuthor = idAuthor;
            Name = name;
            BirthDate = birthDate;
            Description = descrition;
        }
    }
}
