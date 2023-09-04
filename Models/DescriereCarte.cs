using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class DescriereCarte
{
    [Key]
    public int CarteId { get; set; } // Aceasta este și cheia primară și cheia străină
    
    [MinLength(50)]
    [MaxLength(500)]
    [Required]
    public string Rezumat { get; set; }
    
    [MinLength(500)]
    [MaxLength(5000)]
    public string DescriereLunga { get; set; }

    public Carte Carte { get; set; } = null!;
}