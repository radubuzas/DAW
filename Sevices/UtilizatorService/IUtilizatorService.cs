using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
    public interface IUtilizatorService
    {
        List<Utilizator> GetAll();
        
        public bool EmailExists(string email);
        
        Utilizator GetById(int id);
        Utilizator Create(Utilizator user);
        bool ModifyPassword(int userId, string newPassword);
        List<Imprumut> GetImprumuturiByUser(int id);
        UserResponseDTO Authenticate(UserRequestDTO model);
        Task Create(UserRequestDTO newUser);
        void DeleteUser(int id);
    }
}