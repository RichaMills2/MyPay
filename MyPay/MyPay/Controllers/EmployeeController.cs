using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPay.Models;
using MyPay.ViewModels;
using MyPay.Models;

namespace MyPay.Controllers
{

    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Employee
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult New()
        {
           
            var viewModel = new EmployeeViewModel
            {
                Employee = new Employee(),
            };
            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var invalidModel = new EmployeeViewModel()
                {
                    Employee = employee
                };
                    
                return View("EmployeeForm", invalidModel);
            }
            if (employee.Id == 0)
                _context.Employees.Add(employee);
            else
            {

                var employeeInDb = _context.Employees.Single(c => c.Id == employee.Id);
                employeeInDb.Name = employee.Name;
                //employeeInDb.Surname = employee.Surname;
                employeeInDb.AnnualSalary = employee.AnnualSalary;
                employeeInDb.SuperRate = employee.SuperRate;


            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

        public ActionResult Edit(int Id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.Id == Id);

            if (employee == null)
                return HttpNotFound();

            var viewModel = new EmployeeViewModel()
            {
                Employee = employee

            };

            return View("EmployeeForm", viewModel);
        }

        public ActionResult EmployeePayslip()
        {
           
            return View("EmployeePayslip");
        }
    }
}