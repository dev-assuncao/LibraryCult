using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCult.Models.ViewModels
{
    public class CategoryFormViewModel
    {
        public Book Book { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
