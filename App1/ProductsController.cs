using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App1
{
    public class ProductsController: Controller
    {
        //Get: Products/Show/laptops
        public string Show(string Category)
        {
            return "Category : " + Category;
        }
    }
}