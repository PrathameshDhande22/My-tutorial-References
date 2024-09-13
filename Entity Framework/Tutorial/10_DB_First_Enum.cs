using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    class _10_DB_First_Enum
    {
        public static databasesettings db = new databasesettings();

        public static void EnumSupport()
        {
            // Accessing the data as Eum
            var employess = db.EmployeeRoles;
            Console.WriteLine("RoleId\tRoleValue\tRoleName");
            foreach (var role in employess)
            {
                Console.WriteLine($"{role.id}\t{role.roleu.Value}\t{Enum.GetName(typeof(UserRoles), role.roleu)}"); // Prints its value with Enum name
            }
        }
    }
}
