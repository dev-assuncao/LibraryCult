using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Data;
using LibraryCult.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryCult.Services
{
    public class AuthorService
    {

        private readonly LibraryCultContext _context;

        public AuthorService (LibraryCultContext context)
        {
            _context = context;
        }


        public ICollection<Author> AllAuthors()
        {
            var result = from obj in _context.Author select obj;

            return result.Include(x => x.Category).ToList();
        }


        public Author FindAuthorId(int id)
        {
            return _context.Author.FirstOrDefault(x => x.AuthorId == id);
        }

        public bool HasAuthor(int id)
        {
            return _context.Author.Any(x => x.AuthorId == id);
        }
    }
}
