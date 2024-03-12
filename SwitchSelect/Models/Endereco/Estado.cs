using System.ComponentModel.DataAnnotations;

namespace SwitchSelect.Models.Endereco
{
    public class Estado
    {
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        public List<Cidade> Cidades { get; set; } = new List<Cidade>();
    }
}
