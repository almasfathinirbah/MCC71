using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IConfiguration _configuration;

        private AccountRepository accountRepository;

        public AccountController(IConfiguration configuration, AccountRepository accountRepository)
        {
            this._configuration = configuration;
            this.accountRepository = accountRepository;
        }

        [HttpPost("Login")]
        public IActionResult Login(string email, string password)
        {
            try
            {
                ResponseLogin login = accountRepository.Login(email,password);
                if(login == null)
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
                        Message = "Login Berhasil",
                        Put = login
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { StatusCode = 400, Message = e.Message });
            }
        }

        [HttpPost("Register")]
        public IActionResult Register(string fullName, string email, DateTime birthDate, string password)
        {
            try
            {
                var register = accountRepository.Register(fullName, email, birthDate, password);
                if (register == 2)
                    return Ok(new { StatusCode = 200, Message = "Registrasi Berhasil" });
                else if (register == 1)
                    return Ok(new { StatusCode = 200, Message = "Data Telah Digunakan" });
                else if (register == 0)
                    return Ok(new { StatusCode = 200, Message = "Gagal Registrasi" });
                else
                    return Ok(new { StatusCode = 200, Message = "Masih Gagal Registrasi" });
            }
            catch (Exception e)
            {
                return BadRequest(new { StatusCode = 400, Message = e.Message });
            }
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(string email, string password, string confirm)
        {
            try
            {
                var change = accountRepository.ChangePassword(email, password, confirm);
                if (change == 1)
                    return Ok(new { StatusCode = 200, Message = "Pergantian Password Berhasil" });
                if (change == 0)
                    return Ok(new { StatusCode = 200, Message = "Pergantian Password Gagal" });
                return Ok(new { StatusCode = 200, Message = "Pergantian Password Tetap Gagal" });
            }   
            catch (Exception e)
            {
                return BadRequest(new { StatusCode = 400, Message = e.Message });
            }
        }

        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(string email, string confirm)
        {
            try
            {
                var change = accountRepository.ForgotPassword(email, confirm);
                if (change == 1)
                    return Ok(new { StatusCode = 200, Message = "Pergantian Password Berhasil" });
                if (change == 0)
                    return Ok(new { StatusCode = 200, Message = "Pergantian Password Gagal" });
                return Ok(new { StatusCode = 200, Message = "Pergantian Password Tetap Gagal" });
            }
            catch (Exception e)
            {
                return BadRequest(new { StatusCode = 400, Message = e.Message });
            }
        }

    }
}
