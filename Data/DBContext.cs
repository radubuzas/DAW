using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DBCTX : DbContext
    {
        public DbSet<Carte> Carti { get; set; }
        public DbSet<Utilizator> Utilizatori { get; set; }
        public DbSet<Imprumut> Imprumuturi { get; set; }
        public DbSet<Autor> Autori { get; set; } 

        public DBCTX(DbContextOptions<DBCTX> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1:1
            modelBuilder.Entity<Carte>()
                .HasOne<DescriereCarte>(c => c.DescriereCarte)
                .WithOne(dc => dc.Carte)
                .HasForeignKey<DescriereCarte>(dc => dc.CarteId);
            
            // 1:M
            modelBuilder.Entity<Utilizator>()
                .HasMany(a => a.Imprumuturi)
                .WithOne(b => b.Utilizator)
                .HasForeignKey(b => b.UtilizatorId);
             
            // M:M
            // Carte - Autor
            modelBuilder.Entity<CarteAutor>()
                .HasKey(ca => new { ca.CarteId, ca.AutorId });
            
            modelBuilder.Entity<CarteAutor>()
                .HasOne<Carte>(ca => ca.Carte)
                .WithMany(c => c.CarteAutori)
                .HasForeignKey(ca => ca.CarteId);
            
            modelBuilder.Entity<CarteAutor>()
                .HasOne<Autor>(ca => ca.Autor)
                .WithMany(a => a.CarteAutori)
                .HasForeignKey(ca => ca.AutorId);
            
            // Carte - Imprumut
            modelBuilder.Entity<CarteImprumut>()
                .HasKey(ci => new { ci.CarteId, ci.ImprumutId });
            
            modelBuilder.Entity<CarteImprumut>()
                .HasOne<Carte>(ci => ci.Carte)
                .WithMany(c => c.CarteImprumuts)
                .HasForeignKey(ci => ci.CarteId);
            
            modelBuilder.Entity<CarteImprumut>()
                .HasOne<Imprumut>(ci => ci.Imprumut)
                .WithMany(i => i.CarteImprumuts)
                .HasForeignKey(ci => ci.ImprumutId);
        }
        
    }
}