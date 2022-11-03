using API.Context;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        private readonly MyContext myContext;

        public AccountRepository(MyContext context)
        {
            myContext = context;
        }

        public ResponseLogin Login()
        {
            if (email != null)
            {
                var data = myContext.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
                var result = Hashing.ValidatePassword(password, data.Password);
                if (result == true)
                {
                    HttpContext.Session.SetInt32("Id", data.Id);
                    HttpContext.Session.SetString("FullName", data.Employee.FullName);
                    HttpContext.Session.SetString("Email", data.Employee.Email);
                    HttpContext.Session.SetString("Role", data.Role.Name);

                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return 3;
        }
    }
}
