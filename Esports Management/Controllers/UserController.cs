using Esports_Management.Data;
using Esports_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esports_Management.Controllers
{
    public class UserController : Controller
    {

        private ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.User.Include(a => a.Organizer).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            ViewBag.Coll = _context.Organizer.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserModel obj)
        {

            if (obj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.User.Add(obj);
                int a = _context.SaveChanges();

                if (a > 0)
                {
                    TempData["msg"] = "New Row Inserted Successfully";
                }
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
            var row = _context.User.Include(student => student.Organizer).Where(a => a.Id == id).FirstOrDefault();

            ViewBag.Coll = _context.Organizer.ToList();

            return View(row);
        }

        [HttpPost]

        public IActionResult Edit(UserModel obj)
        {
            if (obj == null)
            {

                return BadRequest();
            }
            else
            {
                _context.User.Update(obj);
                int a = _context.SaveChanges();

                if (a > 0)
                {
                    TempData["msg"] = "Row Updated Successfully";
                }
                return RedirectToAction("Index");
            }
        }

        public IActionResult Details(int id)
        {
            var list = _context.User.Include(a => a.Organizer).Where(x => x.Id == id).FirstOrDefault();
            return View(list);
        }
        public IActionResult Delete(int id)
        {
            var row = _context.User.Include(student => student.Organizer).Where(a => a.Id == id).FirstOrDefault();


            return View(row);
        }

        [HttpPost]
        public IActionResult Delete(UserModel obj)
        {
            if (obj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.User.Remove(obj);
                int a = _context.SaveChanges();
                if (a > 0)
                {
                    TempData["msg"] = "Row Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
        }

    }
}
