using System.ComponentModel.DataAnnotations;

namespace SwitchSelect.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Cpf inválido")]
        public string Cpf { get; set; }


    }
}
