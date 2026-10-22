using EFCoreTutorial.Models;

namespace EFCoreTutorial
{
    internal class _09_LazyLoading : Runner
    {
        public async Task RunAsync()
        {
            var context = new ApplicationDbContext();

            // loading the students
            var student = context.Students.Find(10);

            Console.WriteLine(student);

            // Loading its related entities
            foreach(Course course in student.Courses)
            {
                Console.WriteLine(course);
            }

            // Loading its related entities
            foreach(Address address in student.Address)
            {
                Console.WriteLine(address);
            }

            Console.WriteLine(student.StudentProfile);

        }
    }
}
