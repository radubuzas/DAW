using WebApplication1.Models;

namespace WebApplication1.Repository.CarteRepository
{

    public interface ICarteRepository
    {
        //create
        Task<Carte> AddAsync(Carte carte);
        
        
        //read
        Task<List<Carte>> GetAll();
        Task<List<Carte>> GetByAuthor(int idAutor);
        Task<List<Carte>> GetByGenre(string genre);
        
        Carte GetById(int id);

        //update
        Task<bool> UpdateAsync(int idCarte, Carte carte);
        
        //delete
        Task<bool> DeleteAsync(int id);
        
        //save
        Task<bool> SaveAsync();
        
    }
}