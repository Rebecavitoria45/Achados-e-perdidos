using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Enuns;

namespace WebApplication1.Dtos
{
    public class ObjetoDto
    {
        public string Nome { get; set; }
        public string FotoObjeto { get; set; }
        public bool Ativo { get; set; } = true;
        public string Descricao { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public int UsuarioId { get; set; }
    }
}
