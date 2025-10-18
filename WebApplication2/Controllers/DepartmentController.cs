using Azure.Core;
using BIL.Services;
using Demo.BLL.DataTransferObjects;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class DepartmentsController(IDepartmentService departmentService, ILogger<DepartmentsController> logger, IWebHostEnvironment env) : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            var departments = departmentService.GetAll();

            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = departmentService.Add(request);
                if (result > 0)
                    return RedirectToAction("Index");
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
            var department = departmentService.GetById(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var department = departmentService.GetById(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            return View(department.ToUpdateRequest());
        }
        [HttpPost]
        public IActionResult Edit(DepartmentUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = departmentService.Update(request);
                if (result > 0)
                    return RedirectToAction("Index");
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
            var department = departmentService.GetById(id.Value);

            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (ModelState.IsValid)
            {
                var result = departmentService.Delete(id.Value);
                if (result  )
                    return RedirectToAction("Index");
                ModelState.AddModelError(string.Empty, "cant");
                return View(result);
            }
            return View();
        }

    }
}
