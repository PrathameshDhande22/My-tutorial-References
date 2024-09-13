using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    class _05_DB_First_BULK_Operations
    {
        public static databasesettings db = new databasesettings();

        public static void BulkOperations()
        {
            //DeleteBulkOperations();
            //InsertBulkOperations(); // Calls the Insert sQL Statement for the number of Entities you add
            UpdateBulkOperation();
        }

        private static void UpdateBulkOperation()
        {
            var students = from stud in db.StudentChecks
                           where stud.rollno > 33 && stud.rollno < 36
                           select stud;
            // updating their school
            foreach (var student in students)
            {
                student.school = "Detained";
            }
            db.Database.Log = Console.Write;
            db.SaveChanges();
        }

        private static void InsertBulkOperations()
        {
            StudentCheck st1 = new StudentCheck() { id = 32, name = "Liver", school = "BMS" };
            StudentCheck st2 = new StudentCheck() { id = 33, name = "Silver", school = "BAMS" };
            StudentCheck st3 = new StudentCheck() { id = 34, name = "Ranger", school = "Denmark" };

            // After creating the instances of the Student now we want to insert them
            db.Database.Log = Console.Write;

            // Adding using AddRange() method
            db.StudentChecks.AddRange(new List<StudentCheck> { st1, st2, st3 });

            // save the chagnes
            db.SaveChanges();
        }

        public static void DeleteBulkOperations()
        {

            var students = from stud in db.StudentChecks
                           where stud.rollno > 26 && stud.rollno < 30
                           select stud;
            Console.WriteLine("Students");
            foreach (var student in students)
            {
                Console.WriteLine(student.name);
            }
            db.StudentChecks.RemoveRange(students); // removing the student in range
            db.SaveChanges();
        }
    }
}
