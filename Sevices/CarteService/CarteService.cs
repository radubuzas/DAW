using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Services
{
    public class CarteService : ICarteService
    {
        private readonly DBCTX _context;

        public CarteService(DBCTX context)
        {
            _context = context;
        }

        public List<Carte> GetAll()
        {
            return _context.Carti.ToList();
        }

        public Carte Get(int id)
        {
            return _context.Carti.Find(id);
        }

        public Carte Create(Carte book)
        {
            _context.Carti.Add(book);
            _context.SaveChanges();
            return book;
        }

        public void Update(int id, Carte bookIn)
        {
            var book = _context.Carti.Find(id);
            if (book != null)
            {
                book.Titlu = bookIn.Titlu;
                book.CarteAutori = bookIn.CarteAutori;
                book.Gen = bookIn.Gen;
                book.ISBN = bookIn.ISBN;
                book.ExemplareDisponibile = bookIn.ExemplareDisponibile;
                book.ExemplareTotale = bookIn.ExemplareTotale;

                _context.Carti.Update(book);
                _context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            var book = _context.Carti.Find(id);
            if (book != null)
            {
                _context.Carti.Remove(book);
                _context.SaveChanges();
            }
        }
        
        // În CarteService.cs

        public List<IGrouping<string, Carte>> CartiDupaGen()
        {
            return _context.Carti.GroupBy(c => c.Gen).ToList();
        }

        public List<Carte> CartiCuDescriere()
        {
            return _context.Carti.Include(c => c.DescriereCarte).ToList();
        }

        public List<Carte> CartiDupaTitlu(string substring)
        {
            return _context.Carti.Where(c => c.Titlu.Contains(substring)).ToList();
        }

        
        
    }
}