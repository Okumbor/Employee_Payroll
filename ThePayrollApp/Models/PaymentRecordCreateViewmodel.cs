using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThePayrollApp.Models
{
    public class PaymentRecordCreateViewmodel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Display(Name ="FullName")]
        public string FullName { get; set; }
        public decimal I_No { get; set; }
        [Display(Name = "Pay Date"), DataType(DataType.Date)]
        public DateTime PayDate { get; set; } = DateTime.UtcNow;
        [Display(Name = "Pay Month")]
        public string PayMonth { get; set; } = DateTime.Today.Month.ToString();
        public int TaxYearId { get; set; }
        public string TaxCode { get; set; } = "NGN065";
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
        public decimal? UnionFee { get; set; }
        public decimal? SLC { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetPayment { get; set; }
    }
}
