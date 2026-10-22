namespace EFCoreTutorial
{
    internal class _03_Update : Runner
    {
        public async Task RunAsync()
        {
            // Initialize the Context object
            ApplicationDbContext context = new ApplicationDbContext();

            // Get the equivalent record (Retreive the Record)
            var student = context.Students.Where(st => st.Id == 2).FirstOrDefault();

            Console.WriteLine("Before Updating Entity state=" + context.Entry(student).State);
            Console.WriteLine($"Retrieved Values =>{student.Id} Name={student.FirstName} {student.LastName}");

            // Now updating the value for the retrieved
            student.FirstName = "NA";

            // Get the Entity state 
            Console.WriteLine("After Updating Entity state=" + context.Entry(student).State);

            // Saving the Changes
            await context.SaveChangesAsync();

            Console.WriteLine("updated the data");
        }
    }
}
