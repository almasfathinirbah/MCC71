namespace WebApp.Repositories.Interface
{
    public interface IRepository<Entity> where Entity : class
    {
        public List<Entity> Get();
        public Entity GetById(int Id);
        public int Create(Entity Entity);
        public int Update(Entity Entity);
        public int Delete(int Id);
    }
}
