using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCult.Models.ViewModels
{
    public class AuthorViewModel
    {
        public Author Author { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}
