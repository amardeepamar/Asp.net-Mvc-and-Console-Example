using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipExample
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
    }
    public class EmployeeContext : DbContext
    {
        public EmployeeContext():base(@"data source=DESKTOP-IS2M88R; integrated security=yes; initial catalog=company")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
    class Program
    {
        static void Main()
        {
            EmployeeContext db = new EmployeeContext();
            List<Employee> emps = db.Employees.ToList().Skip(2).ToList();
            foreach(Employee emp in emps)
            {
                Console.Write(emp.EmpId);
                Console.Write(",");
                Console.Write(emp.EmpName);
                Console.Write(",");
                Console.Write(emp.Salary);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
