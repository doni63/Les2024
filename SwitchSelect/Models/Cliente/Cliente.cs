﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SwitchSelect.Models;

[Table("Clientes")]
public class Cliente
{
    [Key]
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

    public List<Endereco> Enderecos { get; set; } = new List<Endereco>();
    public List<Telefone> Telefones { get; set; } = new List<Telefone>();

}
