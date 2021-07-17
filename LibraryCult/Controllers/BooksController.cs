using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Services;
using LibraryCult.Models.ViewModels;
using LibraryCult.Models;

namespace LibraryCult.Controllers
{
    public class BooksController : Controller
    {

        private readonly BookService _bookService;
        private readonly CategoryService _categoryService;

        public BooksController (BookService book, CategoryService category)
        {
            _bookService = book;
            _categoryService = category;
        }



        public IActionResult Index()
        {
            var result = _bookService.FindBook();

            return View(result);
        }


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Id invalid" });
            }

            var result = _bookService.FindBookId(id.Value);

            if (result == null)
            {
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Book not found" });
            }


            var category = _categoryService.AllCategory();

            BookFormViewModel bookForm = new BookFormViewModel { Book = result, Categorys = category };

            return View(bookForm);
        }
    }
}
