using Microsoft.AspNetCore.Mvc;

namespace SwitchSelect.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult TelaAdmin()
        {
            return View();
        }
    }
}
