using Microsoft.AspNetCore.Mvc;
using SwitchSelect.Data;
using SwitchSelect.Models.Endereco;
using SwitchSelect.Models;
using SwitchSelect.Models.ViewModels;


namespace SwitchSelect.Controllers
{
    public class ClienteController : Controller
    {
        private readonly SwitchSelectContext _context;

        public ClienteController(SwitchSelectContext context)
        {
            _context = context;
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
                var cliente = new Cliente
                {
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    RG = model.RG,
                    
                };
                //criar e adicionar Cidade
                var cidade = new Cidade()
                {
                    Descricao = model.Cidade
                };
                //Criar e adicionar Bairro
                var bairro = new Bairro(){
                    Descricao = model.Bairro,
                    Cidade = cidade
                };

                // Criar e adicionar o endereço
                var endereco = new Endereco()
                {
                    Logradouro = model.Logradouro,
                    Numero = model.Numero,
                    CEP = model.CEP,
                    Complemento = model.Complemento,
                    Cliente = cliente,
                    Bairro = bairro
                };

                cliente.Enderecos.Add(endereco);

                _context.Add(cliente);
                await _context.SaveChangesAsync();
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
