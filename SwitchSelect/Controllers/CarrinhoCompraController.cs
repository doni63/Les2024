using Microsoft.AspNetCore.Mvc;

namespace SwitchSelect.Controllers
{
    public class CarrinhoCompraController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
