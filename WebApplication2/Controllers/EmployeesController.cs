using AutoMapper;
using BIL.Services;
using BLL.DataTransferObject.Employees;
using Demo.BLL.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace WebApplication2.Controllers
{
    public class EmployeesController(IEmployeeService EmployeeService, ILogger<EmployeesController> logger, IWebHostEnvironment env,IMapper mapper,IDepartmentService departmentService) : Controller
    {

        //transferDate
        //action=>veiw
        //veiw=>layout
        //veiw=>partial
        //veiwDate => one request
        //ViewBag => viewBag.key  
        //tempDate =>two request 


        [HttpGet]
        public IActionResult Index(string? searchvalue)
        {

            if (string.IsNullOrWhiteSpace(searchvalue))
                return View(EmployeeService.GetAll());
            else
                return View(EmployeeService.GetAll(searchvalue));
            //var Employees = EmployeeService.GetAll();
            ////ViewData["message"] = "Employees Page";

            //return View(Employees);
        }
     

            [HttpGet]
        public IActionResult Create()
        {
            var departments = departmentService.GetAll();
            var selectlist = new SelectList(departments, "Id", "Name");
            ViewBag.departments = selectlist;
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = EmployeeService.Add(request);
                if (result > 0)
                {
                    TempData["msg"] = $"Employee{request.Name} Added";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "cant");
                return View(result);
            }
            return View(request);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var Employee = EmployeeService.GetById(id.Value);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var Employee = EmployeeService.GetById(id.Value);
            if (Employee == null)
            {
                return NotFound();
            }
            var departments = departmentService.GetAll();
            var selectlist = new SelectList(departments, "Id", "Name",Employee.DepartmentId);
            ViewBag.departments = selectlist;
            return View(mapper.Map<EmployeeUpdateRequest> (Employee));
        }
        [HttpPost]
        public IActionResult Edit(EmployeeUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = EmployeeService.Update(request);
                if (result > 0)
                {
                    TempData["msg"] = $"Employee{request.Name} edited";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "cant");
                return View(result);
            }
            return View(request);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var Employee = EmployeeService.GetById(id.Value);

            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (ModelState.IsValid)
            {
                var result = EmployeeService.Delete(id.Value);
                if (result)
                    return RedirectToAction("Index");
                ModelState.AddModelError(string.Empty, "cant");
                return View(result);
            }
            return View();
        }
    }
}
