using WebApplication1.Models;

namespace WebApplication1.Helpers.JwtUtils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Utilizator user);
        public int ValidateJwtToken(string token);
    }
}
