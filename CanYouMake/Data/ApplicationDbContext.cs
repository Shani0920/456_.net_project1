using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuroraFeedbackPortal.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Course>().HasData(
            new Course { Id = 1, Name = "Algorithms", FacultyName = "Dr. Sarah Johnson" },
            new Course { Id = 2, Name = "Quantum Mechanics", FacultyName = "Dr. Emily Williams" },
            new Course { Id = 3, Name = "Data Structures", FacultyName = "Dr. Michael Chen" },
            new Course { Id = 4, Name = "Machine Learning", FacultyName = "Dr. Robert Smith" },
            new Course { Id = 5, Name = "Web Development", FacultyName = "Dr. Lisa Anderson" }
        );
    }
}
