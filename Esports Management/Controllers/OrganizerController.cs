using Esports_Management.Data;
using Esports_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Esports_Management.Controllers
{
    public class OrganizerController : Controller
    {

        private ApplicationDbContext _context;

        public OrganizerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Organizer.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrganizerModel obj)
        {

            _context.Organizer.Add(obj);
            int a = _context.SaveChanges();
            if (a > 0)
            {
                TempData["msg"] = "New Record Inserted Successfully";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var list = _context.Organizer.Where(a => a.CId == id).FirstOrDefault();
            return View(list);
        }

        [HttpPost]

        public IActionResult Edit(OrganizerModel obj)
        {
            _context.Organizer.Update(obj);
            int a = _context.SaveChanges();
            if (a > 0)
            {
                TempData["msg"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var row = _context.Organizer.Where(a => a.CId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]

        public IActionResult Delete(OrganizerModel obj)
        {

            _context.Organizer.Remove(obj);
            int a = _context.SaveChanges();

            if (a > 0)
            {
                TempData["msg"] = "Record Deleted Successfully";
            }
            return RedirectToAction("Index");
        }

    }
}
