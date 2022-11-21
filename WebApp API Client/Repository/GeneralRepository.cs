using WebApp.Context;
using WebApp.Repositories.Interface;

namespace API_JWT.Repositories
{
    public class GeneralRepository<Entity> : IRepository<Entity>
        where Entity : class
    {
        MyContext myContext;

        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int Id)
        {
            var data = GetById(Id);
            myContext.Set<Entity>().Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Entity> Get()
        {
            var data = myContext.Set<Entity>().ToList();
            return data;
        }

        public Entity GetById(int Id)
        {
            
            var data = myContext.Set<Entity>().Find(Id);
            return data;
        }

        public int Create(Entity entity)
        {
            myContext.Set<Entity>().Add(entity);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Update(Entity entity)
        {
            myContext.Set<Entity>().Update(entity);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
