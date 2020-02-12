using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Payroll_Entity;
using Payroll_Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ThePayrollApp.Models;

namespace ThePayrollApp.Controllers
{
    public class EmployeeController : Controller
    {
            private readonly IEmployeeService _EmployeeService;
        private readonly HostingEnvironment _hostingEnvironment;
            public EmployeeController (IEmployeeService EmployeeService, HostingEnvironment hostingEnvironment)
            {
                _EmployeeService = EmployeeService;
            _hostingEnvironment = hostingEnvironment;
            }
        public IActionResult Index()
        {
            var employees = _EmployeeService.GetAll().Select(employee => new EmployeeIndexViewmodel
            {
                Id = employee.Id,
                EmployeeNo = employee.EmpNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                ImageUrl = employee.ImageUrl,
                PostalCode = employee.PostalCode,
                DateJoined = employee.DateJoined,
                Designation = employee.Designation,
                Email = employee.Email,
                City = employee.City,
            }).ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewmodel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateViewmodel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    EmpNo = model.EmpNo,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Address = model.Address,
                    City = model.City,
                    PostalCode = model.PostalCode,
                    PhoneNumber = model.PhoneNumber,
                    DOB = model.DOB,
                    DateJoined = model.DateJoined,
                    Designation = model.Designation,
                    Email = model.Email,
                    NationalInsuranceNo = model.NationalInsuranceNo,
                    PaymentMethod = model.PaymentMethod,
                    StudentLoan = model.StudentLoan,
                    UnionMember = model.UnionMember,

                };
                if(model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var UploadDir = @"Images/employeeDP";
                    var Filename = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var Extension = Path.GetExtension(model.ImageUrl.FileName);
                    var WebRoot = _hostingEnvironment.WebRootPath;
                    Filename = DateTime.UtcNow.ToString("yyyymmdd") + Filename + Extension;
                    var path = Path.Combine(WebRoot, UploadDir, Filename);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + UploadDir + "/" + Filename;
                }
                await _EmployeeService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }

        public IActionResult Edit(int Id)
        {
            var employee = _EmployeeService.GetById(Id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeEditViewmodel()
            {
                Id = employee.Id,
                EmpNo = employee.EmpNo,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Address = employee.Address,
                City = employee.City,
                PostalCode = employee.PostalCode,
                PhoneNumber = employee.PhoneNumber,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                Designation = employee.Designation,
                Email = employee.Email,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditViewmodel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _EmployeeService.GetById(model.Id);
                if (employee == null)
                {
                    return NotFound();
                }
                employee.EmpNo = model.EmpNo;
                employee.FirstName = model.FirstName;
                employee.MiddleName = model.MiddleName;
                employee.LastName = model.LastName;
                employee.NationalInsuranceNo = model.NationalInsuranceNo;
                employee.PhoneNumber = model.PhoneNumber;
                employee.Email = model.Email;
                employee.Gender = model.Gender;
                employee.DOB = model.DOB;
                employee.Designation = model.Designation;
                employee.DateJoined = model.DateJoined;
                employee.City = model.City;
                employee.Address = model.Address;
                employee.PostalCode = model.PostalCode;
                employee.PaymentMethod = model.PaymentMethod;
                employee.StudentLoan = model.StudentLoan;
                employee.UnionMember = model.UnionMember;
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var UploadDir = @"Images/employeeDP";
                    var Filename = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var Extension = Path.GetExtension(model.ImageUrl.FileName);
                    var WebRoot = _hostingEnvironment.WebRootPath;
                    Filename = DateTime.UtcNow.ToString("yyyymmdd") + Filename + Extension;
                    var path = Path.Combine(WebRoot, UploadDir, Filename);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + UploadDir + "/" + Filename;
                }
                await _EmployeeService.UpdateAsync(employee);
                 return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Detail(int Id)
        {
            var employee = _EmployeeService.GetById(Id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeDetailViewmodel model = new EmployeeDetailViewmodel()
            {
                Id = employee.Id,
                EmpNo = employee.EmpNo,
                FullName = employee.FullName,
                DateJoined = employee.DateJoined,
                PhoneNumber = employee.PhoneNumber,
                PostalCode = employee.PostalCode,
                Address = employee.Address,
                City = employee.City,
                Designation = employee.Designation,
                DOB = employee.DOB,
                Email = employee.Email,
                Gender = employee.Gender,
                ImageUrl = employee.ImageUrl,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var employee = _EmployeeService.GetById(Id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeDeleteViewmodel model = new EmployeeDeleteViewmodel()
            {
                Id = employee.Id,
                FullName = employee.FullName
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeDeleteViewmodel model)
        {
            await _EmployeeService.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
