﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCult.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
