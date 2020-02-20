using Microsoft.AspNetCore.Mvc.Rendering;
using Payroll_Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Services
{
    public interface IEmployeeService
    {
        Task CreateAsync(Employee newEmployee);
        Employee GetById(int employeeId);
        Task UpdateAsync(Employee employee);
        Task UpdateAsync(int Id);
        Task Delete(int employeeId);
        decimal UnionFee(int Id);
        decimal StudentLoanRepaymentAmount(int Id, decimal TotalAmount);
        IEnumerable<Employee> GetAll();
        IEnumerable<SelectListItem> GetAllEmployeesForPayController();
    }
}
