using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    class _12_DB_First_Functions
    {
        public static databasesettings db = new databasesettings();
        public static void SQLFunctioninEF()
        {
            // calling the table-valued-function
            var results = db.fn_GetStudentDetails("Biology"); // Returns as IQueryable
            foreach(var row in results)
            {
                Console.WriteLine($"{row.StudentId}\t{row.StudentName}\t{row.CourseName}");
            }
            Console.WriteLine("\nMultiStatement");

            // Calling the multistatement-table-valued function
            var results3 = db.fn_GetStudentDetailsMulti("Chemistry");
            foreach (var row in results3)
            {
                Console.WriteLine($"{row.id}\t{row.StudentName}\t{row.CourseName}");
            }
        }
    }
}
