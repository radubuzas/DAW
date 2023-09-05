using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{

    public class UserRequestDTO
    {
        [Required] public string Email { get; set; }

        [Required] public string Parola { get; set; }

        public string Name { get; set; }
    }
}