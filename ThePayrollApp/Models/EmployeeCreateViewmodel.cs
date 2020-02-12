using Microsoft.AspNetCore.Http;
using Payroll_Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThePayrollApp.Models
{
    public class EmployeeCreateViewmodel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Employee Number is required"), RegularExpression(@"^[A-Z]{3,3}[0-9]{3}$")]
        public string EmpNo { get; set; }
        [Required(ErrorMessage ="First Name is required"), StringLength(50, MinimumLength =2), RegularExpression(@"^ [A-Z] [a-z,A-Z]$"), Display(Name ="First Name")]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 2), RegularExpression(@"^ [A-Z] [a-z,A-Z]$"), Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required"), StringLength(50, MinimumLength = 2), RegularExpression(@"^ [A-Z] [a-z,A-Z]$"), Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string FullName { get
            { return FirstName + (string.IsNullOrEmpty(MiddleName) ? " " : (" " + (char?)MiddleName[0] + ".").ToUpper()) + LastName; 
                    } }
        [Required]
        public string Gender { get; set; }
        [Required(ErrorMessage ="Address is required"), StringLength(50)]
        public string Address { get; set; }
        [Required(ErrorMessage ="City is required"), StringLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage ="Postal Code is required"), StringLength(50), Display(Name ="Postal Code")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage ="Phone Number is required")]
        [RegularExpression(@"^\d{4}-\d{3}-\d{4} $")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date), Required(ErrorMessage ="Date of Birth is Required"), Display(Name ="Date of Birth")]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date), Required(ErrorMessage = "Date Joined is Required"), Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage ="Job Role is Required"), StringLength(100)]
        public string Designation { get; set; }
        [DataType(DataType.EmailAddress) ,Required]
        public string Email { get; set; }
        [Display(Name ="Photo")]
        public IFormFile ImageUrl { get; set; }
        [Required(ErrorMessage ="National ID No"), StringLength(50), Display(Name ="National ID No")]
        [RegularExpression(@"^[0-9] {11} $")]
        public string NationalInsuranceNo { get; set; }
        [Display(Name ="What Payment Method do you want")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Are interested in Student Loan")]
        public StudentLoan StudentLoan { get; set; }
        [Display(Name = "Are you a Union Member")]
        public UnionMember UnionMember { get; set; }
    }
}
