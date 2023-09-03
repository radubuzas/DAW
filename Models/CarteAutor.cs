namespace WebApplication1.Models
{

    public class CarteAutor
    {
        public int CarteId { get; set; }
        public Carte Carte { get; set; }
        
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}