using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payroll_Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string EmpNo { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(70)]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required, MaxLength(150)]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }
        public string Designation { get; set; }
        [Required]
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string NationalInsuranceNo { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StudentLoan StudentLoan { get; set; }
        public UnionMember UnionMember { get; set; }
        public IEnumerable<PaymentRecord> PaymentRecords { get; set; }
    }
}
