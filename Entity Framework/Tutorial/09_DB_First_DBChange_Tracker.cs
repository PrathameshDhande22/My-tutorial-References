using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    class _09_DB_First_DBChange_Tracker
    {
        public static databasesettings db = new databasesettings();
        public static void DBChangeTrackerInEF()
        {
            StudentCheck st1 = new StudentCheck() { id = 38, name = "Backspace", school = "Vaibhav" };
            db.StudentChecks.Add(st1);

            Console.WriteLine("Tracking the Changes of {0}", db.ChangeTracker.Entries().Count());
            PrintTheChanges(db.ChangeTracker);

            Employee emp = new Employee() { Gender = "Male", DepartmentId = 1, FirstName = "Rahul", LastName = "Dhola", Salary = 23000, ID = 34 };
            db.Employees.Attach(emp);

            Console.WriteLine("Tracking the Changes of {0}", db.ChangeTracker.Entries().Count());
            PrintTheChanges(db.ChangeTracker);

            emp.Salary = 10000;
            Console.WriteLine("Tracking the Changes of {0}", db.ChangeTracker.Entries().Count());
            PrintTheChanges(db.ChangeTracker);

        }

        private static void PrintTheChanges(DbChangeTracker chngtracker)
        {
            Console.WriteLine();
            var ctx = chngtracker.Entries(); // returns the Ienumerable of entityEntry
            foreach (var entry in ctx)
            {
                Console.WriteLine("Entity Name : {0}", entry.Entity.GetType().Name);
                Console.WriteLine("Entity State : {0}", entry.State);
            }
        }
    }
}
