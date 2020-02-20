using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Payroll_Domain;
using Payroll_Entity;

namespace Payroll_Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private decimal studentLoan;
        private decimal fee;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Employee newEmployee)
        {
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
        }
        public Employee GetById(int employeeId) => 
            _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

        public async Task Delete(int employeeId)
        {
            var Employee = GetById(employeeId);
            _context.Remove(Employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll() => _context.Employees;

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int Id)
        {
            var Employee = GetById(Id);
            _context.Update(Employee);
            await _context.SaveChangesAsync();
        }
        public decimal StudentLoanRepaymentAmount(int Id, decimal TotalAmount)
        {
            var EmployeeStu = GetById(Id);
            if (EmployeeStu.StudentLoan == StudentLoan.Yes && TotalAmount >= 200000 && TotalAmount < 400000)
            {
                studentLoan = 50000m;
            }
            else if (EmployeeStu.StudentLoan == StudentLoan.Yes && TotalAmount >= 400000 && TotalAmount < 600000)
            {
                studentLoan = 100000m;
            }
            else if (EmployeeStu.StudentLoan == StudentLoan.Yes && TotalAmount >= 600000 && TotalAmount < 800000)
            {
                studentLoan = 150000m;
            }
            else if (EmployeeStu.StudentLoan == StudentLoan.Yes && TotalAmount >= 800000 && TotalAmount < 1000000)
            {
                studentLoan = 200000m;
            }
            else if (EmployeeStu.StudentLoan == StudentLoan.Yes && TotalAmount >= 1000000)
            {
                studentLoan = 400000m;
            }
            else
            {
                studentLoan = 0m;
            }
            return studentLoan;
        }

        public decimal UnionFee(int Id)
        {
            var EmployeeUnion = GetById(Id);
            if (EmployeeUnion.UnionMember == UnionMember.Yes)
            {
                fee = 1800m;
            }
            else
            {
                fee = 0m;
            }
            return fee;
        }

        public IEnumerable<SelectListItem> GetAllEmployeesForPayController()
        {
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.FullName,
                Value = emp.Id.ToString()
            });
        }
    }
}
