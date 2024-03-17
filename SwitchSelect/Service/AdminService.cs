using Microsoft.EntityFrameworkCore;
using SwitchSelect.Data;
using SwitchSelect.Models;

namespace SwitchSelect.Service
{
    public class AdminService
    {
        private readonly SwitchSelectContext _context;

        public AdminService(SwitchSelectContext context)
        {
            _context = context;
        }

        public async Task<Cliente> AdminGetCliente(int? id)
        {
            if (id == null) return null;

            var cliente = await _context.Clientes
                 .Include(c => c.Telefones)
                .Include(c => c.Enderecos)
                     .ThenInclude(e => e.Bairro)
                     .ThenInclude(b => b.Cidade)
                     .ThenInclude(c => c.Estado)
                .Include(c => c.Cartoes)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null) return null;

            return cliente;
        }

        public List<Cliente> AdminListarClientes()
        {
            return _context.Clientes.ToList();
        }

    }
}
