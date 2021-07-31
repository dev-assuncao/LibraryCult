using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Data;
using LibraryCult.Models;

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
            return _context.Author.ToList();
        }
    }
}
