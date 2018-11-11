using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyPay.Models;

namespace MyPay.Controllers.Api
{
    public class TaxTablesController : ApiController
    {
        private ApplicationDbContext _context;

        public TaxTablesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<TaxTables> GetTaxTables()
        {
            return _context.TaxTables.ToList();
        }


        [HttpGet]
        [Route("api/taxtables/calc")]
        public TaxTables GetTaxById()
        {
            return _context.TaxTables.SingleOrDefault(x => x.Id == 4);
        }

        [HttpGet]
        [Route("api/taxtables/CalculateTaxTest/{taxableIncome}")]
        public TaxTables CalculateTax(decimal taxableIncome)
        {

            return _context.TaxTables.SingleOrDefault(x => taxableIncome >= x.MinimumAmount && taxableIncome <= x.MaximumAmount);

            
        }

        [HttpGet]
        [Route("api/taxtables/GetTax/{employeeId}")]
        public List<decimal> CalculateTax(int employeeId)
        {
            List<decimal> payslipValues = new List<decimal>();
            decimal gross = 0;
            decimal taxAmount = 0;
            decimal nett = 0;
            decimal super = 0;

            var employee = _context.Employees.SingleOrDefault(x => x.Id == employeeId);

            if (employee != null)
            {

                gross = employee.AnnualSalary / 12;
                payslipValues.Add(Math.Round(gross));

                var taxTables = _context.TaxTables.SingleOrDefault(x => employee.AnnualSalary >= x.MinimumAmount && employee.AnnualSalary <= x.MaximumAmount);

                if (taxTables != null)
                    taxAmount = (taxTables.Amount + (employee.AnnualSalary - taxTables.Threshhold) * (taxTables.TaxAmount / 100))/12 ;

                payslipValues.Add(Math.Round(taxAmount));

                nett = (gross - taxAmount);
                payslipValues.Add(Math.Round(nett));


                super = gross * (employee.SuperRate / 100);

                payslipValues.Add(Math.Round(super));


            }

            return payslipValues;

        }

       

    }
}
