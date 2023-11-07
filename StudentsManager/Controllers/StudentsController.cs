using DAL.Entities;
using StudentsManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using StudentsManager.DAL.Context;

namespace StudentsManager.Controllers
{
    public class StudentsController : Controller
    {
        public StudentsDBProvider DbProvider { get; }
        public StudentsController(StudentsDBContext db)
        {
            DbProvider = new StudentsDBProvider(db);
        }

        private void Log(string action, StudentView student)
        {
            Console.WriteLine("{0}: {1}. {2} {3} {4}", action, student.Id, student.LastName, student.Name, student.Patronymic);
        }

        public IActionResult Index()
        {
            var students = DbProvider.GetStudents()
                .ToArray();

            return View(students);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return View(new StudentView());
            }

            var student = DbProvider.Get(id);
            var studentView = new StudentView(student);

            return View(studentView);
        }

        [HttpPost]
        public IActionResult Edit(StudentView student)
        {
            Log("Edit", student);
            DbProvider.Update(student);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(StudentView student)
        {
            Log("Create", student);
            DbProvider.Create(student);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(StudentView student)
        {
            Log("Delete", student);
            DbProvider.Delete(student.Id);

            return RedirectToAction("Index");
        }
    }
}