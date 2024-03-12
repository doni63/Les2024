using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwitchSelect.Models.Endereco
{
    [Table("TipoEndereco")]
    public class TipoEndereco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Descricao {  get; set; }
    }
}
