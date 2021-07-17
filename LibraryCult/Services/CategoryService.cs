using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Data;
using LibraryCult.Models;

namespace LibraryCult.Services
{
    public class CategoryService
    {
        private readonly LibraryCultContext _context;

        public CategoryService (LibraryCultContext context)
        {
            _context = context;
        }

        public ICollection<Category> AllCategory()
        {
            return _context.Category.ToList();
        }

    }
}
