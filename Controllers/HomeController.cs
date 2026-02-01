using Microsoft.AspNetCore.Mvc;

namespace CodVeda_FullStack_Intern.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
