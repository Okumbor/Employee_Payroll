using Microsoft.AspNetCore.Mvc;
using Payroll_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThePayrollApp.Controllers
{
    public class EmployeeController : Controller
    {
            private readonly IEmployeeService _EmployeeService; 
            public EmployeeController (IEmployeeService EmployeeService)
            {
                _EmployeeService = EmployeeService;
            }
        public IActionResult Index()
        {
            var 
            return View();
        }
    }
}
