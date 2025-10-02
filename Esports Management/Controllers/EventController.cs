using Esports_Management.Data;
using Esports_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esports_Management.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext _context;
        private IWebHostEnvironment Environment;

        public EventController(ApplicationDbContext context, IWebHostEnvironment _environment)
        {
            _context = context;
            Environment = _environment;
        }
        public IActionResult Index()
        {

            if (User.IsInRole("Admin"))
            {
                var list = _context.Event.Include(Event => Event.Sport).ToList();
                return View(list);
            }
            else
            {
                var list = _context.Event.Where(x => x.CreatedBy == User.Identity.Name).Include(Event => Event.Sport).ToList();
                if (list != null)
                {
                    return View(list);
                }
                else
                {
                    return RedirectToAction("Create");
                }

            }


        }

        public IActionResult Create(int id)
        {


            ViewBag.Sport = _context.Sports.ToList();
            var row = _context.Event.Where(a => a.EId == id).FirstOrDefault();
            return View(row);


        }

        [HttpPost]
        public IActionResult Create(EventModel obj)
        {
            if (obj.CoverPhoto != null)
            {
                string folder = "NewFolder";
                folder += obj.CoverPhoto.FileName;
                string serverfolder = Path.Combine(Environment.WebRootPath, folder);
                obj.image_path = folder;
                obj.CoverPhoto.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
            }

            if (ModelState.IsValid)
            {
                _context.Event.Add(obj);
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
            var row = _context.Event.Where(a => a.EId == id).FirstOrDefault();
            ViewBag.Sport = _context.Sports.ToList();
            return View(row);
        }

        [HttpPost]
        public IActionResult Edit(EventModel obj)
        {
            if (ModelState.IsValid)
            {
                _context.Event.Update(obj);
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
            var row = _context.Event.Include(b => b.Sport).Where(a => a.EId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]

        public IActionResult Delete(EventModel obj)
        {
            if (ModelState.IsValid)
            {
                _context.Event.Remove(obj);

                int a = _context.SaveChanges();

                if (a > 0)
                {
                    TempData["msg"] = "Row Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var list = _context.Event.Include(a => a.Sport).Where(b => b.EId == id).FirstOrDefault();
            return View(list);
        }
    }
}
