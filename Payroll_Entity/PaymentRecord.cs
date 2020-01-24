using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_Entity
{
    public class PaymentRecord
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        public string NINo { get; set; }
        public DateTime PayDate { get; set; }
        public string PayMonth { get; set; }
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }
        public string TaxCode { get; set; }
        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal HoursWorked { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ContractualHours { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OverTimeHours { get; set; }
        [Column(TypeName = "money")]
        public decimal ContractualEarning { get; set; }
        [Column(TypeName = "money")]
        public decimal OverTimeEarning { get; set; }
        [Column(TypeName = "money")]
        public decimal Tax { get; set; }
        [Column(TypeName = "money")]
        public decimal FIRS { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnionFee { get; set; }
        [Column(TypeName = "money")]
        public decimal? SLC { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDeductions { get; set; }
        [Column(TypeName = "money")]
        public decimal NetPayment { get; set; }

    }
}