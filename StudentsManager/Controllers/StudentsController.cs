using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsManager.DAL.Context;

namespace StudentsManager.Controllers
{
    public class StudentsController : Controller
    {
        public StudentsDBContext Db { get; }

        public StudentsController(StudentsDBContext db)
        {
            Db = db;
        }

        public async Task<IActionResult> Index()
        {
            var students = await Db.Students.ToArrayAsync();
            return View(students);
        }

        public IActionResult Edit()
        {


            return View();
        }
    }
}
