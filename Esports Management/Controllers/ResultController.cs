using Esports_Management.Data;
using Esports_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esports_Management.Controllers
{
    public class ResultController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ResultController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var x = _context.Result.Include(a => a.Events).ToList();

            return View(x);
        }

        public IActionResult Create()
        {
            ViewBag.Events = _context.Event.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ResultModel obj)
        {
            if (ModelState.IsValid)
            {
                _context.Result.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
