using System.ComponentModel.DataAnnotations;

namespace SwitchSelect.Models.Endereco
{
    public class Cidade
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        public List<Bairro> Bairros { get; set; } = new List<Bairro>();

        // Relacionamento com Estado
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
    }
}
