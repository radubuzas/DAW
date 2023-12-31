using System;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Imprumut
    {
        public int Id { get; set; }
        public int UtilizatorId { get; set; }
        public Utilizator Utilizator { get; set; } = null!;
        public List<CarteImprumut> CarteImprumuts { get; } = new();
        public DateTime DataImprumut { get; set; }
        public DateTime? DataReturnare { get; set; }
    }
}