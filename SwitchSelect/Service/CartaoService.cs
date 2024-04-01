using MySqlX.XDevAPI;
using SwitchSelect.Data;
using SwitchSelect.Models;
using SwitchSelect.Models.ViewModels;
using SwitchSelect.Repositorios.Interfaces;

namespace SwitchSelect.Service;

public class CartaoService
{
    private readonly SwitchSelectContext _context;
    private readonly ICartaoRepositorio _cartaoRepositorio;

    public CartaoService(SwitchSelectContext context, ICartaoRepositorio cartaoRepositorio)
    {
        _context = context;
        _cartaoRepositorio = cartaoRepositorio;
    }

    
    public string FormatarUltimosQuatroDigitos(string numeroCartao)
    {
        if (numeroCartao.Length > 4)
        {
            string ultimosQuatro = numeroCartao.Substring(numeroCartao.Length - 4);
            return "**** **** **** " + ultimosQuatro;
        }
        return numeroCartao; // Retorna o número original se tiver menos de 4 dígitos (caso raro/não esperado)
    }

     
}
