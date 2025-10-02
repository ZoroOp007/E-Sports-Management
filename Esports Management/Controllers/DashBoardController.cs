using Microsoft.AspNetCore.Mvc;

namespace Esports_Management.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
