using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {
        private readonly DivisionRepository _repository;

        public DivisionsController(DivisionRepository divisionRepository)
        {
            _repository = divisionRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var data = _repository.Get();
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Ditemukan"
                    }); 
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Ditemukan",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            try
            {
                var data = _repository.GetById(Id);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Ditemukan"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Ditemukan",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public ActionResult Create(Division division)
        {
            try
            {
                var result = _repository.Create(division);
                if (result == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Gagal Disimpan"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Disimpan",
                        Result = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpPut]
        public ActionResult Update(Division division)
        {
            try
            {
                var result = _repository.Update(division);
                if (result == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Gagal Di Update"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Date Berhasil Di Update",
                        Result = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            try
            {
                var result = _repository.Delete(Id);
                if (result == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Gagal Di Hapus"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Di Hapus",
                        Result = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
    }
}
