using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class UsuarioDto
   {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        
        public string Senha { get; set; }

    }
}
