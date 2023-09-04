using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Repository.CarteRepository;

public class CarteRepository : ICarteRepository
{
    private readonly DBCTX _context;
    private readonly DbSet<Carte> _table;

    public CarteRepository(DBCTX context)
    {
        _context = context;
        _table = _context.Set<Carte>();
    }
    
    public async Task<List<Carte>> GetAll()
    {
        return await _table.AsNoTracking().ToListAsync();
    }
    
    public async Task<Carte> AddAsync(Carte carte)
    {
        await _table.AddAsync(carte);
        await _context.SaveChangesAsync();
        return carte;
    }
    
    public async Task<bool> UpdateAsync(Carte carte)
    {
        _table.Update(carte);
        _context.Entry(carte).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var carte = await _table.FindAsync(id);
        if (carte == null)
        {
            return false;
        }
        _table.Remove(carte);
        await _context.SaveChangesAsync();
        return true;
    }
    

    public async Task<bool> SaveAsync()
    {
        try
        {
            return (await _context.SaveChangesAsync()) > 1;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<List<Carte>> GetByAuthor(int idAutor)
    {
        return await _table.AsNoTracking().Where(c => c.CarteAutori.Any(ca => ca.AutorId == idAutor)).ToListAsync();
    }
    
    public async Task<List<Carte>> GetByGenre(string genre)
    {
        return await _table.AsNoTracking().Where(c => c.Gen.ToLower().Equals(genre.ToLower())).ToListAsync();
    }
    
    public Carte GetById(int id)
    {
        return _table.Find(id);
    }

}