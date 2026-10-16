using E_CommerceMangementSystem.Dtos.AuthDtos;
using E_CommerceMangementSystem.Models;
using E_CommerceMangementSystem.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_CommerceMangementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork u;
        public AuthController(IUnitOfWork u)
        {
            this.u = u;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var log = await u.Auth.Login(dto);
            if (log == null)
            {
                return Unauthorized("Unaouthorized");
            }
            return Ok(log);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var data = new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                Password = dto.Password,
                Role = dto.Role,
            };

            var reg = await u.Auth.register(data);
            if (!reg)
            {
                return BadRequest("Alredy regidted");
            }
            return Ok("Registerd");
        }
    }
}
