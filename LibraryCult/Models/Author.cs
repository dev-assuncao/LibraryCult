using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryCult.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public Category Category { get; set; }

        public Author()
        {
        }

        public Author(int idAuthor, string name, DateTime birthDate, string descrition, Category category)
        {
            AuthorId = idAuthor;
            Name = name;
            BirthDate = birthDate;           
            Description = descrition;
            Category = category;
        }

        public int TotalBooks(string name)
        {
            return Books.Where(x => x.Author.Name == name).Sum(x => x.Amount);
        }
    }
}
