using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImprumuturiController : ControllerBase
    {
        private readonly IImprumutService _imprumutService;

        public ImprumuturiController(IImprumutService imprumutService)
        {
            _imprumutService = imprumutService;
        }

        // GET: api/Imprumuturi
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Imprumut>>> GetAll()
        {
            return Ok(await _imprumutService.GetAll());
        }

        // GET: api/Imprumuturi/5
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Imprumut>> GetById(int id)
        {
            var imprumut = await _imprumutService.GetById(id);

            if (imprumut == null)
            {
                return NotFound();
            }

            return Ok(imprumut);
        }

        // POST: api/Imprumuturi
        [HttpPost("create")]
        public async Task<ActionResult<Imprumut>> Create(Imprumut imprumut)
        {
            if (_imprumutService.GetById(imprumut.Id) == null)
            {
                return BadRequest("Id already exists");
            }

            return await _imprumutService.AddAsync(imprumut);
        }

        // PUT: api/Imprumuturi
        [HttpPut("updateById/{id}")]
        public async Task<IActionResult> Update(int id, Imprumut imprumutIn)
        {
            var imprumut = _imprumutService.GetById(id);

            if (imprumut == null)
            {
                return NotFound();
            }

            return Ok(await _imprumutService.UpdateAsync(id, imprumutIn));
        }

        // DELETE: api/Imprumuturi
        [HttpDelete("deleteById/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var imprumut = _imprumutService.GetById(id);

            if (imprumut == null)
            {
                return NotFound();
            }

            return Ok(await _imprumutService.DeleteAsync(id));
        }
        
        [HttpGet("getActiveRents")]
        public async Task<ActionResult<List<Imprumut>>> GetActiveRents()
        {
            return Ok(await _imprumutService.GetActiveRents());
        }
        
        [HttpGet("getPastRent")]
        public async Task<ActionResult<List<Imprumut>>> GetPastRent()
        {
            return Ok(await _imprumutService.GetPastRent());
        }

        [HttpGet("getNumberOfActiveRents")]
        public ActionResult<int> GetNumberOfActiveRents()
        {
            return Ok(_imprumutService.GetNumberOfActiveRents());
        }
    }
}