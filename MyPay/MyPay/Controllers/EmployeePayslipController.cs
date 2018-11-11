using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPay.Controllers
{
    public class EmployeePayslipController : Controller
    {
        // GET: EmployeePayslip
        public ActionResult New()
        {
            return View();
        }
    }
}