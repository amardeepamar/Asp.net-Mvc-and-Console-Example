using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App1
{
    public class EmployeesController:Controller
    {

        //Get: Employees/Disply/1
        public string Disply(int EmpId)
        {
            return "Emp Id : " + EmpId;
        }

    }
}