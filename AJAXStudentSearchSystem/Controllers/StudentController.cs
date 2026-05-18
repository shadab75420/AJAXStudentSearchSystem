using AJAXStudentSearchSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace AJAXStudentSearchSystem.Controllers
{
    public class StudentController : Controller
    {
        // Sample Student Data
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                StudentId = 101,
                Name = "Alice",
                Department = "CSE",
                Email = "alice@gmail.com",
                City = "Delhi"
            },

            new Student
            {
                StudentId = 102,
                Name = "Bob",
                Department = "EEE",
                Email = "Bob@gmail.com",
                City = "Mumbai"
            },

            new Student
            {
                StudentId = 103,
                Name = "John Smith",
                Department = "BBA",
                Email = "john@gmail.com",
                City = "Kolkata"
            }
        };

        // Load Page
        public IActionResult Index()
        {
            return View();
        }

        // AJAX Search Method
        [HttpGet]
        public JsonResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Student not found"
                });
            }

            return Json(new
            {
                success = true,
                data = student
            });
        }
    }
}