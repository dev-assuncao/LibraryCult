using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCult.Models
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }
        public Department Department { get; set; }

        public Employee()
        {
        }

        public Employee(int idEmployee, string name, DateTime birthDate, double salary, Department department)
        {
            IdEmployee = idEmployee;
            Name = name;
            BirthDate = birthDate;
            Salary = salary;
            Department = department;
        }
    }
}
