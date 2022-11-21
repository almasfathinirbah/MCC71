using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using WebApp.Context;
using WebApp.Models;
using WebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using WebApp.Handlers;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        MyContext myContext;

        public AccountController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if(email != null)
            {
                var data = myContext.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
                var result = Hashing.ValidatePassword(password, data.Password);
                if(result == true)
                {
                    HttpContext.Session.SetInt32("Id", data.Id);
                    HttpContext.Session.SetString("FullName", data.Employee.FullName);
                    HttpContext.Session.SetString("Email", data.Employee.Email);
                    HttpContext.Session.SetString("Role", data.Role.Name);

                    return RedirectToAction("Index", "Home");                    
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }                
            }
            return View();

        }

        //Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string fullName, string email, DateTime birthDate, string password)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            if (data != null)
            {
                return View();
            }
            else
            {
                Employee employee = new Employee()
                {
                    FullName = fullName,
                    Email = email,
                    BirthDate = birthDate
                };
                myContext.Employees.Add(employee);
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    var id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(email)).Id;
                    User user = new User()
                    {
                        Id = id,
                        Password = Hashing.HashPassword(password),
                        RoleId = 1
                    };
                    myContext.Users.Add(user);
                    var resultUser = myContext.SaveChanges();
                    if (resultUser > 0)
                        return RedirectToAction("Login", "Account");
                }
                return View();
            }
        }

        //Change Password
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(string email, string password, string confirm)
        {
            if(email != null)
            {
                var data = myContext.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .AsNoTracking()
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
                myContext.SaveChanges();
                var result = Hashing.ValidatePassword(password, data.Password);
                if (result == true)
                {
                    User user = new User()
                    {
                        Id = data.Id,
                        Password = Hashing.HashPassword(confirm),
                        RoleId = data.RoleId
                    };
                    myContext.Entry(user).State = EntityState.Modified;
                    var resultUser = myContext.SaveChanges();
                    if (resultUser > 0)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
            }            
            return View();
        }

        //Forgot Password
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email, string confirm)
        {
            var data = myContext.Users
               .Include(x => x.Employee)
               .AsNoTracking()
               .SingleOrDefault(x => x.Employee.Email.Equals(email));
            myContext.SaveChanges();
            if (data != null)
            {
                data.Password = Hashing.HashPassword(confirm);
                myContext.Entry(data).State = EntityState.Modified;
                var resultUser = myContext.SaveChanges();
                if (resultUser > 0)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View();
        }
    }
}