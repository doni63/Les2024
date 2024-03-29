﻿using SwitchSelect.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwitchSelect.Models
{
    [Table("Cartoes")]
    public class Cartao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe número do cartão")]
        [Display(Name = "Numero do cartão")]
        [StringLength(16)]
        public string NumeroCartao { get; set; }

        [NotMapped]
        [Display(Name ="Cartao de final")]
        public string? CartaoQuatroDigito { get; set; }

        [Required(ErrorMessage = "Informe nome do titular do cartão")]
        [Display(Name = "Nome do titular")]
        [StringLength(100)]
        public string TitularDoCartao { get; set; }

        [Required(ErrorMessage = "Informe cpf do titular")]
        [Display(Name = "Cpf do titular")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Cpf inválido")]
        public string CpfTitularCartao { get; set; }
        
        [Range(1, 12, ErrorMessage = "O mês de validade deve estar entre 1 e 12.")]
        [NotMapped]
        public int MesValidade { get; set; }

        [Required(ErrorMessage = "O ano de validade é obrigatório.")]
        [AnoValidade]
        [NotMapped]
        public int AnoValidade { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Validade")]
        public DateTime DataValidade { get; set; }

        [Required(ErrorMessage = "Informe o CVV")]
        [Display(Name = "CVV")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV inválido")]
        public string CVV {  get; set; }

        [Required]
        [Display(Name ="Tipo de cartão")]
        public TipoCartao TipoCartao { get; set; }

        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }  


    }
}
