using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App1
{
    public class Controller2Controller:Controller
    {
        public string Action1()
        {
            return "Products Page Here";
        }
        public string Action2()
        {
            return "Services Page Here";
        }
    }
}