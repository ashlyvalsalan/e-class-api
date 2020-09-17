using System;
using Microsoft.EntityFrameworkCore;
namespace e_class.Models
{
    public class ApplicationDatabase : DbContext
    {
        public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
