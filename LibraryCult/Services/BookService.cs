using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Data;
using LibraryCult.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using LibraryCult.Services.Exceptions;

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
                throw new DbConcurencyException("Database has this item");
            }

            try
            {
                _context.Book.Add(book);
                _context.SaveChanges();
            }
            catch(DbConcurencyException e)
            {
                throw new DbConcurencyException(e.Message);
            }
        }

        public void UpdateBook(Book book)
        {
            bool hasBook = _context.Book.Any(x => x.BookId == book.BookId);

            if (!hasBook)
            {
                throw new Exception("Book not found");
            }

            _context.Update(book);
            _context.SaveChanges();
        }


        public void RemoveBook(int id)
        {
            var obj = _context.Book.Find(id);


            _context.Book.Remove(obj);
            _context.SaveChanges();
        }
    }
}
