using Microsoft.AspNetCore.Mvc;
using SwitchSelect.Models;
using SwitchSelect.Models.ViewModels;
using SwitchSelect.Repositorios.Interfaces;
using SwitchSelect.Service;

namespace SwitchSelect.Controllers
{
    public class CartaoController : Controller
    {
        private readonly ICartaoRepositorio _cartaoRepositorio;
        private readonly CartaoService _cartaoService;

        public CartaoController(CartaoService service, ICartaoRepositorio cartaoRepositorio)
        {
            _cartaoService = service;
            _cartaoRepositorio = cartaoRepositorio;
        }

        public IActionResult CartaoList(int clienteId)
        {
            var cartoes = _cartaoRepositorio.ObterCartaoPorCliente(clienteId);

            //convertendo model para viewmodel
            var cartoesViewModel = cartoes.Select(c => new CartaoViewModel
            {
                Id = c.Id,
                ClienteId = c.ClienteId,
                NumeroCartao = c.NumeroCartao,
                TitularDoCartao = c.TitularDoCartao,
                CpfTitularCartao = c.CpfTitularCartao,
                MesValidade = c.MesValidade,
                AnoValidade = c.AnoValidade,
                DataValidade = c.DataValidade,
                CVV = c.CVV,
                TipoCartao = c.TipoCartao,
            }).ToList();
            if(cartoesViewModel is null)
            {
                return NotFound();
            }
            foreach(var cartao in cartoesViewModel)
            {
                var numeroCartao = cartao.NumeroCartao;
                cartao.CartaoQuatroDigito = _cartaoService.FormatarUltimosQuatroDigitos(numeroCartao);
            }
            ViewData["ClienteID"] = clienteId;
            return View(cartoesViewModel);
        }

      
    }
}
