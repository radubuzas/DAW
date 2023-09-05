using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO;

public class UserResponseDTO
{
    public int Id { get; set; }
    
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    public string Token { get; set; }

    public UserResponseDTO(Utilizator utilizator, string token)
    {
        Id = utilizator.Id;
        Email = utilizator.Email;
        Name = utilizator.Nume;
        Token = token;
    }
}