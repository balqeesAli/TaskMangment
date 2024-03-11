using Microsoft.AspNetCore.Mvc;

namespace TaskMangmentAPI.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
