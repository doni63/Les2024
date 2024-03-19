using SwitchSelect.Data;

namespace SwitchSelect.Models.Carrinho;

public class CarrinhoCompra
{
    private readonly SwitchSelectContext _context;

    public CarrinhoCompra(SwitchSelectContext context)
    {
        _context = context;
    }

    public string CarrinhoCompraId { get; set; }
    public List<CarrinhoCompraItem> CarrinhosCompraItens { get; set; }
}
