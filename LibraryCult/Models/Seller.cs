using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryCult.Models
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }

        public Department Department { get; set; }

        [Display(Name = "Department")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }



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
    }
}
