using Microsoft.AspNetCore.Mvc;
using SwitchSelect.Models;
using SwitchSelect.Models.ViewModels;
using SwitchSelect.Repositorios.Interfaces;
using SwitchSelect.Service;

namespace SwitchSelect.Controllers;

public class EnderecoController : Controller
{
    private readonly IEnderecoRepositorio _enderecoRepositorio;
    private readonly EnderecoService _enderecoService;

    public EnderecoController(IEnderecoRepositorio enderecoRepositorio, EnderecoService enderecoService)
    {
        _enderecoRepositorio = enderecoRepositorio;
        _enderecoService = enderecoService;
    }


    public IActionResult EnderecoList(int clienteId)
    {
        var enderecos = _enderecoRepositorio.ObterEnderecosPorCliente(clienteId);

        // Convertendo de Model para ViewModel
        var enderecosViewModel = enderecos.Select(e => new EnderecoViewModel
        {
            Id = e.Id,
            ClienteID = clienteId,
            Logradouro = e.Logradouro,
            Numero = e.Numero,
            Complemento = e.Complemento,
            Bairro = e.Bairro.Descricao,
            Cidade = e.Bairro.Cidade.Descricao,
            Estado = e.Bairro.Cidade.Estado.Descricao,
            CEP = e.CEP
           
        }).ToList();
        ViewData["ClienteID"] = clienteId;
        return View(enderecosViewModel);
    }

    public IActionResult Create(int clienteId)
    {
        var viewModel = new EnderecoViewModel
        { ClienteID = clienteId };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EnderecoViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _enderecoService.CriarEnderecoAsync(model);

        // Redireciona para a lista de endereços do cliente, passando o clienteId
        return RedirectToAction(nameof(EnderecoList), new { clienteId = model.ClienteID });
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        var endereco =  _enderecoRepositorio.Enderecos
            .FirstOrDefault(e => e.Id == id);
        if (endereco == null) { return NotFound(); }

        var viewModel = new EnderecoViewModel
        {
            Id = endereco.Id,
            Logradouro = endereco.Logradouro,
            Numero = endereco.Numero
        };
        return View(viewModel);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmedAsync(int id)
    {
       await _enderecoService.DeleteEndereco(id);
        return RedirectToAction("AreaCliente","Cliente");
    }

}
