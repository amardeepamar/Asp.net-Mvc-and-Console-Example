using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeferredExample
{
    public class Department
    {
        [Key]
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public string Loc { get; set; }
    }
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public int DeptNo { get; set; }
    }
    public class Context : DbContext
    {
        public Context() : base(@"data source=DESKTOP-IS2M88R; integrated security=yes; initial catalog=company")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
    class Program
    {
        static void Main()
        {
            Context db = new Context();
            var depts = db.Departments.Where(temp => temp.DeptNo > 10);
            var emps = db.Employees.Where(temp => temp.Salary > 3000);
            List<Department> d = depts.ToList();
            List<Employee> e = emps.ToList();

            foreach(Department temp in d)
            {
                Console.Write(temp.DeptNo);
                Console.Write(",");
                Console.Write(temp.DeptName);
                Console.Write(",");
                Console.Write(temp.Loc);
                Console.WriteLine();
            }
            Console.WriteLine();

            foreach (Employee temp in e)
            {
                Console.Write(temp.EmpId);
                Console.Write(",");
                Console.Write(temp.EmpName);
                Console.Write(",");
                Console.Write(temp.Salary);
                Console.Write(",");
                Console.Write(temp.DeptNo);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
