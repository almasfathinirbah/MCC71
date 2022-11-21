using WebApp.Context;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using API_JWT.Repositories;

namespace WebApp.Repositories.Data
{
    public class DepartmentRepository : GeneralRepository<Department>
    {
        private readonly MyContext _context;

        public DepartmentRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Department> Get()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int Id)
        {
            return _context.Departments.Find(Id);
        }

        public int Create(Department department)
        {
            _context.Departments.Add(department);
            var result = _context.SaveChanges();
            return result;
        }

        public int Update(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }

        public int Delete(int Id)
        {
            var data = _context.Departments.Find(Id);
            if (data != null)
            {
                _context.Remove(data);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }
    }
}
