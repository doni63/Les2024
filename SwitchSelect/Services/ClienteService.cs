using SwitchSelect.Data;
using SwitchSelect.Models;

namespace SwitchSelect.Services;

public class ClienteService
{
    private readonly SwitchSelectContext _context;

    public ClienteService(SwitchSelectContext context)
    {
        _context = context;
    }

    //método para inserir no banco
    public void Insert(Cliente cliente)
    {
        _context.Add(cliente);
        _context.SaveChanges();
    }
}
