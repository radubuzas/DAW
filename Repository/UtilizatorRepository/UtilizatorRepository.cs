using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repository
{
    public class UtilizatorRepository : IUtilizatorRepository
    {
        private readonly DBCTX _context;
        protected readonly DbSet<Utilizator> _table;

        public UtilizatorRepository(DBCTX context)
        {
            _context = context;
            _table = _context.Set<Utilizator>();
        }

        public List<Utilizator> GetAll()
        {
            return _context.Utilizatori.ToList();
        }

        public async Task<Utilizator> Create(Utilizator utilizator)
        {
            _context.Utilizatori.Add(utilizator);
            await _table.AddAsync(utilizator);
            await _context.SaveChangesAsync();
            return utilizator;
        }

        public async void Delete(int Id)
        {
            _context.Utilizatori.Remove(GetById(Id));
            await _context.SaveChangesAsync();
            _table.Remove(GetById(Id));
        }

        public Utilizator GetByEmail(string email)
        {
            return _context.Utilizatori.FirstOrDefault(u => u.Email == email);
        }

        public Utilizator GetById(int id)
        {
            return _table.FindAsync(id).Result;
        }


        public bool EmailExists(string email)
        {
            return _context.Utilizatori.Any(u => u.Email == email);
        }

        public List<Imprumut> GetImprumuturiByUser(int userId)
        {
            var user = GetById(userId);
            return _context.Imprumuturi.Where(i => i.Utilizator == user).ToList();
        }
        
        public async Task<Utilizator> UpdatePassword(Utilizator utilizator)
        {
            _context.Entry(utilizator).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return utilizator;
        }


        public async Task<bool> Update()
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
    }
}