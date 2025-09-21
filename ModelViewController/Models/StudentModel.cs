using System;
using System.ComponentModel.DataAnnotations;


namespace ModelViewController.Models
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class StudentModel
    {
        //public int rollNo { get; set; }
        [Required(ErrorMessage ="Please Enter Correct Name")]

        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is Must")]
        [Range(10, 50, ErrorMessage = "Age must between 10 and 50")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Password is Must")]
        [RegularExpression("(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Password must contain 1 capital and 1 special character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is must")]
        [Compare("Password", ErrorMessage = "Both passwords must be identical")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Url is must")]
        [Url(ErrorMessage = "Invalid Url")]
        public string WebsiteUrl { get; set; }
       
        //public string Gender { get; set; }

        //public int Standard { get; set; }

    }
}