using System;
namespace LINQTOSQL
{
    class _04_Stored_Procedure
    {
        public static void CallStoredProcedure()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            // Calling the stored procedure
            var results = dc.getEmployees();

            foreach (var emp in results)
            {
                Console.WriteLine($"id={emp.ID} first_name={emp.FirstName} last_name={emp.LastName} gender={emp.Gender} dept={emp.Department.Name}");
            }

            // Calling the stored procedure with output parameter
            int? count = 0;
            var results2 = dc.getTotalEmployeeCount("Female", ref count);
            Console.WriteLine("Total Employees: {0}", count);
            Console.WriteLine(results2);


            // calling the stored procedure which throws error
            //var results3 = dc.spThrowError();
            //Console.WriteLine(results3);

            // calling the stored procedure with table-valued-parameters

        }
    }
}
