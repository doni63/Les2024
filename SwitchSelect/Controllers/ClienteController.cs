using Microsoft.AspNetCore.Mvc;
using SwitchSelect.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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

        public IActionResult ListaCliente()
        {
            var list = _clienteService.ListarClientes();
            return View(list);
        }

        public IActionResult PerfilUsuario()
        {
            return View();
        }
        public IActionResult Create()
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = await _clienteService.ObterClientePorIdAsync(id.Value);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sucesso = await _clienteService.EditarClienteAsync(id, clienteViewModel);
                if (sucesso)
                {
                    return RedirectToAction("ListaCliente","Cliente"); 
                }
                else
                {
                    return NotFound();
                }
            }
            return View(clienteViewModel);
        }

    }
}
