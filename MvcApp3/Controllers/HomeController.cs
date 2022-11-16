using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public ActionResult Index()
        {
            return View();
        }
        // GET: Home/Expression
        public ActionResult Expression()
        {
            return View();
        }
        // GET: Home/RazorIfExample
        public ActionResult RazorIfExample()
        {
            return View();
        }
        
    }
}