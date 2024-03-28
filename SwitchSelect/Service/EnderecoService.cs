using SwitchSelect.Data;
using SwitchSelect.Models;
using SwitchSelect.Models.ViewModels;
using SwitchSelect.Repositorios.Interfaces;

namespace SwitchSelect.Service;

public class EnderecoService
{
    private readonly SwitchSelectContext _context;
    private readonly IEnderecoRepositorio _endRepositorio;

    public EnderecoService(SwitchSelectContext context, IEnderecoRepositorio endRepositorio)
    {
        _context = context;
        _endRepositorio = endRepositorio;
    }

    public async Task CriarEnderecoAsync(EnderecoViewModel model)
    {
        var estado = new Estado
        {
            Descricao = model.Estado,
        };

        var cidade = new Cidade
        {
            Descricao = model.Cidade,
            Estado = estado
        };

        var bairro = new Bairro
        {
            Descricao = model.Bairro,
            Cidade = cidade
        };

        var endereco = new Endereco
        {
            ClienteId = model.ClienteID,
            TipoEndereco = model.TipoEndereco,
            TipoResidencia = model.TipoResidencia,
            TipoLogradouro = model.TipoLogradouro,
            Logradouro = model.Logradouro,
            Numero = model.Numero,
            CEP = model.CEP,
            Complemento = model.Complemento,
            Bairro = bairro
            
        };
        
        _context.Enderecos.Add(endereco);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteEndereco(int enderecoId)
    {
        var endereco = _endRepositorio.GetEnderecoPorId(enderecoId);
        if(endereco is null)
        {
            throw new Exception("Endereco não encontrado"); ;
        }

        _context.Enderecos.Remove(endereco);
        await _context.SaveChangesAsync();
    }
}
