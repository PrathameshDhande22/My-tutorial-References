using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    class _11_DB_First_Views
    {
        public static databasesettings db=new databasesettings();

        public static void ViewsinEf()
        {
            // Iterating over the data of the views
            foreach(var res in db.vw_GetEmployeeWithDept)
            {
                Console.WriteLine($"{res.empID}\t{res.FullName}\t{res.Name}\t{res.Gender}\t{res.deptID}");
            }
        }
    }
}
