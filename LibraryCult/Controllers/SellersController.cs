using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Models;
using LibraryCult.Models.ViewModels;
using LibraryCult.Services;
using System.Diagnostics;

namespace LibraryCult.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
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
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });
            }

            var result = _sellerService.FindPerId(id.Value);

            if (result == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Seller not found." });
            }

            List<Department> departments = _departmentService.FindAllDp();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = result, Departments = departments };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAllDp();
                var viewModel = new SellerFormViewModel { Departments = departments, Seller = seller };
                return View(viewModel);
            }

            if (id.Value != seller.SellerId)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            _sellerService.Update(seller);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "id not provided" });
            }

            var result = _sellerService.FindPerId(id.Value);

            if (result == null)
            {
                RedirectToAction(nameof(Error), new { message = "Seller not found" });
            }

            return View(result);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var result = _sellerService.FindPerId(id.Value);

            if (result == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Seller not found" });
            }

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            var result = _sellerService.FindPerId(id);

            if (result == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            _sellerService.Remove(id);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
