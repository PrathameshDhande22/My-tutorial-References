using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Tutorial
{
    class _13_DB_First_Transactions
    {
        public static databasesettings db = new databasesettings();
        public static void TransactionSupportinEF()
        {
            // Begin the transaction
            bool ToThrowError = false;
            DbContextTransaction transaction = db.Database.BeginTransaction();
            try
            {
                StudentCheck stnew = new StudentCheck() { id = 45, name = "Dhruva", school = "Bhs" };

                db.StudentChecks.Add(stnew);
                db.SaveChanges();

                Course course = new Course() { CourseName = "Zoology" };
                db.Courses.Add(course);
                db.SaveChanges();
                if (ToThrowError)
                {
                    throw new Exception("Not Possible to Add");
                }
                transaction.Commit(); // to Commit the transaction
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // To  Rollback the transaction
                Console.WriteLine(ex);
            }
        }
    }
}
