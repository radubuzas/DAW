using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebApplication1.Repository;
using WebApplication1.Data;
using WebApplication1.Repository.CarteRepository;

namespace WebApplication1.Services.CarteService
{
    public class CarteService : ICarteService
    {
        private readonly ICarteRepository _repository;
        public CarteService(ICarteRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Carte>> GetAll()
        {
            return _repository.GetAll();
        }
        
        public Task<List<Carte>> GetByAuthor(int idAutor)
        {
            return _repository.GetByAuthor(idAutor);
        }
        
        public Task<List<Carte>> GetByGenre(string genre)
        {
            return _repository.GetByGenre(genre);
        }
        
        public Carte GetById(int id)
        {
            return _repository.GetById(id);
        }
        
        public Task<Carte> AddAsync(Carte carte)
        {
            var newCarte = new Carte
            {
                Id = carte.Id,
                Titlu = carte.Titlu,
                CarteAutori = carte.CarteAutori,
                DescriereCarte = carte.DescriereCarte,
                Gen = carte.Gen,
                ExemplareDisponibile = carte.ExemplareDisponibile,
                ExemplareTotale = carte.ExemplareTotale,
                ISBN = carte.ISBN
            };
            var ret = _repository.AddAsync(newCarte);
            _repository.SaveAsync();
            
            return ret;
        }
        
        public async Task<bool> UpdateAsync(Carte carte)
        {
            
            var ret = await _repository.UpdateAsync(carte);
            _repository.SaveAsync();
            return ret;
        }
        
        public Task<bool> DeleteAsync(int id)
        {
            var ret = _repository.DeleteAsync(id);
            _repository.SaveAsync();
            return ret;
        }

        public Task<bool> SaveAsync()
        {
            return _repository.SaveAsync();
        }

    }
}