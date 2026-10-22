using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial
{
    internal class _12_Functions : Runner
    {
        public async Task RunAsync()
        {
            var context = new ApplicationDbContext();

            // Calling the Mapped Function;
            var courses = context.Courses.Select(course => new
            {
                courseId = course.Id,
                Name = course.Name,
                TotalStudents = context.GetTotalStudentsForCourse(course.Id)
            });
            
            foreach(var course in courses)
            {
                Console.WriteLine(course);
            }
        }
    }
}
