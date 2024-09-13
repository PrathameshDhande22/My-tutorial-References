using EF_Core;

class Program
{
    static void Main()
    {
        StudentContext context = new StudentContext();
        // create the database
        context.Database.EnsureCreated();

        //create entity objects
        var grd1 = new Grade() { GradeName = "1st Grade" };
        var std1 = new Student() { Name = "Rajput", City = "Vashi", Address = "Sector 16", Grade = grd1 };

        //add entitiy to the context
        context.Students.Add(std1);

        //save data to the database tables
        context.SaveChanges();

        //retrieve all the students from the database
        foreach (var s in context.Students)
        {
            Console.WriteLine($"{s.Id}\t{s.Grade.GradeName}\t{s.Address}\t{s.Name}");
        }

        Console.WriteLine();
        var results = from grade in context.Grades
                      select grade;
        foreach (var s in results)
        {
            Console.WriteLine($"{s.GradeName}\t{s.GradeId}");
        }
    }
}