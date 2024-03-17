using Microsoft.AspNetCore.Mvc;
using SwitchSelect.Service;

namespace SwitchSelect.Controllers
{
    public class AdminController : Controller
    {
        private readonly ClienteService _Service;
        public IActionResult TelaAdmin()
        {
            return View();
        }

        public AdminController(ClienteService service)
        {
            _Service = service;
        }

        public IActionResult AdminListaCliente()
        {
            var list = _Service.ListarClientes();
            return View(list);
        }

        //public AdminController(AdminService adminService)
        //{
        //    _adminService = adminService;
        //}

        //public async Task<IActionResult> AdminInformacaoCliente(int? id)
        //{
        //    if(id == null) { return NotFound(); }

        //    var cliente = _adminService.AdminGetCliente(id.Value);
        //    if(cliente == null) { return NotFound(); };
        //    return View(cliente);
        //}
    }
}
