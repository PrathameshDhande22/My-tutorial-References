using System;
using System.Linq;

namespace LINQTOSQL
{
    class _07_Practice
    {
        public static void LINQSQLPractice()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            // Applying the join operation on the table.
            var query = from emp in dc.Employees
                        join dept in dc.Departments
                        on emp.DepartmentId equals dept.ID
                        select new { emp, dept };

            // viewing its equivalent query
            Console.WriteLine(dc.GetCommand(query).CommandText);

            // printing the results
            foreach (var res in query)
            {
                Console.WriteLine($"id={res.emp.ID} Name={res.emp.FirstName + ' ' + res.emp.LastName}\n\tid={res.dept.ID} dept name={res.dept.Name}");
            }
            Console.WriteLine();

            // groupby operator
            var query2 = from emp in dc.Employees
                         join dept in dc.Departments
                         on emp.DepartmentId equals dept.ID
                         group emp by dept.Name into egroup
                         select egroup;
            Console.WriteLine(query2.ToString());
            foreach (var res in query2)
            {
                Console.WriteLine($"Dept name={res.Key} | count={res.Count()}");
            }
            Console.WriteLine();

            // left outer join
            var query3 = from emp in dc.Employees
                         join dept in dc.Departments
                         on emp.DepartmentId equals dept.ID into joined
                         from dept in joined.DefaultIfEmpty()
                         select new { emp, Department = dept == null ? new Department() { Name = "Unknown" } : dept };

            Console.WriteLine(query2.ToString());
            foreach (var res in query3)
            {
                Console.WriteLine($"id={res.emp.ID} Name={res.emp.FirstName + ' ' + res.emp.LastName}\n\tid={res.Department.ID} dept name={res.Department.Name}");

            }
        }
    }
}
