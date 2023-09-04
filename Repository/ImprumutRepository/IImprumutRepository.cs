using WebApplication1.Models;

namespace WebApplication1.Repository
{

    public interface IImprumutRepository
    {
        Task<List<Imprumut>> GetAll();
        Task<Imprumut> AddAsync(Imprumut imprumut);
        Task<bool> UpdateAsync(int IdImprumut, Imprumut imprumut);
        Task<bool> DeleteAsync(int id);
        Task<bool> SaveAsync();
        
        Task<List<Imprumut>> GetActiveRents();
        Task<List<Imprumut>> GetPastRent();
        Task<Imprumut> GetById(int id);
        
        int GetNumberOfActiveRents();
    }

}