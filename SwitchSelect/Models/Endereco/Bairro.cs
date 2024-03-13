using System.ComponentModel.DataAnnotations;

namespace SwitchSelect.Models.Endereco
{
    public class Bairro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Bairro")]
        public string Nome { get; set; }
        public List<Endereco> Enderecos { get; set; } = new List<Endereco>();

    }
}
