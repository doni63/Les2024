using System.ComponentModel.DataAnnotations;

namespace SwitchSelect.Models.Endereco
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public TipoEndereco Tipo { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int BairroId { get; set; }
        public Bairro Bairro { get; set; }
    }

  
}
