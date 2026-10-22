using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial
{
    internal class _11_Split_Query : Runner
    {
        public async Task RunAsync()
        {
            var context = new ApplicationDbContext();

            var students = context.Students.
                                Include(st => st.StudentProfile).
                                Include(st => st.Address)
                                .AsSplitQuery()  // Specifying the AsSplitQuery 
                                .Where(st => st.Id == 19)
                                .FirstOrDefault();

            Console.WriteLine(students);
        }
    }
}
