using WebApp.Context;
using WebApp.Handlers;
using WebApp.Models;
using WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Repository.Data
{
    public class AccountRepository
    {
        MyContext myContext;

        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public ResponseLogin Login(string email, string password)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            var validate = Hashing.ValidatePassword(password, data.Password);

            if (data != null && validate)
            {
                ResponseLogin login = new ResponseLogin()
                {
                    //Id = data.Id,
                    FullName = data.Employee.FullName,
                    Email = data.Employee.Email,
                    Role = data.Role.Name
                };
                return login;
            }
            return null;
        }

        public int Register(string fullName, string email, DateTime birthDate, string password)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            if (data == null)
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
                        return 2;
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int ChangePassword(string email, string password, string confirm)
        {
            if (email != null)
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
                        return 1;
                    }
                }
            }
            return 0;
        }

        public int ForgotPassword(string email, string confirm)
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
                    return 1;
                }
            }
            return 0;
        }
    }
}
