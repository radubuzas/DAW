using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Helpers.Seeders;

public class UtilizatorSeeder
{
    public readonly DBCTX _context;
    
    public UtilizatorSeeder(DBCTX context)
    {
        _context = context;
    }

    public void SeedInitialUtilizatori()
    {
        if(_context.Utilizatori.Any())
        {
            var newUtilizator = new Utilizator
            {
                Email = "admin@admin.com",
                Parola = "admin123",
            };
            
            _context.Utilizatori.Add(newUtilizator);
            
            _context.SaveChanges();
        }
    }
}