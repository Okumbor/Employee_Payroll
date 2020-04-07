using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll_Entity;
using Payroll_Services;
using RotativaCore;
using ThePayrollApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThePayrollApp.Controllers
{
    public class PayController : Controller
    {
        private readonly IPaymentRecordService _paymentRecordService;
        private readonly IEmployeeService _employeeService;
        private readonly ITaxService _taxService;
        private readonly IInsuranceService _insuranceService;
        private decimal overtimeHrs;
        private decimal contractualEarnings;
        private decimal overTimeEarnings;
        private decimal totalEarnings;
        private decimal tax;
        private decimal unionFee;
        private decimal studentLoan;
        private decimal insurance;
        private decimal totalDeductions;

        public ITaxService TaxService { get; }

        public PayController(IPaymentRecordService paymentRecordService,
                            IEmployeeService employeeService,
                            ITaxService taxService,
                            IInsuranceService insuranceService)
        {
            _paymentRecordService = paymentRecordService;
            _employeeService = employeeService;
            _taxService = taxService;
            _insuranceService = insuranceService;
        }

        public IActionResult Index()
        {
            var paymentRecords = _paymentRecordService.GetAll().Select(pay => new PaymentRecordIndexViewmodel
            { Id = pay.Id,
                EmployeeId = pay.EmployeeId,
                FullName = pay.FullName,
                PayDate = pay.PayDate,
                PayMonth = pay.PayMonth,
                TaxYearId = pay.TaxYearId,
                Year = _paymentRecordService.GetTaxYearById(pay.TaxYearId).YearofTax,
                TotalEarnings = pay.TotalEarnings,
                TotalDeductions = pay.TotalDeductions,
                NetPayment = pay.NetPayment,
                Employee = pay.Employee,
            });
            return View(paymentRecords);
        }

        public IActionResult Create()
        {
            ViewBag.employees = _employeeService.GetAllEmployeesForPayController();
            ViewBag.allTaxYears = _paymentRecordService.GetAllTaxYear();
            var model = new PaymentRecordCreateViewmodel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentRecordCreateViewmodel model)
        {
            if (ModelState.IsValid)
            {
                var payroll = new PaymentRecord()
                {
                    Id = model.Id,
                    EmployeeId = model.EmployeeId,
                    FullName = _employeeService.GetById(model.EmployeeId).FullName,
                    PayDate = model.PayDate,
                    PayMonth = model.PayMonth,
                    TaxYearId = model.TaxYearId,
                    TaxCode = model.TaxCode,
                    HourlyRate = model.HourlyRate,
                    HoursWorked = model.HoursWorked,
                    ContractualHours = model.ContractualHours,
                    OverTimeHours = overtimeHrs = _paymentRecordService.OvertimeHours(model.HoursWorked, model.ContractualHours),
                    ContractualEarning = contractualEarnings = _paymentRecordService.ContractualEarnings(model.ContractualHours, model.HourlyRate, model.HoursWorked),
                    OverTimeEarning = overTimeEarnings = _paymentRecordService.OvertimeEarnings(_paymentRecordService.OvertimeRate(model.HourlyRate), overtimeHrs),
                    TotalEarnings = totalEarnings = _paymentRecordService.TotalEarnings(overTimeEarnings, contractualEarnings),
                    Tax = tax = _taxService.TaxAmount(totalEarnings),
                    UnionFee = unionFee = _employeeService.UnionFee(model.EmployeeId),
                    SLC = studentLoan = _employeeService.StudentLoanRepaymentAmount(model.EmployeeId, totalEarnings),
                    I_No = insurance = _insuranceService.Insurance(totalEarnings),
                    TotalDeductions = totalDeductions = _paymentRecordService.TotalDeduction(tax, insurance, unionFee, studentLoan),
                    NetPayment = _paymentRecordService.NetPay(totalEarnings, totalDeductions)

                };
                await _paymentRecordService.CreateAsync(payroll);
                return RedirectToAction(nameof(Index));
            }
            var employees = _employeeService.GetAllEmployeesForPayController();
            var allTaxYears = _paymentRecordService.GetAllTaxYear();
            return View();
        }

        public IActionResult Details(int id)
        {
            var paymentRecord = _paymentRecordService.GetById(id);
            if (paymentRecord == null)
            {
                return NotFound();
            }
            var model = new PaymentRecordDetailViewmodel()
            {
                Id = paymentRecord.Id,
                EmployeeId = paymentRecord.EmployeeId,
                FullName = paymentRecord.FullName,
                Employee = paymentRecord.Employee,
                TaxYearId = paymentRecord.TaxYearId,
                Year = _paymentRecordService.GetTaxYearById(paymentRecord.TaxYearId).YearofTax,
                PayDate = paymentRecord.PayDate,
                PayMonth = paymentRecord.PayMonth,
                HourlyRate = paymentRecord.HourlyRate,
                I_No = paymentRecord.I_No,
                HoursWorked = paymentRecord.HoursWorked,
                OverTimeEarning = paymentRecord.OverTimeEarning,
                OverTimeHours = paymentRecord.OverTimeHours,
                ContractualEarning = paymentRecord.ContractualEarning,
                ContractualHours = paymentRecord.ContractualHours,
                SLC = paymentRecord.SLC,
                TaxCode = paymentRecord.TaxCode,
                Tax = paymentRecord.Tax,
                UnionFee = paymentRecord.UnionFee,
                TotalEarnings = paymentRecord.TotalEarnings,
                TotalDeductions = paymentRecord.TotalDeductions,
                NetPayment = paymentRecord.NetPayment
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Payslip(int id)
        {
            var paymentRecord = _paymentRecordService.GetById(id);
            if (paymentRecord == null)
            {
                return NotFound();
            }
            var model = new PaymentRecordDetailViewmodel()
            {
                Id = paymentRecord.Id,
                EmployeeId = paymentRecord.EmployeeId,
                FullName = paymentRecord.FullName,
                Employee = paymentRecord.Employee,
                TaxYearId = paymentRecord.TaxYearId,
                Year = _paymentRecordService.GetTaxYearById(paymentRecord.TaxYearId).YearofTax,
                PayDate = paymentRecord.PayDate,
                PayMonth = paymentRecord.PayMonth,
                HourlyRate = paymentRecord.HourlyRate,
                I_No = paymentRecord.I_No,
                HoursWorked = paymentRecord.HoursWorked,
                OverTimeEarning = paymentRecord.OverTimeEarning,
                OverTimeHours = paymentRecord.OverTimeHours,
                ContractualEarning = paymentRecord.ContractualEarning,
                ContractualHours = paymentRecord.ContractualHours,
                SLC = paymentRecord.SLC,
                TaxCode = paymentRecord.TaxCode,
                Tax = paymentRecord.Tax,
                UnionFee = paymentRecord.UnionFee,
                TotalEarnings = paymentRecord.TotalEarnings,
                TotalDeductions = paymentRecord.TotalDeductions,
                NetPayment = paymentRecord.NetPayment
            };
            return View(model);
        }

        public IActionResult GeneratePaySlipPDF(int id)
        {
            var payslip = new ActionAsPdf("Payslip", new { id = id })
            {
                FileName = "PaySlip.pdf"
            };
            return payslip;
        }

    }
}
