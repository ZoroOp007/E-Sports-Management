using Esports_Management.Data;
using Esports_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esports_Management.Controllers
{
    public class NewsController : Controller
    {

        private IWebHostEnvironment Environment;
        private ApplicationDbContext _context;

        public NewsController(IWebHostEnvironment _environment, ApplicationDbContext context)
        {
            Environment = _environment;
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.News.Include(a => a.Event).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            ViewBag.Events = _context.Event.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewsModel obj)
        {

            if (obj.NoticePdf != null)
            {
                string folder = "NewFolder";
                folder += obj.NoticePdf.FileName;
                string serverfolder = Path.Combine(Environment.WebRootPath, folder);
                obj.image_path = folder;
                obj.NoticePdf.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
            }

            _context.News.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Edit(int id)
        {
            var list = _context.News.Where(a => a.Notice_Id == id).FirstOrDefault();
            return View(list);
        }

        [HttpPost]

        public IActionResult Edit(NewsModel obj)
        {
            _context.News.Update(obj);
            int a = _context.SaveChanges();
            if (a > 0)
            {
                TempData["msg"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var row = _context.News.Where(a => a.Notice_Id == id).FirstOrDefault();

            return View(row);
        }

        [HttpPost]
        public IActionResult Delete(NewsModel obj)
        {
            if (ModelState.IsValid)
            {
                _context.News.Remove(obj);
                int a = _context.SaveChanges();

                if (a > 0)
                {
                    TempData["msg"] = "Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Invalid Object";
            return View();

        }
    }
}
