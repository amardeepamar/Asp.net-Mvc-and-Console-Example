using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptExample
{
    public class Employee
    {   
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public int DeptNo { get; set; }
    }
    //@"data source=DESKTOP-IS2M88R; integrated security=yes; initial catalog=company")
    public class ManjayContext : DbContext
    {
        public ManjayContext():base(@"data source=DESKTOP-IS2M88R;initial catalog=company;integrated security=yes") { }
        public DbSet<Employee> Employees { get; set; }
    }
    class Program
    {
        static void Main()
        {
            ManjayContext db = new ManjayContext();
            List<Employee> emps1 = db.Employees.Where(temp => temp.Salary > 3500).ToList();
            List<Employee> emps2 = db.Employees.Where(temp => temp.DeptNo == 10).ToList();
            List<Employee> emps = emps1.Except(emps2).ToList();
            foreach(Employee emp in emps)
            {
                Console.Write(emp.EmpId);
                Console.Write(",");
                Console.Write(emp.EmpName);
                Console.Write(",");
                Console.Write(emp.Salary);
                Console.Write(",");
                Console.Write(emp.DeptNo);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
