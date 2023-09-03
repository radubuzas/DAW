using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class UtilizatorService : IUtilizatorService
    {
        private readonly IUtilizatorRepository _repository;

        public UtilizatorService(IUtilizatorRepository repository)
        {
            _repository = repository;
        }
        
        public List<Utilizator> GetAll()
        {
            return _repository.GetAll();
        }
        
        public Utilizator Get(int id)
        {
            return null;
        }
        
        public Utilizator Create(Utilizator utilizator)
        {
            Utilizator newUtilizator = new Utilizator{
                    Id = utilizator.Id,
                    Nume = utilizator.Nume,
                    Adresa = utilizator.Adresa,
                    NumarTelefon = utilizator.NumarTelefon,
                    Email = utilizator.Email,
                    Parola = utilizator.Parola,
                };
            _repository.Create(newUtilizator);
            _repository.Update();
            
            return newUtilizator;
        }
        
        public bool ModifyPassword(int userId, string newPassword)
        {
            var user = _repository.GetById(userId);
            if (user == null)
            {
                return false;
            }
            user.Parola = newPassword;
            _repository.UpdatePassword(user);
            return true;
        }
        
        public void Update(int id, Utilizator userIn)
        {
            ;
        }
        
        public void Remove(int id)
        {
            ;
        }
        
        public bool EmailExists(string email)
        {
            return _repository.EmailExists(email);
        }
        
        
    }
}