using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Services.Exceptions;
using LibraryCult.Services;
using LibraryCult.Models.ViewModels;
using LibraryCult.Models;
using System.Diagnostics;

namespace LibraryCult.Controllers
{
    public class AuthorsController : Controller
    {

        private readonly AuthorService _authorService;
        private readonly CategoryService _categoryService;



        public AuthorsController (AuthorService authorService, CategoryService category)
        {
            _authorService = authorService;
            _categoryService = category;
        }


        public IActionResult Index()
        {
            var authors = _authorService.AllAuthors();

            return View(authors);
        }

        public IActionResult Edit(int id)
        {
            var find = _authorService.FindAuthorId(id);

            if (find == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Author not found" });
            }

            var categories = _categoryService.AllCategory();

            var viewModel = new AuthorViewModel { Author = find, Categories = categories};


            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Author author)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryService.AllCategory();
                var viewModel = new AuthorViewModel { Author = author, Categories = categories };
                return View(viewModel);
            }

            _authorService.UpdateAuthor(author);
            return RedirectToAction(nameof(Index));
        }




        public IActionResult Details(int id)
        {
            var find = _authorService.FindAuthorId(id);

            if (find == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Author not found" });
            }

            var category = _categoryService.AllCategory();

            var viewModel = new AuthorViewModel { Author = find, Categories = category};


            return View(viewModel);
        }


        public IActionResult Error (string message)
        {
            var viewModel = new ErrorViewModel { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(viewModel);
        }
    }
}
