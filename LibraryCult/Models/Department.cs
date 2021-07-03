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
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();


        public Department()
        {
        }

        public Department(int idDepartment, string name)
        {
            DepartmentId = idDepartment;
            Name = name;
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        /*
        public double TotalEmployeesPerDepartment(int idDepartment)
        {
            return Employees.Where(x => x.Department == idDepartment);
        }*/
    }
}
