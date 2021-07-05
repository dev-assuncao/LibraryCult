using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCult.Models
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }
        public Department Department { get; set; }
        public Seller()
        {
        }

        public Seller(int idEmployee, string name, DateTime birthDate, double salary, Department department)
        {
            SellerId = idEmployee;
            Name = name;
            BirthDate = birthDate;
            Salary = salary;
            Department = department;
        }

        /*
         public double TotalEmployeesPerDepartment(int idDepartment)
         {
            return Employees.Where(x => x.Department == idDepartment);
         }*/

    }
}
