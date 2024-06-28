using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Key]
        public int  IdUsuario { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        public int Telefone { get; set; }
        [Required]
        public string Senha { get; set; }
       
        
   }
}
