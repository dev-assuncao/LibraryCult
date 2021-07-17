using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace LibraryCult.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public DateTime Release { get; set; }
        public Author Author { get; set; }
        public string Language { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public Status Status { get; set; }

        [Display(Name = "Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Book()
        {
        }

        public Book(int idBooks, string name, Category category, DateTime release, Author author, string language, int amount, double price, Status status)
        {
            BookId = idBooks;
            Name = name;
            Category = category;
            Release = release;
            Author = author;
            Language = language;
            Amount = amount;
            Price = price;
            Status = status;
        }
    }
}
