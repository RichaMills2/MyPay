using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPay.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[Required]
        //[StringLength(255)]
        //public string Surname { get; set; }

        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]

        public decimal AnnualSalary { get; set; }

        [Required]
        [Range(0, 50)]
        public decimal SuperRate { get; set; }
    }
}