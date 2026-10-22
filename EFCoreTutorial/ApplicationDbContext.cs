using EFCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreTutorial
{
    // Create the DbContext class by inheriting from the EFCore DbContext
    public class ApplicationDbContext : DbContext
    {
        // Overriding the Configuration method for configuring the Database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Creating the Connection String for SQL Server connection.
            string connectionString = "Server=localhost;Database=EFCoreTutorial;User Id=sa;Password=Password@2026;TrustServerCertificate=True;";

            // Using the SQL Server as the Db server
            optionsBuilder
                .UseSqlServer(connectionString, options =>
                {
                    // Enabling the Split Query
                    //options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                })
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();

            // Enabling the Lazy loading for the DbContext
            //optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        // Define the Entity or Called as Tables
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentProfiles> StudentProfiles { get; set; }

        // Applying the DbFunction
        public int GetTotalStudentsForCourse(int courseid) => throw new NotSupportedException();

        // Override the method for Table Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API Configuration -- Modifying the column in the table
            modelBuilder.Entity<Student>()
                .Property(p => p.Age)
                .IsRequired();

            // Grouping Configuration
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);

            // Mapping the dbFunction with already present in the database
            modelBuilder.HasDbFunction(typeof(ApplicationDbContext).GetMethod(nameof(GetTotalStudentsForCourse), [typeof(int)])!)
                .HasName("fn_GetTotalStudentInCourse")
                .HasSchema("dbo");
        }

    }
}
