namespace ModelViewController.Models
{

    
    public class Employee
    {
        //public int EmpId { get; set; } 

        public Gender Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Designation { get; set; }

        public int Salary { get; set; }

        public string Married { get; set; }

        public string Description { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
