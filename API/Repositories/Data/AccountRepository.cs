using API.Context;
using API.Handlers;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Repositories.Data
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
                    Id = data.Id,
                    FullName = data.Employee.FullName,
                    Email = data.Employee.Email,
                    Role = data.Role.Name
                };
                return login;
            }
            return null;
        }
    }
}
