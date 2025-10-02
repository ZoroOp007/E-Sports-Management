using Esports_Management.Data;
using Esports_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Esports_Management.Controllers
{
    public class SportController : Controller
    {

        private ApplicationDbContext _context;

        public SportController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Sports.ToList();
            return View(list);
        }

        public IActionResult Create(int id)
        {
            var row = _context.Sports.Where(a => a.SId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public IActionResult Create(SportModel obj)
        {
            if (ModelState.IsValid)
            {
                _context.Sports.Add(obj);
                int a = _context.SaveChanges();
                if (a > 0)
                {
                    TempData["msg"] = "New Record Inserted Successfully";
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var row = _context.Sports.Where(a => a.SId == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public IActionResult Edit(SportModel obj)
        {
            if (ModelState.IsValid)
            {
                _context.Sports.Update(obj);
                int a = _context.SaveChanges();

                if (a > 0)
                {
                    TempData["msg"] = "Row Updated Successfully";
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var row = _context.Sports.Where(a => a.SId == id).FirstOrDefault();

            return View(row);
        }

        [HttpPost]
        public IActionResult Delete(SportModel obj)
        {
            if (ModelState.IsValid)
            {
                _context.Sports.Remove(obj);
                int a = _context.SaveChanges();

                if (a > 0)
                {
                    TempData["msg"] = "Row Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
