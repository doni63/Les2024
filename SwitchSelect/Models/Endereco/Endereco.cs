using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwitchSelect.Models;
[Table("Enderecos")]
public class Endereco
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Informe o logradouro")]
    [StringLength(50,ErrorMessage = "Numero máximo de de caracteres 50")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "Informe o número")]
    [StringLength(10, ErrorMessage = "Numero máximo de de caracteres 10")]
    public string Numero { get; set; }

    [Required(ErrorMessage = "Informe o CEP")]
    [StringLength(8,MinimumLength =8, ErrorMessage = "Cep deve conter 8 caracteres")]
    public string CEP { get; set; }

    [StringLength(200, ErrorMessage = "Numero máximo de de caracteres 200")]
    public string Complemento { get; set; }
    public int BairroID { get; set; }
    public virtual Bairro Bairro { get; set; }
    public int ClienteID { get; set; }
    public virtual Cliente Cliente { get; set; }
}
