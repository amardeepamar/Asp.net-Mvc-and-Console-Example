using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExample
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
    }
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base(@"data source=DESKTOP-IS2M88R; integrated security=yes; initial catalog=company")
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CompanyDbContext db = new CompanyDbContext();
            Console.WriteLine("This is simple list of employee.");
            List <Employee> empsSimplelist = db.Employees.ToList();
            foreach (Employee empsimple in empsSimplelist)
            {
                Console.Write(empsimple.EmpID);
                Console.Write(",");
                Console.Write(empsimple.EmpName);
                Console.Write(",");
                Console.Write(empsimple.Salary);
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.WriteLine("Above is the simple list of employee." + Environment.NewLine + "The Employee which has salary is greatter then 3000");
            /////////////////////////////////////////////
            List<Employee> empsWhere = db.Employees.Where(temp => temp.Salary > 3000).ToList();
            
            foreach (Employee empWhere in empsWhere)
            {
                Console.Write(empWhere.EmpID);
                Console.Write(",");
                Console.Write(empWhere.EmpName);
                Console.Write(",");
                Console.Write(empWhere.Salary);
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.WriteLine("Above is list of The Employee which has salary is greatter then 3000." + Environment.NewLine + "Now list of The Employee which has salary is greatter then 3000 and orderby Salary.");
            /////////////////////////////////////////////
            List<Employee> empsOrderBy = db.Employees.Where(temp => temp.Salary > 3000).OrderBy(temp => temp.Salary).ToList();

            foreach (Employee empOrderBy in empsOrderBy)
            {
                Console.Write(empOrderBy.EmpID);
                Console.Write(",");
                Console.Write(empOrderBy.EmpName);
                Console.Write(",");
                Console.Write(empOrderBy.Salary);
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.WriteLine("Above is list of The Employee which has salary is greatter then 3000 and orderby Salary." + Environment.NewLine + "Only display list of The Employee which is order by Salary.");
            /////////////////////////////////////////////////
            List<Employee> empsonlyOrderBy = db.Employees.OrderBy(temp => temp.Salary).ToList();

            foreach (Employee empOrderBy in empsonlyOrderBy)
            {
                Console.Write(empOrderBy.EmpID);
                Console.Write(",");
                Console.Write(empOrderBy.EmpName);
                Console.Write(",");
                Console.Write(empOrderBy.Salary);
                Console.WriteLine();
            }
            Console.ReadKey();

            Console.WriteLine("Example of OrderByDescending" + Environment.NewLine + "Example of OrderByDescending");
        }
    }
}
