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

        public List<Cliente> AdminListarClientes()
        {
            return _context.Clientes.ToList();
        }
    }
}
