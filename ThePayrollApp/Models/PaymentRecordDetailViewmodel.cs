using Payroll_Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThePayrollApp.Models
{
    public class PaymentRecordDetailViewmodel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Display(Name = "FullName")]
        public string FullName { get; set; }
        [Display(Name = "Insurance")]
        public decimal I_No { get; set; }
        [Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; }
        [Display(Name = "Pay Month")]
        public string PayMonth { get; set; } 
        public int TaxYearId { get; set; }
        public string Year { get; set; }
        public string TaxCode { get; set; } 
        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { get; set; }
        [Display(Name = "Hours Worked")]
        public decimal HoursWorked { get; set; }
        [Display(Name = "Contractual Hours")]
        public decimal ContractualHours { get; set; } = 280m;
        [Display(Name = "Over Time Hours")]
        public decimal OverTimeHours { get; set; }
        [Display(Name = "Contractual Earning")]
        public decimal ContractualEarning { get; set; }
        [Display(Name = "Over Time Earning")]
        public decimal OverTimeEarning { get; set; }
        [Display(Name = "Tax")]
        public decimal Tax { get; set; }
        public decimal? FIRS { get; set; }
        [Display(Name = "Union Fee")]
        public decimal? UnionFee { get; set; }
        [Display(Name = "Student Loan")]
        public decimal? SLC { get; set; }
        [Display(Name = "Total Earnings")]
        public decimal TotalEarnings { get; set; }
        [Display(Name = "Total Deductions")]
        public decimal TotalDeductions { get; set; }
        [Display(Name = "NetPayment")]
        public decimal NetPayment { get; set; }
    }
}
