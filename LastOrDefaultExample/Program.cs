using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastOrDefaultExample
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
        public EmployeeContext() : base(@"data source=DESKTOP-IS2M88R; integrated security=yes; initial catalog=company")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }

    class Program
    {
        static void Main()
        {
            EmployeeContext db = new EmployeeContext();
            Employee emp = db.Employees.Where(temp => temp.Salary > 10000).ToList().LastOrDefault();
            if (emp == null)
            {
                Console.WriteLine("No data found");
            }
            else
            {
                Console.Write(emp.EmpId);
                Console.Write(",");
                Console.Write(emp.EmpName);
                Console.Write(",");
                Console.Write(emp.Salary);
            }
            Console.ReadKey();
        }
    }
}
