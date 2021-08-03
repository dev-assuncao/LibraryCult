using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Services.Exceptions;
using LibraryCult.Services;
using LibraryCult.Models.ViewModels;

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
                throw new NotFoundException("Author not found");
            }

            var viewModel = new AuthorViewModel { Author = find };


            return View(viewModel);
        }


        public IActionResult Details(int id)
        {
            var find = _authorService.FindAuthorId(id);

            if (find == null)
            {
                throw new NotFoundException("Author not found");
            }

            var category = _categoryService.AllCategory();

            var viewModel = new AuthorViewModel { Author = find, Categories = category};


            return View(viewModel);
        }

    }
}
