using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Enuns;

namespace WebApplication1.Dtos
{
    public class DocumentoDto
    {
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NomeCompletoDocumento { get; set; }
        public EstadoEnum EstadoDocumento { get; set; }
       public int UsuarioId { get; set; }
    }
}
