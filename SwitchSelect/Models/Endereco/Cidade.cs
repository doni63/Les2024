using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwitchSelect.Models.Endereco
{
    [Table("Cidades")]
    public class Cidade
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Limite 100 Caracteres")]
        public string Descricao { get; set; }
        public List<Bairro> Bairros { get; set; } = new List<Bairro>();

        // Relacionamento com Estado
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
    }
}
