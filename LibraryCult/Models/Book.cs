using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCult.Models
{
    public class Book
    {
        public int IdBooks { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
        public string Language { get; set; }
        public double Price { get; set; }


        public Book()
        {
        }

        public Book(int idBooks, string name, Category category, Author author, string language, double price)
        {
            IdBooks = idBooks;
            Name = name;
            Category = category;
            Author = author;
            Language = language;
            Price = price;
        }
    }
}
