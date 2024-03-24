using Microsoft.AspNetCore.Mvc;
using SwitchSelect.Models.ViewModels;
using SwitchSelect.Repositorios.Interfaces;

namespace SwitchSelect.Controllers
{
    public class JogoController : Controller
    {
        private readonly IJogoRepositorio _jogoRepositorio;

        public JogoController(IJogoRepositorio jogoRepositorio)
        {
            _jogoRepositorio = jogoRepositorio;
        }

       public IActionResult JogoList()
        {
            var jogoListViewModel = new JogoListViewModel();
            jogoListViewModel.Jogos = _jogoRepositorio.Jogos;
          
            return View(jogoListViewModel);
        }

        public IActionResult JogosPreferidos()
        {
            var jogosPreferidos = new JogoPreferidoViewModel();
            jogosPreferidos.JogosPreferidos = _jogoRepositorio.JogosPreferidos;

            return View(jogosPreferidos);
        }
       
        public IActionResult JogoSelecionado()
        {
            return View();
        }
    }
}
