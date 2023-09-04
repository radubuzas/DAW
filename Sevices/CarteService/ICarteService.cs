using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ICarteService
    {
        //create
        Task<Carte> AddAsync(Carte carte);
            
        //read
        Task<List<Carte>> GetAll();
        Task<List<Carte>> GetByAuthor(int idAutor);
        Task<List<Carte>> GetByGenre(string genre);
        Carte GetById(int id);

        //update
        Task<bool> UpdateAsync(Carte carte); 
            
        //delete
        Task<bool> DeleteAsync(int id);
            
        //save
        Task<bool> SaveAsync();
    }
}