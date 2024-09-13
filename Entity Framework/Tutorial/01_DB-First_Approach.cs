using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SqlClient;
using Dapper;


namespace Tutorial
{
    class _01_DB_First_Approach
    {
        public static databasesettings dc = new databasesettings();
        public static void DBFirstApproach()
        {
            // Tutorial based on DB First Approach

            //InsertOperation();
            //SelectOperation();
            //DapperSelectOperation();
            //UpdateOperation();
            //DeleteOperation();
        }

        public static void InsertOperation()
        {
            // Accessing the Context class created while creating the designer
            databasesettings nwDatabaseContext = new databasesettings();

            // Adding the new Data to the database
            Employee employee = new Employee() { ID = 87, FirstName = "y", LastName = "dfas", Gender = "Male", Salary = 45000 };

            // Adding the instance of the employee into the employees Class
            nwDatabaseContext.Employees.Add(employee);

            // Saving the changes after adding to commit to the database
            int returneddata = nwDatabaseContext.SaveChanges();

            // Returns the number inserted data into the database.
            Console.WriteLine(returneddata);
        }

        public static void SelectOperation()
        {
            Stopwatch st = new Stopwatch();
            st.Start();

            // create an instance of data context
            databasesettings nwDatabaseContext = new databasesettings();

            // Retrieving the data from the database
            List<Employee> employees = nwDatabaseContext.Employees.Select(emp => emp).ToList();

            st.Stop();
            Console.WriteLine(st.Elapsed);

            foreach (var res in employees)
            {
                Console.WriteLine($"Id={res.ID} \t Name={res.FirstName + res.LastName} \t Gender={res.Gender}");
            }

            // using linq query
            var results = from emp in nwDatabaseContext.Employees
                          select emp;
            Console.WriteLine(results.ToString()); // printing the sql query of the related linq query
            Console.WriteLine();
            // printing the results
            foreach (var res in results)
            {
                Console.WriteLine($"Id={res.ID} \t Name={res.FirstName + res.LastName} \t Gender={res.Gender}");
            }
        }

        public static void DapperSelectOperation()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string connection = "Server=localhost;Database=newdatabase;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection connect = new SqlConnection(connection);
            var res = connect.Query("Select * from employees");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        public static void UpdateOperation()
        {
            // Update Operation

            var employee = (from emp in dc.Employees
                           where emp.ID == 19
                           select emp).SingleOrDefault();

            // updating its department id to some id
            employee.DepartmentId = 3;

            int rowsaffected=dc.SaveChanges();
            Console.WriteLine(rowsaffected);
        }

        public static void DeleteOperation()
        {
            var employees = dc.Employees.Where(emp => emp.ID == 19 );

            // remove the data from the employees 
            dc.Employees.RemoveRange(employees);
            // save the changes
            dc.SaveChanges();
        }
    }
}
