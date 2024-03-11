using Microsoft.AspNetCore.Mvc;

namespace TaskMangmentAPI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
