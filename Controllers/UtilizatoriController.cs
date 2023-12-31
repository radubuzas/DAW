using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Helpers.Attributes;
using WebApplication1.Models.Enums;

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

        [Authorization(Role.User)]
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
        
        [Authorization(Role.Admin)]
        [HttpGet("getAllUsers")]
        public List<Utilizator> GetAll()
        {
            return _utilizatorService.GetAll();
        }
        
        
        
        [HttpPut("ModifyPasswordById/{Id}")]
        public IActionResult ModifyPassword(int Id, string Parola)
        {
            if (_utilizatorService.ModifyPassword(Id, Parola))
            {
                return Ok();
            }
            return BadRequest();
        }
        
        [Authorization(Role.Admin, Role.User)]
        [HttpGet("GetImprumuturiByUser")]
        public List<Imprumut> GetImprumuturiByUser(int Id)
        {
            return _utilizatorService.GetImprumuturiByUser(Id);
        }
        
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int Id)
        {
            _utilizatorService.DeleteUser(Id);
            return Ok();
        }
    }
}