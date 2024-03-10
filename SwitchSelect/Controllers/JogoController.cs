using Microsoft.AspNetCore.Mvc;

namespace SwitchSelect.Controllers
{
    public class JogoController : Controller
    {
        public IActionResult JogoSelecionado()
        {
            return View();
        }
       
    }
}
