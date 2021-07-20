using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Data;
using LibraryCult.Models;
using Microsoft.EntityFrameworkCore;


namespace LibraryCult.Services
{
    public class BookService 
    {
        private readonly LibraryCultContext _context;

        public BookService (LibraryCultContext context)
        {
            _context = context;
        }

        public ICollection<Book> FindBook()
        {
            return _context.Book.ToList();
        }

        public Book FindBookId(int id)
        {
            return _context.Book.Include(obj => obj.Author).FirstOrDefault(obj => obj.BookId == id);
        }

        public void InsertBook(Book book)
        {
            bool hasBook = _context.Book.Any(x => x.BookId == book.BookId);

            if (hasBook)
            {
                throw new Exception("Database has this item");
            }

            _context.Book.Add(book);
            _context.SaveChanges();
        }
    }
}
