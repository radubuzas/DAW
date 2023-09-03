

using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Carte
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titlu { get; set; }
        
        public ICollection<CarteAutor>? CarteAutori { get; set; }
        
        public DescriereCarte? DescriereCarte { get; set; }

        [StringLength(50)]
        public string? Gen { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public int ExemplareDisponibile { get; set; }

        [Required]
        public int ExemplareTotale { get; set; }
    }
}