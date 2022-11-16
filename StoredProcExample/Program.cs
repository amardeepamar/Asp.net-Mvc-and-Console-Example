using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcExample
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
            List<Employee> emp = db.Database.SqlQuery<Employee>("GetEmployees").ToList();
            foreach(Employee emps in emp)
            {
                Console.Write(emps.EmpId);
                Console.Write(",");
                Console.Write(emps.EmpName);
                Console.Write(",");
                Console.Write(emps.Salary);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
