using EFCoreTutorial.Models;

namespace EFCoreTutorial
{
    public class _02_Read : Runner
    {
        public async Task RunAsync()
        {
            // Reading the objects from the Database

            // Initialize the context object
            var context = new ApplicationDbContext();

            // Read the records using the context directly
            var students = context.Students.ToList();

            foreach (Student stud in students)
            {
                Console.WriteLine(stud);
            }

            Console.WriteLine();

            // Reading the records using the LINQ Queries directly -- Returns IQueryAble
            IQueryable<Student> students_queries = from student in context.Students
                                                   where student.Age > 10
                                                   select student;
            foreach(Student stud in students_queries)
            {
                Console.WriteLine(stud);
            }
        }
    }
}
