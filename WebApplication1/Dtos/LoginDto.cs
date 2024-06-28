using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }  
    }
}
