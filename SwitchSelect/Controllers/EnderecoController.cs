using Microsoft.AspNetCore.Mvc;
using SwitchSelect.Models.ViewModels;
using SwitchSelect.Repositorios.Interfaces;

namespace SwitchSelect.Controllers;

public class EnderecoController : Controller
{
    private readonly IEnderecoRepositorio _enderecoRepositorio;
    
    public EnderecoController(IEnderecoRepositorio enderecoRepositorio)
    {
        _enderecoRepositorio = enderecoRepositorio;
       
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult EnderecoList(int clienteId)
    {
        var enderecos = _enderecoRepositorio.ObterEnderecosPorCliente(clienteId);

        // Convertendo de Model para ViewModel
        var enderecosViewModel = enderecos.Select(e => new EnderecoViewModel
        {
            // Supondo que ambos, Endereco e EnderecoViewModel, têm as mesmas propriedades.
            // Faça a atribuição correspondente aqui.
            Id = e.Id,
            ClienteID = clienteId,
            Logradouro = e.Logradouro,
            Numero = e.Numero,
            Complemento = e.Complemento,
            Bairro = e.Bairro.Descricao,
            Cidade = e.Bairro.Cidade.Descricao,
            Estado = e.Bairro.Cidade.Estado.Descricao,
            CEP = e.CEP
            // Continue com as outras propriedades necessárias.
        }).ToList();
        ViewData["ClienteID"] = clienteId;
        return View(enderecosViewModel);
    }

}
