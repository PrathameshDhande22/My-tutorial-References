using System;
using System.Threading.Tasks;

namespace Tutorial
{
    class _04_DB_First_Asynchronus
    {
        public static databasesettings db = new databasesettings();
        public static async Task AsynchronousProgramming()
        {
            // Finding the Students by findAsync
            var res = await db.StudentChecks.FindAsync(20); // must pass one primary key
            Console.WriteLine(res); // returns the StudentCheck single class only

            // Saving Asynchronous
            StudentCheck stnew = new StudentCheck() { id = 31, name = "Denmakr", school = "BHMLS" };
            db.StudentChecks.Add(stnew); // add the entity

            // Save the changes asynchronously
            int rows = await db.SaveChangesAsync();
            Console.WriteLine(rows);

        }
    }
}
