namespace EFCoreTutorial
{
    internal class _04_Delete : Runner
    {
        public async Task RunAsync()
        {
            // Initialize Db Context
            var context = new ApplicationDbContext();

            // Retrieve the data which want to delete
            var student = (from students in context.Students
                          where students.Id.Equals(2)
                          select students).FirstOrDefault();

            // removing
            context.Students.Remove(student);

            // Save the changes
            await context.SaveChangesAsync();

            Console.WriteLine($"Removed Student={student}");

        }
    }
}
