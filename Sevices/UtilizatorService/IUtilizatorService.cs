using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUtilizatorService
    {
        List<Utilizator> GetAll();
        
        public bool EmailExists(string email);
        
        Utilizator Get(int id);
        Utilizator Create(Utilizator user);
        bool ModifyPassword(int userId, string newPassword);
        void Update(int id, Utilizator userIn);
        void Remove(int id);
    }
}