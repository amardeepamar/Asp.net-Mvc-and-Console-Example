using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinExample
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
        public Context():base(@"data source=DESKTOP-IS2M88R; integrated security=yes; initial catalog=company")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
    public class JoinedModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public string Loc { get; set; }
    }
    class Program
    {
        static void Main()
        {
            Context db = new Context();
            List<JoinedModel> joinedModels = 
                db.Departments.Join(db.Employees, d => d.DeptNo, e => e.DeptNo, 
                (d, e) => new JoinedModel()
            {
                EmpId = e.EmpId,
                EmpName = e.EmpName,
                Salary = e.Salary,
                DeptNo = d.DeptNo,
                DeptName = d.DeptName,
                Loc = d.Loc
            }).ToList();
            foreach(JoinedModel emp in joinedModels)
            {
                Console.Write(emp.EmpId);
                Console.Write(",");
                Console.Write(emp.EmpName);
                Console.Write(",");
                Console.Write(emp.Salary);
                Console.Write(",");
                Console.Write(emp.DeptNo);
                Console.Write(",");
                Console.Write(emp.DeptName);
                Console.Write(",");
                Console.Write(emp.Loc);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
