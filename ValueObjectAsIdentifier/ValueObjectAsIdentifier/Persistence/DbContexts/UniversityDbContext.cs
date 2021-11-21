using Framework.Tools.Extensions;
using Microsoft.EntityFrameworkCore;
using UseValueObjectAsIdentifier.Domain.Models;
using UseValueObjectAsIdentifier.Persistence.Mappings;

namespace UseValueObjectAsIdentifier.Persistence.DbContexts
{
    public class UniversityDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=University;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentMapping).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.UseValueConverter(new CourseIdValueConverter());
            modelBuilder.UseValueConverter(new StudentIdValueConverter());
            modelBuilder.UseValueConverter(new StudentCourseIdValueConverter());
        }
    }
}
