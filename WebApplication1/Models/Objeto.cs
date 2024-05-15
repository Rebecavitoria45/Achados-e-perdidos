using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Enuns;

namespace WebApplication1.Models
{
    public class Objeto
    {
        [Key]
        public int IdObjeto { get; set; }

        [Required (ErrorMessage ="O Nome do Objeto é obrigatório")]
        public string Nome { get; set; }
        public string FotoObjeto { get; set; }
        public bool Ativo { get; set; } = true;

        [Required(ErrorMessage ="A descrição do objeto é obrigatória")]
        [StringLength(255)]
        public string Descrição { get; set; }

        [Required]
        public CategoriaEnum Categoria {  get; set; }
         [ForeignKey("Usuario")]
         public int UsuarioId { get; set; }
         public virtual Usuario Usuario { get; set; }
    }
}
