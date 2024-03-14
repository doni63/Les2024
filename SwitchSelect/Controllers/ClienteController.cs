using Microsoft.AspNetCore.Mvc;
using SwitchSelect.Data;

using SwitchSelect.Models.ViewModels;
using SwitchSelect.Service;


namespace SwitchSelect.Controllers
{
    public class ClienteController : Controller
    {
        private readonly SwitchSelectContext _context;
        private readonly ClienteService _clienteService;

        public ClienteController(SwitchSelectContext context, ClienteService service)
        {
            _context = context;
            _clienteService = service;
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult PerfilUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {                      
                await _clienteService.CriarClienteAsync(model);
                return RedirectToAction("Index","home");
            }
            return View(model);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
