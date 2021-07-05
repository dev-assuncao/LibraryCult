using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Models.Enums;
using LibraryCult.Models;

namespace LibraryCult.Data
{
    public class SeedingService
    {
        private LibraryCultContext _context;

        public SeedingService (LibraryCultContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Author.Any() || _context.Book.Any()
                || _context.Category.Any() || _context.Seller.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Games");
            Department d3 = new Department(3, "Books");
            Department d4 = new Department(4, "Musics");

            Category c1 = new Category(1, "Hqs and Mangás");
            Category c2 = new Category(2, "Literature");
            Category c3 = new Category(3, "Management");
            Category c4 = new Category(4, "Technology");
            Category c5 = new Category(5, "Fiction");

            Author a1 = new Author(1, "Eiichiro Oda", new DateTime(1975, 1, 1), "Eiichiro Oda is a Japanese manga artist and the creator of the series One Piece.", c1);
            Author a2 = new Author(2, "Joaquim Maria Machado de Assis", new DateTime(1839, 6, 21), "Machado de Assis was a Brazilian novelist, poet, playwright and short story writer.", c2);
            Author a3 = new Author(3, "Daniel Goleman", new DateTime(1946, 5, 7), "Daniel Goleman is an author and science Journalist. Goleman has written books on topics including sef-deceptionm creativity, transparency and others.", c3);
            Author a4 = new Author(4, "Robert Cecil Martin", new DateTime(1952, 12, 5), "Robert Cecil Martin (Uncle Bob), is an American software engineerm instructor, and best-selling author.", c4);
            Author a5 = new Author(5, "Joanne Rowling", new DateTime(1965, 7, 31), "Joanne Rowling (J. K. Rowling) is a British author, philanthropistm film producer, television producer and screenwriter.", c5);

            Book b1 = new Book(1, "One Piece: Ace's Story", c1, new DateTime(2020, 5, 5), a1, "English", 10, 50.92, Status.Available);
            Book b2 = new Book(2, "Dom Casmurro", c2, new DateTime(1899, 6, 8), a2, "Portuguese", 100, 15.45, Status.Available);
            Book b3 = new Book(3, "The Focus", c3, new DateTime(2014, 1, 7), a3, "English", 0, 40.90, Status.Unavailable);
            Book b4 = new Book(4, "Clean Code", c4, new DateTime(2009, 9, 8), a4, "English", 15, 88.90, Status.Available);
            Book b5 = new Book(5, "Harry Potter and the Philosopher's Stone", c5, new DateTime(1997, 6, 26), a5, "English", 30, 36.90, Status.Available);

            Seller s1 = new Seller(1, "Davisson Pereira", new DateTime(2001, 8, 10), 1500.00, d3);
            Seller s2 = new Seller(2, "Danilo Assunção", new DateTime(1994, 2, 27), 1600.00, d2);
            Seller s3 = new Seller(3, "Sandra Pereira", new DateTime(1970, 8, 26), 1400.00, d4);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Category.AddRange(c1, c2, c3, c5, c5);
            _context.Author.AddRange(a1, a2, a3, a4, a5);
            _context.Book.AddRange(b1, b2, b3, b4, b5);
            _context.Seller.AddRange(s1, s2, s3);

            _context.SaveChanges();
        }
    }
}
