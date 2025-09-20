using Microsoft.AspNetCore.Mvc;
using ModelViewController.Models;
//using ModelViewController.Repository;
using System.Diagnostics;

namespace ModelViewController.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private readonly StudentRepository _studentRepository = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //this._studentRepository = new StudentRepository();
        }

        //public List<StudentModel> getAllStudents()
        //{
        //    return _studentRepository.getAllStudent();
        //}

        //public StudentModel getStudentById(int id)
        //{
        //    return _studentRepository.getStudentById(id);
        //}

        
        public IActionResult Index()
        {

            //Employee emp = new Employee()
            //{
            //    EmpId = 101,
            //    EmpName = "Prerak",
            //    Designation = "Manger",
            //    Salary = 25000
            //};
            //ViewData["EmpInfo"] = emp;

            //List<Employee> EmployeeModels = new List<Employee>();
            //EmployeeModels.Add(new Employee { EmpId = 1, EmpName = "Prerak", Designation = "Male", Salary = 5 });
            //EmployeeModels.Add(new Employee { EmpId = 2, EmpName = "Raj", Designation = "Male", Salary = 10 });
            //EmployeeModels.Add(new Employee { EmpId = 3, EmpName = "Rani", Designation = "Female", Salary = 12 });
            //EmployeeModels.Add(new Employee { EmpId = 4, EmpName = "Ankita", Designation = "Female", Salary = 8 });

            //var Emp = EmployeeModels;

            //ViewData["MyStudents"] = students;
            return View();
        }



        [HttpPost]
        public IActionResult Index(StudentModel sm)
        {
            return View();
            //return "Name: " + emp.Name + " Salary: " + emp.Salary + " Age: " + emp.Age + " Gender: " + emp.Gender + " Designation: " + emp.Designation + " Married: " + emp.Married + " Description: " + emp.Description;
            //if (ModelState.IsValid)
            //{
            //    return "Form sent successfully Name is " + sm.Name;
            //}
            //else
            //{
            //    return "There was a problem sending the form....";
            //}

                
        }

        public string Details(int id,  string name)
        {
            return "Id is: " + id + " Name is: " + name;
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
