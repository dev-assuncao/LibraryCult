using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Models;
using LibraryCult.Models.ViewModels;
using LibraryCult.Services;

namespace LibraryCult.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController (SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAllDp();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAllDp();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Id not provided" });
            }

            var result = _sellerService.FindPerId(id.Value);

            if (result == null)
            {
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Id not found" });
            }

            List<Department> departments = _departmentService.FindAllDp();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = result, Departments = departments };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Seller seller)
        {
            if(!ModelState.IsValid)
            {
                var departments = _departmentService.FindAllDp();
                var viewModel = new SellerFormViewModel { Departments = departments, Seller = seller };
                return View(viewModel);
            }

            if (id.Value != seller.SellerId)
            {
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Id not correspondind" });
            }

            _sellerService.Update(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
