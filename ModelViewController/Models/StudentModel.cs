using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelViewController.Models
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class StudentModel
    {
        //public int rollNo { get; set; }
        //[Required(ErrorMessage ="Please Enter Correct Name")]

        //[StringLength(15, MinimumLength = 3)]
        [Key]
        public int Id { get; set; }

        //[EmailAddress]
        [Column("StudentName",TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Age is Must")]
        //[Range(10, 50, ErrorMessage = "Age must between 10 and 50")]
        [Column("StudentGender", TypeName = "varchar(20)")]
        [Required]
        public string Gender { get; set; }
        [Required]
        public int? Age { get; set; }

        [Required]
        public int? standard { get; set; }

        //[Required(ErrorMessage = "Password is Must")]
        //[RegularExpression("(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Password must contain 1 capital and 1 special character")]
        //public string Password { get; set; }

        //[Required(ErrorMessage = "ConfirmPassword is must")]
        //[Compare("Password", ErrorMessage = "Both passwords must be identical")]
        //public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Url is must")]
        //[Url(ErrorMessage = "Invalid Url")]
        //public string WebsiteUrl { get; set; }
       
        //public string Gender { get; set; }

        //public int Standard { get; set; }

    }
}