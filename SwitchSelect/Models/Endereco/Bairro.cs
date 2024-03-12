using System.ComponentModel.DataAnnotations;

namespace SwitchSelect.Models.Endereco
{
    public class Bairro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        public List<Endereco> Enderecos { get; set; } = new List<Endereco>();

        // Relacionamento com Cidade
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }
    }
}
