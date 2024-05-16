using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Key]
        public int  IdUsuario { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        public int Telefone { get; set; }
        public ICollection<Objeto> Objetos { get; set; }
        public ICollection<Documento> Documentos { get; set; }   
   }
}
