using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCult.Models
{
    public class Department
    {
        public int IdDepartment { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();


        public Department()
        {
        }

        public Department(int idDepartment, string name)
        {
            IdDepartment = idDepartment;
            Name = name;
        }
    }
}
