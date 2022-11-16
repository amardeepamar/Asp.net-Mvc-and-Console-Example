using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App1
{
    public class HomeController: Controller
    {
        //Get: home/index
        public void Index()
        
        {
            Response.Write("<p>URL : " + Request.Url.ToString() + "</p>");
            Response.Write("<p>Path : " + Request.Path + "</p>");
            Response.Write("<p>Query String : " + Request.QueryString + "</p>");
            Response.Write("<p>Method : " + Request.HttpMethod + "</p>");
            Response.Write("<p>Request headers : " + Request.Headers["User-Agent"] + "</p>");
            Response.Write("<p>Browser : " + Request.Browser.Type + "</p>");
            Response.Write("<p>Physical App Path : " + Request.PhysicalApplicationPath + "</p>");
        }
        //Get: home/display
        public void Display()
        {
            Response.Write("Hello ");
            Response.Write("World");
            Response.Headers.Add("x", "100");
            Response.ContentType = "text/plain";
            Response.StatusCode = 500;
        }
        //Get: home/Content
        public ContentResult Content()
        {
            ContentResult c = new ContentResult();
            c.Content = "Hello Amardeep Kumar Amar";
            c.ContentType = "text/plain";
            return c;
            //return Content("Hello World", "text/plain");
        }
        //Get: home/File
        public FileResult File()
        {
            return File("~/sample.pdf", "application/pdf");
        }
        //Get: home/Page1
        public RedirectToRouteResult Page1()
        {
            return RedirectToAction("Page2", "Home");
        }
        //Get: home/Page2
        public ContentResult Page2()
        {
            return Content("Page 2");
        }
        //Get: home/ServerTransferExample
        public void ServerTransferExample()
        {
            Response.Write("<h1>Page 1</h1>");
            Server.TransferRequest("/Home/ServerTransferExampleToOther");
        }
        //Get: home/ServerTransferExampleToOther
        public ContentResult ServerTransferExampleToOther()
        {
            return Content("<h1>Server Transfer Example One Page To Other</h1>");
        }

    }
}