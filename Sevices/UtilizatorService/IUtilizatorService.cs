using WebApplication1.Models;

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
        void DeleteUser(int id);
    }
}