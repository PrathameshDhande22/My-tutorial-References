using EFCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial
{
    internal class _07_Tracking_No_Tracking_Queries : Runner
    {
        public async Task RunAsync()
        {
            var context = new ApplicationDbContext();

            // These is the Query with Tracking 
            var students = context.Students.Where(st => st.Age > 10).FirstOrDefault();
            students.Age = 1000;
            context.SaveChanges();

            // No Tracking Queries
            var students_no_tracking = context.Students.Where(st => st.Age > 20).AsNoTracking().ToList();
            foreach(Student student in students_no_tracking)
            {
                Console.WriteLine(student);
            }


        }
    }
}
