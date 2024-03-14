using Microsoft.AspNetCore.Mvc;

namespace SwitchSelect.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult TelaLogin()
        {
            return View();
        }
    }
}
