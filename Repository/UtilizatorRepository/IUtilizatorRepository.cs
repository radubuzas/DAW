using WebApplication1.Models;

namespace WebApplication1.Repository
{

    public interface IUtilizatorRepository
    {
        List<Utilizator> GetAll();
        Task<Utilizator> Create(Utilizator utilizator);
        
        Task<Utilizator> UpdatePassword(Utilizator utilizator);
        Utilizator GetByEmail(string email);
        Utilizator GetById(int id);
        bool EmailExists(string email);
        List<Imprumut> GetImprumuturiByUser(int id);
        Task<bool> Update();
        
        Utilizator FindByEmail(string email);
        
        void Delete(int id);
    }
}