using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Data;
using LibraryCult.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryCult.Services
{
    public class CategoryService
    {
        private readonly LibraryCultContext _context;

        public CategoryService(LibraryCultContext context)
        {
            _context = context;
        }

        public ICollection<Category> AllCategory()
        {
            return _context.Category.ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ICollection<Book> PerCategory(int categoryId)
        {
            var result = from obj in _context.Book select obj;

            return result.Include(x => x.Category)
                .Include(x => x.Author)
                .Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
