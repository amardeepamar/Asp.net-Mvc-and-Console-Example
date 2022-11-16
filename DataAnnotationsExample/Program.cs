using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotationsExample
{
    [Table("Departments")]
    public class Dept
    {
        [Key]
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        [Column("Loc")]
        public string Location { get; set; }
    }

    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public int DeptNo { get; set; }
        [ForeignKey("DeptNo")]
        public virtual Dept Department { get; set; }
        [NotMapped]
        public double Tax { get; set; } = 1000;
    }
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base(@"data source=DESKTOP-IS2M88R; integrated security=yes; initial catalog=company")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dept> Departments { get; set; }
    }
    class Program
    {

        static void Main()
        {
            EmployeeContext db = new EmployeeContext();
            List<Employee> emps = db.Employees.ToList();
            foreach(Employee emp in emps)
            {
                Console.Write(emp.EmpId);
                Console.Write(",");
                Console.Write(emp.EmpName);
                Console.Write(",");
                Console.Write(emp.Salary);
                Console.Write(",");
                Console.Write(emp.DeptNo);
                Console.Write(",");
                Console.Write(emp.Department.DeptName);
                Console.Write(",");
                Console.Write(emp.Department.Location);
                Console.Write(",");
                Console.Write(emp.Tax);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
