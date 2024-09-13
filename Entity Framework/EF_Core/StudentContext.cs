using Microsoft.EntityFrameworkCore;

namespace EF_Core
{
    public class StudentContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionstring = "Server=SS-2024-05-015\\PRATHAMESH;Database=EFCoreDB;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionstring);

        }
    }
}
