using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizatoriController : ControllerBase
    {
        private readonly IUtilizatorService _utilizatorService;

        public UtilizatoriController(IUtilizatorService utilizatorService)
        {
            _utilizatorService = utilizatorService;
        }

        [HttpPost("register")]
        public IActionResult Register(Utilizator utilizator)
        {
            if (_utilizatorService.EmailExists(utilizator.Email)) {
                return BadRequest(new { message = "Email already exists" });
            }
            try
            {
                var newUser = _utilizatorService.Create(utilizator);
                return Ok(newUser);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("getAllUsers")]
        public List<Utilizator> GetAll()
        {
            return _utilizatorService.GetAll();
        }
        
        [HttpPut("ModifyPasswordById/{Id}")]
        public IActionResult ModifyPassword(Guid Id, string Parola)
        {
            if (_utilizatorService.ModifyPassword(Id, Parola))
            {
                return Ok();
            }
            return BadRequest();
        }
        
        [HttpGet("GetImprumuturiByUser")]
        public List<Imprumut> GetImprumuturiByUser(Guid Id)
        {
            return _utilizatorService.GetImprumuturiByUser(Id);
        }
        
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(Guid Id)
        {
            _utilizatorService.DeleteUser(Id);
            return Ok();
        }
    }
}