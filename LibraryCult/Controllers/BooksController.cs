using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Services;
using LibraryCult.Models.ViewModels;
using LibraryCult.Models;
using System.Diagnostics;

namespace LibraryCult.Controllers
{
    public class BooksController : Controller
    {

        private readonly BookService _bookService;
        private readonly CategoryService _categoryService;
        private readonly AuthorService _authorService;

        public BooksController(BookService book, CategoryService category, AuthorService author)
        {
            _bookService = book;
            _categoryService = category;
            _authorService = author;
        }



        public IActionResult Index()
        {
            var result = _bookService.FindBook();

            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var category = _categoryService.AllCategory();
            var bookForm = new BookFormViewModel { Categorys = category };
            return View(bookForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                var category = _categoryService.AllCategory();
                BookFormViewModel bookForm = new BookFormViewModel { Book = book, Categorys = category };
            }

            _bookService.InsertBook(book);

            var hasAuthor = _authorService.HasAuthor(book.AuthorId);

            if (hasAuthor)
            {
                //return RedirectToAction("Edit", new RouteValueDictionary(new { Controller = "AuthorsController", Action = "Edit", book.AuthorId }));

                //return RedirectToAction("Edit", "AuthorsController", new { id = book.AuthorId });

                return RedirectToAction(nameof(AuthorsController.Edit), new { id = book.AuthorId });
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }



        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch." });
            }

            var result = _bookService.FindBookId(id.Value);

            if (result == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Book not found." });
            }


            var category = _categoryService.AllCategory();

            BookFormViewModel bookForm = new BookFormViewModel { Book = result, Categorys = category };

            return View(bookForm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Book book)
        {
            if (!ModelState.IsValid)
            {
                var category = _categoryService.AllCategory();
                var viewModel = new BookFormViewModel { Book = book, Categorys = category };
                return View(viewModel);
            }

            if (id != book.BookId)
            {
                return RedirectToAction(nameof(Error), new { message = "Book not found." });
            }

            _bookService.UpdateBook(book);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details (int id)
        {
           var result = _bookService.FindBookId(id);

            if (result == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Book not found" });
            }

            var category = _categoryService.AllCategory();

            var viewModel = new BookFormViewModel { Book = result, Categorys = category };

            return View(viewModel);
        }



        [HttpGet]
        public IActionResult Delete (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch." });
            }

            var result = _bookService.FindBookId(id.Value);

            if (result == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Book not found" });
            }

            var categorys = _categoryService.AllCategory();
            var viewModel = new BookFormViewModel { Book = result, Categorys = categorys };

            return View(viewModel);     
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var result = _bookService.FindBookId(id);

            if (result == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Book not found" });
            }

            _bookService.RemoveBook(id);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Error (string message)
        {
            var viewModel = new ErrorViewModel { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(viewModel);
        }
    }
}
