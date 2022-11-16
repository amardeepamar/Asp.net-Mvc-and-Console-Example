using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdationExample
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
            Console.WriteLine("Emp ID: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Emp Name: ");
            string b = Console.ReadLine();
            Console.WriteLine("Salary: ");
            decimal c = Convert.ToDecimal(Console.ReadLine());
            Employee emp = db.Employees.Where(temp => temp.EmpId == a).FirstOrDefault();
            if (emp != null)
            {
                emp.EmpName = b;
                emp.Salary = c;
                db.SaveChanges();
                Console.WriteLine("Updated");
            }
            else
            {
                Console.WriteLine("Invalid Employee Id");
            }
            
            
            Console.ReadKey();
        }
    }
}
