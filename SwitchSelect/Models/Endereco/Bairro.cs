using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwitchSelect.Models.Endereco
{
    [Table("Bairros")]
    public class Bairro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="Limite 100 Caracteres")]
        public string Descricao { get; set; }
        public List<LogradouroModel> Logradouros { get; set; } = new List<LogradouroModel>();

        // Relacionamento com Cidade
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }
    }
}
