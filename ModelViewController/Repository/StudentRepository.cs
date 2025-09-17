using ModelViewController.Models;

namespace ModelViewController.Repository
{
    public class StudentRepository : IStudent
    {
       public StudentModel getStudentById(int id)
       {
            return DataSource().Where(x => x.rollNo == id).FirstOrDefault();
       }

        public List<StudentModel> getAllStudent()
        { 
            return DataSource(); 
        }

        private List<StudentModel> DataSource()
        {
            List<StudentModel> studentModels = new List<StudentModel>();
            studentModels.Add(new StudentModel { rollNo = 1, Name = "Prerak", Gender = "Male", Standard = 5 });
            studentModels.Add(new StudentModel { rollNo = 2, Name = "Raj", Gender = "Male", Standard = 10 });
            studentModels.Add(new StudentModel { rollNo = 3, Name = "Rani", Gender = "Female", Standard = 12 });
            studentModels.Add(new StudentModel { rollNo = 4, Name = "Ankita", Gender = "Female", Standard = 8 });

            return studentModels;
        }
    }
}
