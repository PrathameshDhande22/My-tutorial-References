using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial
{
    internal class _13_ExecuteDelete : Runner
    {
        public async Task RunAsync()
        {
            var context = new ApplicationDbContext();

            // Getting the details of the Student
            var students = context.Students.Where(st => st.Age > 20);

            // Bulk Delete
            int deletedcount = students.ExecuteDelete();

            Console.WriteLine($"Deleted Students Count={deletedcount}");
            context.SaveChanges();
        }
    }
}
