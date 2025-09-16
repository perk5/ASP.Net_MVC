using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ModelViewController.Models;

namespace ModelViewController.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            List<StudentModel> studentModels = new List<StudentModel>();
            studentModels.Add(new StudentModel { rollNo = 1, Name = "Prerak", Gender = "Male", Standard = 5 });
            studentModels.Add(new StudentModel { rollNo = 2, Name = "Raj", Gender = "Male", Standard = 10 });
            studentModels.Add(new StudentModel { rollNo = 3, Name = "Rani", Gender = "Female", Standard = 12 });
            studentModels.Add(new StudentModel { rollNo = 4, Name = "Ankita", Gender = "Female", Standard = 8 });

            var students = studentModels;

            ViewData["MyStudents"] = students;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
