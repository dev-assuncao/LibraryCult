using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCult.Data;
using LibraryCult.Models;
using Microsoft.EntityFrameworkCore;

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

        public Seller FindPerId(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(x => x.SellerId == id);
        }

        public void Insert(Seller obj)
        {
            if (!(obj is Seller))
            {
                return;//exception
            }

            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            bool hasAny = _context.Seller.Any(x => x.SellerId == obj.SellerId);
            if (!hasAny)
            {
                throw new Exception("Id not found in dbcontext");
            }

            _context.Update(obj);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);

            /*if (!hasAny)
            {
                throw new Exception("Seller not found");
            }*/

            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
