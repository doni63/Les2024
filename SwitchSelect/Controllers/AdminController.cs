using Microsoft.AspNetCore.Mvc;
using SwitchSelect.Service;

namespace SwitchSelect.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService _Adminservice;
        
        public IActionResult TelaAdmin()
        {
            return View();
        }

        public AdminController(AdminService Adminservice)
        {
            _Adminservice = Adminservice;
            
        }

        public IActionResult AdminListaCliente()
        {
            var list = _Adminservice.AdminListarClientes();
            return View(list);
        }


        public async Task<IActionResult> AdminInformacaoCliente(int? id)
        {
            if (id == null) { return NotFound(); }

            var cliente = await _Adminservice.AdminGetCliente(id.Value);
            if (cliente == null) { return NotFound(); };
            return View(cliente);
        }
    }
}
