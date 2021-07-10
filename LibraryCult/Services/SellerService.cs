using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Data;
using LibraryCult.Models;

namespace LibraryCult.Services
{
    public class SellerService
    {
        private readonly LibraryCultContext _context;

        public SellerService (LibraryCultContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
