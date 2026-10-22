using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial
{
    internal class _14_ExecuteUpdate : Runner
    {
        public async Task RunAsync()
        {
            var context = new ApplicationDbContext();

            // Get the students 
            var students = context.Students.
                ExecuteUpdate(setters =>
                {
                    // Setting the property with value
                    setters.SetProperty(p => p.Age, 40);
                });

            Console.WriteLine($"Updated Students ={students}");
        }
    }
}
