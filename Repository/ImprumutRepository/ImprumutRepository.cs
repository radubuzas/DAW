using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{

    public class ImprumutRepository : IImprumutRepository
    {
        private readonly DBCTX _context;
        private readonly DbSet<Imprumut> _table;

        public ImprumutRepository(DBCTX context)
        {
            _context = context;
            _table = _context.Set<Imprumut>();
        }

       public async Task<List<Imprumut>> GetAll()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<Imprumut> AddAsync(Imprumut imprumut)
        {
            await _table.AddAsync(imprumut);
            await _context.SaveChangesAsync();
            return imprumut;
        }
        
        public async Task<bool> UpdateAsync(int IdImprumut, Imprumut imprumut)
        {
            var exists = await _table.FindAsync(IdImprumut);
            if (exists == null)
            {
                return false;
            }
            _table.Update(imprumut);
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            var imprumut = await _table.FindAsync(id);
            if (imprumut == null)
            {
                return false;
            }
            _table.Remove(imprumut);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return (await _context.SaveChangesAsync() > 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<List<Imprumut>> GetActiveRents()
        {
            return await _table.AsNoTracking().Where(x => x.DataReturnare == null || x.DataReturnare > DateTime.Now).ToListAsync();
        }
        
        public async Task<List<Imprumut>> GetPastRent()
        {
            return await _table.AsNoTracking().Where(x => x.DataReturnare < DateTime.Now).ToListAsync();
        }
        
        public async Task<Imprumut> GetById(int id)
        {
            return await _table.FindAsync(id);
        }
        
        public int GetNumberOfActiveRents()
        {
            var activeRents = GetActiveRents();
            return activeRents.Result.Count;
        }
    }
}