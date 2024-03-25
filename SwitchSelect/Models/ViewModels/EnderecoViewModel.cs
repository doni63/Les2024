using System.ComponentModel.DataAnnotations;

namespace SwitchSelect.Models.ViewModels;

public class EnderecoViewModel
{
    [Display(Name ="Id")]
    public int Id { get; set; }
    public int ClienteID { get; set; }
    
    [Display(Name = "Tipo de endereço")]
    public TipoEndereco TipoEndereco { get; set; }

    [Display(Name = "Tipo de residência")]
    public TipoResidencia TipoResidencia { get; set; }

    [Display(Name ="Tipo de logradoutro")]
    public TipoLogradouro TipoLogradouro { get; set; }

   
    public string Logradouro { get; set; }

    [Display(Name ="Número")]
    public string Numero { get; set; }

    public string CEP { get; set; }

    public string? Complemento { get; set; }

   
    public string Bairro { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }


}
