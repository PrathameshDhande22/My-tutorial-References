using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    class _08_DB_First_CRUD_Stored_Procedure
    {
        public static databasesettings db = new databasesettings();

        public static void CRUDStored_Procedure()
        {
            InsertOperation();
        }



        private static void InsertOperation()
        {
            StudentCheck st1 = new StudentCheck() { id = 37, name = "Liverpool", school = "MGM" };
            db.StudentChecks.Add(st1); // calls the stored Procedure
            db.SaveChanges();
        }
    }
}
