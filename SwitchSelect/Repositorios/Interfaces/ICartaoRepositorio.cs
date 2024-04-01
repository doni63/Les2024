using SwitchSelect.Models;

namespace SwitchSelect.Repositorios.Interfaces;

public interface ICartaoRepositorio
{
    IEnumerable<Cartao> Cartoes { get; }
    IEnumerable<Cartao> ObterCartaoPorCliente(int clienteId);
    Cartao GetCartaoPorId(int id);  
}
