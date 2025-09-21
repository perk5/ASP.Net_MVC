using Microsoft.EntityFrameworkCore;

namespace ModelViewController.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<StudentModel> Students { get; set; }
    }
}
