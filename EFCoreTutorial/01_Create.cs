using EFCoreTutorial.Models;

namespace EFCoreTutorial
{
    public class _01_Create : Runner
    {
        public async Task RunAsync()
        {
            // CRUD
            // Create the object of the db context
            var context = new ApplicationDbContext();

            // The Students entity model we created For new Records create the objects
            Student student1 = new Student()
            {
                FirstName = "Johnny",
                LastName = "Cacha",
                Age = 10
            };

            Student student2 = new()
            {
                FirstName = "Calvin",
                LastName = "Kelvin",
                Age = 20
            };

            Student student3 = new()
            {
                FirstName = "Danny",
                LastName = "Morals",
                Age = 24
            };

            // Add in the Context
            await context.Students.AddAsync(student1); // Adding only one record

            // Save the Changes to the DB
            await context.SaveChangesAsync();

            Console.WriteLine("Saving the Student1 Entity in the Database");

            // Add the entity in range
            await context.Students.AddRangeAsync(new List<Student>() { student2, student3 });

            // Save the Changes 
            await context.SaveChangesAsync();
        }
    }
}
