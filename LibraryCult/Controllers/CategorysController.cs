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
                throw new Exception("Id is null");
            }

            var search = _categoryService.PerCategory(id.Value);

            if (search == null)
            {
                throw new Exception("Category not found");
            }

            var viewModel = new CategoryFormViewModel { Books = search };
            return View(viewModel);
        }
    }
}
