
using SwitchSelect.Models.Endereco;
using System.ComponentModel.DataAnnotations;


namespace SwitchSelect.Models.ViewModels
{
    public class ClienteViewModel
    {
        // Informações do Cliente
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(100, ErrorMessage = "Número máximo de caracter 100")]
        public string Nome { get; set; }

        [Required]
        [StringLength(10)]
        public string Genero { get; set; }


        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Cpf")]
        [StringLength(11, ErrorMessage = "Número máximo de caracter 11")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe o RG")]
        [StringLength(9, ErrorMessage = "Número máximo de caracter 9")]
        public string RG { get; set; }

        // Informações de Endereço
        [Required]
        [Display(Name ="Tipo de endereço")]
        public TipoEndereco TipoEndereco { get; set; }

        [Required]
        [Display(Name ="Tipo de residência")]
        public TipoResidencia TipoResidencia { get; set; }

        [Required]
        public TipoLogradouro TipoLogradouro { get; set; }

        [Required(ErrorMessage = "Informe o logradouro")]
        [StringLength(100, ErrorMessage = "Limite de 100 caracteres para o logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o número")]
        [StringLength(10, ErrorMessage = "Limite de 10 caracteres para o número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [StringLength(8, ErrorMessage = "Limite de 8 caracteres para o CEP")]
        public string CEP { get; set; }

        [StringLength(200, ErrorMessage = "Limite de 200 caracteres para o complemento")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Informe o bairro")]
        [StringLength(100)]
        public string Bairro { get; set; }

       [Required(ErrorMessage = "Informe a cidade")]
       [StringLength(100)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o Estado")]
        [StringLength(100)]
        public string Estado { get; set; }

        //[Required(ErrorMessage = "Informe o estado")]
        //[StringLength(100)]
        //public string Estado { get; set; }


        // public List<EnderecoViewModel> Enderecos { get; set; } = new List<EnderecoViewModel>();

        // Classe interna para Endereco, se necessário
        // public class EnderecoViewModel
        // {
        //     // Propriedades do Endereço
        // }
    }
}
