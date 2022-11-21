using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DivisionController : Controller
    {
        /*MyContext myContext;
        public DivisionController(MyContext myContext)
        {
            this.myContext = myContext;
        }*/

        // Get All
        public IActionResult Index()
        {
            /*var Role = HttpContext.Session.GetString("Role");
            if(Role == "Admin")
            {
                var data = myContext.Divisions.ToList();
                return View(data);
            }
            else if (Role == null)
            {
                return RedirectToAction("UnAuthorized", "ErrorPage");
            }
            return RedirectToAction("Forbidden", "ErrorPage");*/
            /*var data = myContext.Divisions.ToList();
            return View(data);*/
            return View();
        }

        // Get by ID
        /*public IActionResult Details(int Id)
        {
            var data = myContext.Divisions.Find(Id);
            return View(data);
        }*/

        // Insert - Get Post
        public IActionResult Create()
        {
            return View();
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Division division)
        {
            division.CreatedBy = HttpContext.Session.GetString("FullName");
            division.CreatedDate = DateTime.Now.ToLocalTime();
            myContext.Divisions.Add(division);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Division");
            return View();
        }

        // Update - Get Post
        public IActionResult Edit(int Id)
        {
            var data = myContext.Divisions.Find(Id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, Division division)
        {
            var data = myContext.Divisions.Find(Id);
            if (data != null)
            {
                data.Name = division.Name;
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index", "Division");
            }
            return View();
        }

        // Delete - Get Post
        public IActionResult Delete(int Id)
        {
            var data = myContext.Divisions.Find(Id);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Division division)
        {
            myContext.Divisions.Remove(division);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Division");
            return View();
        }*/
    }
}
