using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using WebApplication1.Services;
using WebApplication1.Services.CarteService;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartiController : ControllerBase
    {
        private readonly ICarteService _carteService;

        public CartiController(ICarteService carteService)
        {
            _carteService = carteService;
        }
        

        // GET: api/Carti
        [HttpGet("getById/{id}")]
        public ActionResult<Carte> Get(int id)
        {
            var book = _carteService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpGet("dupaGen/{gen}")]
        public async Task<ActionResult<Carte>> GetByGenre(string gen)
        {
            var books = await _carteService.GetByGenre(gen);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet("dupaAutor/{idAutor}")]
        public async Task<ActionResult<Carte>> GetByAuthor(int idAutor)
        {
            var books = await _carteService.GetByAuthor(idAutor);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }
        
        // POST: api/Carti
        [HttpPost("create")]
        public async Task<ActionResult<Carte>> Create(Carte book)
        {
            try
            {
                var newBook = await _carteService.AddAsync(book);
                return Ok(newBook);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Carti/5
        [HttpPut("ModifyBookById/{id}")]
        public async Task<IActionResult> Update(int id, Carte bookIn)
        {
            var book = _carteService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            var ret = await _carteService.UpdateAsync(id, bookIn);

            return Ok(ret);
        }

        // DELETE: api/Carti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = _carteService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            var ret = await _carteService.DeleteAsync(id);

            return Ok(ret);
        }
        
        

    }
}