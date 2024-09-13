using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    class _14_DB_First_Many_to_many
    {
        public static void ManytoMany()
        {
            databasesettings db=new databasesettings();

            foreach(var res in db.Students)
            {
                Console.WriteLine($"Id={res.StudentId}\tName={res.StudentName}");
                foreach(var stu in res.Courses)
                {
                    Console.WriteLine($"\tstudID={stu.CourseId}\tName={stu.CourseName}");
                }
            }
        }
    }
}
