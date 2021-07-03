using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCult.Data
{
    public class SeedingService
    {
        private LibraryCultContext _context;

        public SeedingService (LibraryCultContext context)
        {
            _context = context;
        }
    }
}
