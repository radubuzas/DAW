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
        public ActionResult<Carte> GetByGenre(string gen)
        {
            var books = _carteService.GetByGenre(gen);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet("dupaAutor/{idAutor}")]
        public ActionResult<Carte> GetByAuthor(int idAutor)
        {
            var books = _carteService.GetByAuthor(idAutor);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }
        
        // POST: api/Carti
        [HttpPost("create")]
        public ActionResult<Carte> Create(Carte book)
        {
            try
            {
                var newBook = _carteService.AddAsync(book);
                return Ok(newBook);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Carti/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Carte bookIn)
        {
            var book = _carteService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            var ret = _carteService.UpdateAsync(id, bookIn);

            return Ok(ret);
        }

        // DELETE: api/Carti/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _carteService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            var ret = _carteService.DeleteAsync(id);

            return Ok(ret);
        }
        
        

    }
}