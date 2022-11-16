using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggreateOperatorExample
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
            decimal sum = db.Employees.Select(temp => temp.Salary).Sum();
            decimal avg = db.Employees.Select(temp => temp.Salary).Average();
            decimal min = db.Employees.Select(temp => temp.Salary).Min();
            decimal max = db.Employees.Select(temp => temp.Salary).Max();
            decimal count = db.Employees.Select(temp => temp.Salary).Count();
            Console.WriteLine("Sum : " + sum);
            Console.WriteLine("Average : " + avg);
            Console.WriteLine("Minimum : " + min);
            Console.WriteLine("Maximum : " + max);
            Console.WriteLine("Count : " + count);
            Console.ReadKey();
        }
    }
}
