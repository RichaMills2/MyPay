using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MyPay.Dtos;
using MyPay.Models;

namespace MyPay.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/employees
        public IHttpActionResult GetEmployees(string query = null)
        {

            if (string.IsNullOrWhiteSpace(query))
                return Ok(_context.Employees.ToList().Select(Mapper.Map<Employee, EmployeeDto>));
            else
                return Ok(_context.Employees.Where(x => x.Name.Contains(query)).Select(Mapper.Map<Employee, EmployeeDto>));
          

        }

        //GET /api/employees/1
        public EmployeeDto GetEmployee(int id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Employee,EmployeeDto>(employee);
        }


        //POST /api/employee
        [HttpPost]
        public IHttpActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employee = Mapper.Map<EmployeeDto, Employee>(employeeDto);

            _context.Employees.Add(employee);
            _context.SaveChanges();

            employeeDto.Id = employee.Id;

            return Created(new Uri(Request.RequestUri + "/" + employee.Id),employeeDto );
        }

        [HttpPut]
        public void UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var employeeInDb = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employeeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(employeeDto, employeeInDb);

           
            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var employeeInDb = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employeeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();

        }
    }
}
