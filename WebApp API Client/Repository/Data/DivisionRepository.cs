using WebApp.Context;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace API_JWT.Repositories.Data
{
    public class DivisionRepository : GeneralRepository<Division>
    {
        private MyContext _context;
        public DivisionRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        //Get All
        public IEnumerable<Division> Get()
        {
            return _context.Divisions.ToList();
        }

        //Get by Id
        public Division GetById(int Id)
        {
            return _context.Divisions.Find(Id);
        }

        //Create 
        public int Create(Division division)
        {
            _context.Divisions.Add(division);
            var result = _context.SaveChanges();
            return result;
        }

        //Update
        public int Update(Division division)
        {
            _context.Entry(division).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }

        //Delete
        public int Delete(int Id)
        {
            var data = _context.Divisions.Find(Id);
            if(data != null)
            {
                _context.Remove(data);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }        
    }
}
