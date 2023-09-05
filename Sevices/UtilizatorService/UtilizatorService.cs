using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Helpers.JwtUtils;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models.DTO;
using WebApplication1.Repository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace WebApplication1.Services.UtilizatorService
{
    public class UtilizatorService : IUtilizatorService
    {
        private readonly IUtilizatorRepository _repository;
        private readonly JwtUtils _jwtUtils;

        public UtilizatorService(IUtilizatorRepository repository, JwtUtils jwtUtils)
        {
            _repository = repository;
            _jwtUtils = jwtUtils;
        }

        public List<Utilizator> GetAll()
        {
            return _repository.GetAll();
        }
        
        public Utilizator GetById(int id)
        {
            return _repository.GetById(id);
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

        public void DeleteUser(int id)
        {
            try
            {
                _repository.Delete(id);
                _repository.Update();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public bool EmailExists(string email)
        {
            return _repository.EmailExists(email);
        }
        
        public List<Imprumut> GetImprumuturiByUser(int id)
        {
            return _repository.GetImprumuturiByUser(id);
        }

        public UserResponseDTO Authenticate(UserRequestDTO model)
        {   
            var user = _repository.FindByEmail(model.Email);
            if (user == null)
            {
                return null;
            }
            
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new UserResponseDTO(user, jwtToken);
        }

        public Task Create(UserRequestDTO newUser)
        {
            throw new NotImplementedException();
        }
        
    }
}