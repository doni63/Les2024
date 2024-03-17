using Microsoft.AspNetCore.Mvc;
using SwitchSelect.Service;

namespace SwitchSelect.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService _service;
        public IActionResult TelaAdmin()
        {
            return View();
        }

        public AdminController(AdminService service)
        {
            _service = service;
        }

        public IActionResult AdminListaCliente()
        {
            var list = _service.AdminListarClientes();
            return View(list);
        }


        public async Task<IActionResult> AdminInformacaoCliente(int? id)
        {
            if (id == null) { return NotFound(); }

            var cliente = _service.AdminGetCliente(id.Value);
            if (cliente == null) { return NotFound(); };
            return View(cliente);
        }
    }
}
