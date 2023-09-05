using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Enums;

namespace WebApplication1.Models
{
    public class Utilizator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nume { get; set; }
        
        public ICollection<Imprumut>? Imprumuturi { get; }

        [StringLength(300)]
        public string Adresa { get; set; }

        [StringLength(20)]
        public string NumarTelefon { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(100)]
        [MinLength(8)]
        public string Parola { get; set; }
        
        public Role Role { get; set; }
    }
}