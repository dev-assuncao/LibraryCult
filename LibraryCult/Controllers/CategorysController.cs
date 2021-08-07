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
    public class CategorysController : Controller
    {

        private readonly CategoryService _categoryService;

        public CategorysController(CategoryService service)
        {
            _categoryService = service;
        }
        public IActionResult Index()
        {
            var category = _categoryService.AllCategory();

            return View(category);
        }


        public IActionResult Search(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var search = _categoryService.PerCategory(id.Value);

            if (search == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Category not Found" });
            }

            var viewModel = new CategoryFormViewModel { Books = search };
            return View(viewModel);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(viewModel);
        }
    }
}
