using Microsoft.AspNetCore.Mvc;
using SwitchSelect.Models;
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

        public IActionResult JogoList(string categoria) 
        {
            IEnumerable<Jogo> jogos;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(categoria))
            {
                jogos = _jogoRepositorio.Jogos.OrderBy(j =>  j.Id);
                categoriaAtual = "Todos os Jogos";
            }
            else
            {
                if(string.Equals("Aventura", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    jogos = _jogoRepositorio.Jogos
                        .Where(j => j.Categoria.Nome.Equals("Aventura"))
                        .OrderBy(j => j.Nome);
                }
                else
                {
                    jogos = _jogoRepositorio.Jogos
                             .Where(j => j.Categoria.Nome.Equals("Luta"))
                             .OrderBy(j => j.Nome);
                }
                categoriaAtual = categoria;
            }
            var jogoListViewModel = new JogoListViewModel
            {
                Jogos = jogos,
                CategoriaAtual = categoriaAtual
            };
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
