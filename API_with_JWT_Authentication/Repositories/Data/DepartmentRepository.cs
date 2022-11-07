using API.Context;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class DepartmentRepository : IRepository<Department, int>
    {
        private readonly MyContext _context;

        public DepartmentRepository(MyContext context)
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

        public int Create(Department Entity)
        {
            _context.Departments.Add(Entity);
            var result = _context.SaveChanges();
            return result;
        }

        public int Update(Department Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
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
