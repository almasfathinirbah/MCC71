using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories.Interface;

namespace WebApp.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Repository, Entity> : ControllerBase
        where Repository : class, IRepository<Entity>
        where Entity : class
    {
        Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = repository.Get();
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data has beeen Retrieved",
                data = data
            });
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            var data = repository.GetById(Id);
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data has beeen Retrieved",
                data = data
            });
        }

        [HttpPost]
        public IActionResult Create(Entity entity)
        {
            var data = repository.Create(entity);
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data has beeen Retrieved",
                data = data
            });
        }

        [HttpPut]
        public IActionResult Update(Entity entity)
        {
            var data = repository.Update(entity);
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data has beeen Retrieved",
                data = data
            });
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var data = repository.Delete(Id);
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data has beeen Retrieved",
                data = data
            });
        }
    }
}
