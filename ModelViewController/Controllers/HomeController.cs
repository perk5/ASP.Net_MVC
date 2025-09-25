using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ModelViewController.Models;
//using ModelViewController.Repository;
using System.Diagnostics;
using System.Net.Sockets;

namespace ModelViewController.Controllers
{

    public enum Gender
    {
        Male,
        Female
    }

    

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

        public IActionResult Products()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Id=1, Name="picture1", Description="firstImage", Price=20.00, Image="~/images/profile_pic.png" },
                new Product() { Id=2, Name="picture2", Description="secondImage", Price=40.00, Image="~/images/spider.png" }
            };

            return View(products);
        }

        public StudentModel DDL()
        {
            StudentModel stdModel = new StudentModel();
            stdModel.StudentsList = new List<SelectListItem>();

            var data = studentDB.Students.ToList();

            stdModel.StudentsList.Add(new SelectListItem
            {
                Text = "Select Name",
                Value = ""
            });

            foreach (var item in data)
            {
                stdModel.StudentsList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return stdModel;
        }

        

        public IActionResult Index1()
        {

            //StudentModel stdModel = new StudentModel();
            //stdModel.StudentsList = new List<SelectListItem>();

            //var data = studentDB.Students.ToList();

            //stdModel.StudentsList.Add(new SelectListItem
            //{
            //    Text = "Select Name",
            //    Value = ""
            //});

            //foreach (var item in data)
            //{
            //    stdModel.StudentsList.Add(new SelectListItem
            //    {
            //        Text = item.Name,
            //        Value = item.Id.ToString()
            //    });
            //}

            var data = DDL();   

            HttpContext.Session.SetString("MyKey","SuperSimpleDev");

            List<SelectListItem> Gender = new()
            {
                new SelectListItem {Value= "Male", Text="Male"},
                new SelectListItem {Value= "Female", Text="Female"}
            };
            ViewBag.Gender = Gender;
            return View(data);
        }
        [HttpPost]
        public IActionResult Index1(StudentModel sm)
        {
            
            if(sm != null)
            {
                sm = studentDB.Students.Where(x => x.Id == sm.Id).FirstOrDefault();
            }
            var data = DDL();
            if(sm != null)
            {
                ViewBag.Name = sm.Name;
            }
            return View(data);
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
            List<SelectListItem> Gender = new()
            {
                new SelectListItem {Value= "Male", Text="Male"},
                new SelectListItem {Value= "Female", Text="Female"}
            };
            ViewBag.Gender = Gender;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentModel sm)
        {

            List<SelectListItem> Gender = new()
            {
                new SelectListItem {Value= "Male", Text="Male"},
                new SelectListItem {Value= "Female", Text="Female"}
            };
            ViewBag.Gender = Gender;

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
            List<SelectListItem> Gender = new()
            {
                new SelectListItem {Value= "Male", Text="Male"},
                new SelectListItem {Value= "Female", Text="Female"}
            };
            ViewBag.Gender = Gender;
            var data = await studentDB.Students.FindAsync(id);      
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, StudentModel sm)
        {
            List<SelectListItem> Gender = new()
            {
                new SelectListItem {Value= "Male", Text="Male"},
                new SelectListItem {Value= "Female", Text="Female"}
            };
            ViewBag.Gender = Gender;                        
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
