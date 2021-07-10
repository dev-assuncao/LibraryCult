using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Data;
using LibraryCult.Models;


namespace LibraryCult.Services
{
    public class DepartmentService
    {

        private readonly LibraryCultContext _context;

        public DepartmentService (LibraryCultContext context)
        {
            _context = context;
        }

        public List<Department> FindAllDp()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
