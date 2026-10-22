namespace EFCoreTutorial
{
    internal class _06_Create_Record : Runner
    {
        public async Task RunAsync()
        {
            var context = new ApplicationDbContext();

            Console.WriteLine("Saving the Courses Records");
            await context.Courses.AddRangeAsync(StudentSeedData.Courses);

            Console.WriteLine("Saving the Students");
            await context.Students.AddRangeAsync(StudentSeedData.Students);

            Console.WriteLine("Saving to DB Now");
            int affected_rows = await context.SaveChangesAsync();
            Console.WriteLine($"Affected Rows {affected_rows}");
        }
    }
}
