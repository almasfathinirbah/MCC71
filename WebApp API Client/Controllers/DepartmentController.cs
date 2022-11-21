using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Migrations;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        /*MyContext myContext;
        public DepartmentController(MyContext myContext)
        {
            this.myContext = myContext;
        }*/

        // Get All
        public IActionResult Index()
        {
            /*var Role = HttpContext.Session.GetString("Role");
            if (Role == "Admin")
            {
                var data = myContext.Departments.ToList();
                return View(data);
            }
            else if (Role == null)
            {
                return RedirectToAction("UnAuthorized", "ErrorPage");
            }
            return RedirectToAction("Forbidden", "ErrorPage");*/
            /*var data = myContext.Departments.ToList();
            return View(data);*/
            return View();
        }

        // Get by ID
        /*public IActionResult Details(int Id)
        {
            var data = myContext.Departments.Find(Id);
            return View(data);
        }*/

        // Insert - Get Post
        public IActionResult Create()
        {
            return View();
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            department.CreatedBy = HttpContext.Session.GetString("FullName");
            department.CreatedDate = DateTime.Now.ToLocalTime();
            myContext.Departments.Add(department);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Department");
            return View();
        }*/

        // Update - Get Post
        /*public IActionResult Edit(int Id)
        {
            var data = myContext.Departments.Find(Id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, Department department)
        {
            var data = myContext.Departments.Find(Id);
            if (data != null)
            {
                data.Name = department.Name;
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index", "Department");
            }
            return View();
        }

        // Delete - Get Post
        public IActionResult Delete(int Id)
        {
            var data = myContext.Departments.Find(Id);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department)
        {
            myContext.Departments.Remove(department);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Department");
            return View();
        }*/
    }
}
