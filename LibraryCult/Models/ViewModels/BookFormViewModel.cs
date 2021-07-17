﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Models;

namespace LibraryCult.Models.ViewModels
{
    public class BookFormViewModel
    {
        public Book Book { get; set; }
        public ICollection<Category> Categorys { get; set; }
    }
}
