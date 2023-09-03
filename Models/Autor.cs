using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Autor
{
    [Key]
    [Required]
    public int AutorId { get; set; }
    
    [MaxLength(50)]
    public string Nume { get; set; }
    
    [MaxLength(50)]
    public string Prenume { get; set; }
    
    public ICollection<CarteAutor> CarteAutori { get; set; }
    
}