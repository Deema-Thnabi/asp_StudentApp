using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using StudentApp.Models;

namespace StudentApp.Controllers
{
	public class StudentsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public StudentsController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View(_context.Students.AsNoTracking().ToList());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
        public IActionResult Create(Student model)
        {
			_context.Students.Add(model);
			_context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid id)
        {
            return View(_context.Students.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Student model)
        {
			var student = _context.Students.Find(model.Id);
			if (student is not null)
			{
                if (model.Name is not null)
                {
                    student.Name = model.Name;
                }
                if (model.Email is not null)
                {
                    student.Email = model.Email;
                }
                if (model.Password is not null)
                {
                    student.Password = model.Password;
                }
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            //var student = _context.Students.Find(id);
            _context.Students.Remove(_context.Students.Find(id));
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
