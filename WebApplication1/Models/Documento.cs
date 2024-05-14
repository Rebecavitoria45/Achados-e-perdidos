using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Enuns;

namespace WebApplication1.Models
{
    public class Documento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TipoDocumento { get; set; }
        [Required]
        public string NumeroDocumento { get; set; }
        [Required]
        public string NomeCompletoDocumento { get; set; }
        [Required]
        public EstadoEnum EstadoDocumento { get; set; }
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set;}


    }
}
