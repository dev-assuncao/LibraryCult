using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCult.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int idDepartment, string name)
        {
            DepartmentId = idDepartment;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public void RemoveSeller(Seller seller)
        {
            Sellers.Remove(seller);
        }


        public double TotalEmployeesPerDepartment(Department obj)
        {
            return Sellers.Where(x => x.Department == obj).ToList().Count();
        }

    }
}
