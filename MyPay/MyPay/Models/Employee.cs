using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPay.Models
{
    public class Employee
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

        [Display(Name="Annual salary")]
        public decimal AnnualSalary { get; set; }

        [Required]
        [Range(0,50)]
        [Display(Name ="Super Rate %")]
        public decimal SuperRate { get; set; }
    }
}