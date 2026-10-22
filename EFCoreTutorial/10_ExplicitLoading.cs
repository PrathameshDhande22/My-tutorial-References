using EFCoreTutorial.Models;

namespace EFCoreTutorial
{
    internal class _10_ExplicitLoading : Runner
    {
        public async Task RunAsync()
        {
            var context = new ApplicationDbContext();

            // Loading the student
            var student = context.Students.Find(20);

            // Based on one Student load the its related entity
            Console.WriteLine(student);

            if (student.Courses.Any())
            {
                Console.WriteLine("Contains Courses No need to fetch");
            }
            else
            {
                // Explicit loading 
                context.Entry(student).Collection(st=>st.Courses).Load();

                foreach (Course course in student.Courses)
                {
                    Console.WriteLine(course);
                }
            }
        }
    }
}
