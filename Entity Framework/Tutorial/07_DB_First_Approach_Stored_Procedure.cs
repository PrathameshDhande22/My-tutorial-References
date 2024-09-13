using System.Data.Entity.Core.Objects;
using System;

namespace Tutorial
{
    class _07_DB_First_Approach_Stored_Procedure
    {
        public static databasesettings db = new databasesettings();

        public static void CallingStoredProcedureinEF()
        {
            // Calling the stored Procedure
            ObjectResult<Course> course = db.sp_GetCoursesOfStudentId(3);  // returns the ObjectResult<Course>

            foreach (Course c in course)
            {
                Console.WriteLine($"{c.CourseId}\t{c.CourseName}");
            }


            // Calling the stored procedure with output parameter
            ObjectParameter outputparams = new ObjectParameter("count", typeof(int)); // need to pass the object parameter with parameter name without @
            int no = db.sp_GetTotalStudentCourseByCount("Biology", outputparams); // call the sp
            Console.WriteLine(outputparams.Value); // accessing the value using value Property
            Console.WriteLine(no); // returns -1

            // Stored Procedure which Throws error
            try
            {
                db.spThrowError(); // to handle these get the innner Exception

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message); // Printing the message of theInner Exception
            }

        }
    }
}
