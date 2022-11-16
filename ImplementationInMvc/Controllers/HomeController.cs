using ImplementationInMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImplementationInMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Select()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult Select(Employee employee)
        {
            Db db = new Db();
            db.Employees.Select(temp => new { temp.EmpName, temp.Salary });
            return View(employee);
        }
    }
}