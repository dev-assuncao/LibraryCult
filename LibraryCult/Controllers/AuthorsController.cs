using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Services;

namespace LibraryCult.Controllers
{
    public class AuthorsController : Controller
    {

        private readonly AuthorService _authorService;

        public AuthorsController (AuthorService authorService)
        {
            _authorService = authorService;
        }


        public IActionResult Index()
        {
            var authors = _authorService.AllAuthors();

            return View(authors);
        }

        public IActionResult Edit()
        {
            return View();
        }


        public IActionResult Details()
        {
            return View();
        }

    }
}
