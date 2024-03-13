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
        [StringLength(100)]
        [Display(Name ="Cidade")]
        public string Descricao { get; set; }
        public List<Bairro> Bairros { get; set; }

    }
}
