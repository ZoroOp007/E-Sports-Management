using Esports_Management.Data;
using Esports_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Esports_Management.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var  list = _context.Test.ToList();

            return View(list);
        }

        public IActionResult Create()
        {
            
            return View();
            
        }

        [HttpPost]
        public IActionResult Create(Test obj)
        {
            if(ModelState.IsValid)
            {
                _context.Test.Add(obj);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");   
        }
    }
}
