using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwitchSelect.Models.Endereco
{
    [Table("Estados")]
    public class Estado
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Limite 100 Caracteres")]
        public string Descricao { get; set; }
        public List<Cidade> Cidades { get; set; } = new List<Cidade>();
    }
}
