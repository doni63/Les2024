using Microsoft.EntityFrameworkCore;
using SwitchSelect.Data;
using SwitchSelect.Models;
using SwitchSelect.Models.ViewModels;
using SwitchSelect.Repositorios.Interfaces;

namespace SwitchSelect.Service;

public class ConvertService
{
    private readonly SwitchSelectContext _context;

    private readonly IClienteRepositorio _cliRepositorio;

    public ConvertService(IClienteRepositorio cliRepositorio)
    {
        _cliRepositorio = cliRepositorio;
    }

    public ClienteCompletoViewModel ConverterParaClienteViewModel(Cliente cliente)
    {
        if (cliente is null) return null;

        var clienteViewModel = new ClienteCompletoViewModel
        {
            //dados cliente
            Id = cliente.Id,
            Nome = cliente.Nome,
            DataDeNascimento = cliente.DataDeNascimento,
            Email = cliente.Email,
            Genero = cliente.Genero,
            Cpf = cliente.Cpf,
            RG = cliente.RG,
            NumeroTelefone = cliente.Telefones.FirstOrDefault()?.NumeroTelefone,
            TipoTelefone = (TipoTelefone)cliente.Telefones.FirstOrDefault()?.TipoTelefone,
            DDD = cliente.Telefones.FirstOrDefault()?.DDD,
            Estado = cliente.Enderecos.FirstOrDefault()?.Bairro.Cidade.Estado.Descricao,
            Cidade = cliente.Enderecos.FirstOrDefault()?.Bairro.Cidade.Descricao,
            Bairro = cliente.Enderecos.FirstOrDefault()?.Bairro.Descricao,
            Logradouro = cliente.Enderecos.FirstOrDefault()?.Logradouro,
            Numero = cliente.Enderecos.FirstOrDefault()?.Numero,
            CEP = cliente.Enderecos.FirstOrDefault()?.CEP,
            TipoEndereco = (TipoEndereco)cliente.Enderecos.FirstOrDefault()?.TipoEndereco,
            TipoLogradouro = (TipoLogradouro)cliente.Enderecos.FirstOrDefault()?.TipoLogradouro,
            TipoResidencia = (TipoResidencia)cliente.Enderecos.FirstOrDefault()?.TipoResidencia,
            Complemento = cliente.Enderecos.FirstOrDefault()?.Complemento,
            TipoCartao = (TipoCartao)cliente.Cartoes.FirstOrDefault()?.TipoCartao,
            NumeroCartao = cliente.Cartoes.FirstOrDefault()?.NumeroCartao,
            TitularDoCartao = cliente.Cartoes.FirstOrDefault()?.TitularDoCartao,
            CpfTitularCartao = cliente.Cartoes.FirstOrDefault()?.CpfTitularCartao,
            DataValidade = (DateTime)(cliente.Cartoes.FirstOrDefault()?.DataValidade),
            CVV = cliente.Cartoes.FirstOrDefault()?.CVV,
        };
        return clienteViewModel;
    }

   public ClienteDadosPessoaisViewModel ConverterParaClienteDadosPessoaisViewModel(Cliente cliente)
    {
        if(cliente is null)
        {
            return null;
        }
        var clienteViewModel = new ClienteDadosPessoaisViewModel
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            DataDeNascimento = cliente.DataDeNascimento,
            Email = cliente.Email,
            Genero = cliente.Genero,
            Cpf = cliente.Cpf,
            RG = cliente.RG,
            NumeroTelefone = cliente.Telefones.FirstOrDefault()?.NumeroTelefone,
            TipoTelefone = (TipoTelefone)cliente.Telefones.FirstOrDefault()?.TipoTelefone,
            DDD = cliente.Telefones.FirstOrDefault()?.DDD
        };
        return clienteViewModel;
    }
}

