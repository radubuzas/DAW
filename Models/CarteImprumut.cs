namespace WebApplication1.Models
{

    public class CarteImprumut
    {
        public int CarteId { get; set; }
        public Carte Carte { get; set; } = null!;
        
        public int ImprumutId { get; set; }
        public Imprumut Imprumut { get; set; } = null!;
    }
}