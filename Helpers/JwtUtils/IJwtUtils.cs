using WebApplication1.Models;

namespace Lab4_13.Helpers.JwtUtils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Utilizator user);
        public Guid ValidateJwtToken(string token);
    }
}
