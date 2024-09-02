using System;
using System.Linq;

namespace LINQTOSQL
{
    class _01_Basics
    {
        public static void SelectClauseBasics()
        {
            // Getting the database context to access the employee and department table
            DataClasses1DataContext datacontext = new DataClasses1DataContext();

            // Applying the select clause
            var results = from emp in datacontext.Employees
                          select emp; // returns the IQueryable interface of employee
            foreach (var emp in results)
            {
                Console.WriteLine($"id={emp.ID} first_name={emp.FirstName} last_name={emp.LastName} gender={emp.Gender} dept={emp.Department.Name}");
            }

        }
    }
}
