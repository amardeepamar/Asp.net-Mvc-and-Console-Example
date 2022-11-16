using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImplementationInMvc.Models
{
    public class Db: DbContext
    {
        public Db() : base(@"data source=DESKTOP-IS2M88R; integrated security=yes; initial catalog=company")
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}