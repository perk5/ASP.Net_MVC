using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ModelViewController.Models;
//using ModelViewController.Repository;
using System.Diagnostics;

namespace ModelViewController.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDB;

        public HomeController(StudentDBContext studentDB)
        {
            this.studentDB = studentDB;
        }
        //private readonly ILogger<HomeController> _logger;

        //private readonly StudentRepository _studentRepository = null;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //    //this._studentRepository = new StudentRepository();
        //}

        //public List<StudentModel> getAllStudents()
        //{
        //    return _studentRepository.getAllStudent();
        //}

        //public StudentModel getStudentById(int id)
        //{
        //    return _studentRepository.getStudentById(id);
        //}

        public IActionResult Index1()
        {
            HttpContext.Session.SetString("MyKey","SuperSimpleDev");
            return View();
        }

        public IActionResult Index2()
        {
            if (HttpContext.Session.GetString("MyKey") != null)
            {
                ViewBag.Data = HttpContext.Session.GetString("MyKey").ToString();
            }
            return View();
        }


        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("MyKey") != null)
            {
                HttpContext.Session.Remove("MyKey");
            }
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var stdData = await studentDB.Students.ToListAsync();
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
            return View(stdData);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentModel sm)
        {
            if (ModelState.IsValid)
            {
                await studentDB.Students.AddAsync(sm);
                await studentDB.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(sm);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var Data = await studentDB.Students.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (Data == null)
            {
                return NotFound();  
            }
            return View(Data);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var data = await studentDB.Students.FindAsync(id);      
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, StudentModel sm)
        {
            if (id != sm.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                studentDB.Update(sm);
                await studentDB.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(sm);   
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || studentDB.Students == null)
            {
                return NotFound();
            }

            var Data = await studentDB.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (Data == null)
            {
                return NotFound();
            }

            return View(Data);
            //studentDB.Remove(Data);
            //await studentDB.SaveChangesAsync();
            //return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var stdData = await studentDB.Students.FindAsync(id);

            if (stdData != null)
            {
                studentDB.Students.Remove(stdData);
            }
            await studentDB.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
           


            //[HttpPost]
            //public IActionResult Index(StudentModel sm)
            //{

            //    //if (ModelState.IsValid)
            //    //{
            //    //    ModelState.Clear();
            //    //}

            //    //return View();
            //    //return "Name: " + emp.Name + " Salary: " + emp.Salary + " Age: " + emp.Age + " Gender: " + emp.Gender + " Designation: " + emp.Designation + " Married: " + emp.Married + " Description: " + emp.Description;
            //    //if (ModelState.IsValid)
            //    //{
            //    //    return "Form sent successfully Name is " + sm.Name;
            //    //}
            //    //else
            //    //{
            //    //    return "There was a problem sending the form....";
            //    //}


            //}

            //public string Details(int id,  string name)
            //{
            //    return "Id is: " + id + " Name is: " + name;
            //}

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
