using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.SqlClient;

namespace Tutorial
{
    class _02_DB_First_Querying
    {
        public static databasesettings db = new databasesettings();
        public static void QueryingInEF()
        {

            //LINQEntities(); // LINQ to SQL Entities
            //EntitySQl(); // Entity SQL
            //NativeSQL(); // Writing the pure sql
            EagerLoading(); // Eager Loading
            //ExplicitLoading(); // Explicit Loading
            //ExecuteRawQueries(); // Execute RAW SQl Queries.
        }

        public static void ExecuteRawQueries()
        {
            // Executing RAW Queries using SqlQuery() with sql parameter
            var employees = db.Employees.SqlQuery("select * from employees where id=@id", new SqlParameter("@id", 12));
            PrintEmployees(employees);
            Console.WriteLine();


            // Executing the RAW Queries using SqlQuery method of DbContext
            var onlyemp = db.Database.SqlQuery<Employee>("select * from employees");
            PrintEmployees(onlyemp);

            // Executing the dml statements using SQlCommand method of Dbcontext
            int rowsaffected = db.Database.ExecuteSqlCommand("delete from employees where id=@id", new SqlParameter("@id", 12));
            Console.WriteLine("Rows Affected : {0}",rowsaffected);

            void PrintEmployees(dynamic empl)
            {
                foreach (var emp in empl)
                {
                    Console.WriteLine($"Id={emp.ID}\tName={emp.FirstName}");
                }
            }
        }

        public static void EagerLoading()
        {
            var results = db.Employees.Include("Department").Select(emp => emp).ToList();
            foreach (var row in results)
            {
                string deptname = "No";
                if (row.Department != null)
                {
                    deptname= row.Department.Name;
                }
                Console.WriteLine($"Id={row.ID}\tName={row.FirstName}\tDept={deptname}");
            }
        }

        public static void LINQEntities()
        {
            // linq to SQl Entities
            var results = from emp in db.Employees
                          where emp.ID == 11 || emp.ID == 12
                          select emp;  // returns as iQueryable INterface of employee

            // iterating over the results
            foreach (var row in results)
            {
                Console.WriteLine($"ID={row.ID}\tname={row.FirstName}");
            }
        }
        public static void EntitySQl()
        {
            // writing the entity sql these sql is name from there only.
            string query = "Select Value emp from newdatabaseEntities1.Employees as emp where emp.FirstName=='Mark'";

            // coverting the database context to object context
            ObjectContext objctx = (db as IObjectContextAdapter).ObjectContext;

            // creating the query and fetching the data from the query.
            ObjectQuery<Employee> res = objctx.CreateQuery<Employee>(query); // returns as object query

            // printing the results
            foreach (var row in res.AsEnumerable())
            {
                Console.WriteLine($"ID={row.LastName}\tname={row.FirstName}");
            }

        }

        public static void NativeSQL()
        {
            // executing the raw SQL Queries
            string query = "select * from employees"; // writing our own sql query
            var results = db.Employees.SqlQuery(query); // returns the DBSqlQuery

            // iterate over each row
            foreach (var row in results)
            {
                Console.WriteLine(row.ID);
            }


        }

        public static void ExplicitLoading()
        {
            var employees = (from emp in db.Employees
                             where emp.ID == 10
                             select emp).FirstOrDefault();

            // applying the eager loading for the colleciton of employees
            var listofemp = from emp in db.Employees.Include("Department")
                            select emp;

            // setting the explicit loading for some entities or only one entity
            db.Entry(employees).Reference(s => s.Department).Load();

            foreach (var emp in listofemp)
            {
                Console.WriteLine($"Id={emp.ID}\tName={emp.FirstName}\tDept_name={emp.Department.Name}");
            }

            // Printing the results
            Console.WriteLine($"Id={employees.ID}\tName={employees.FirstName}\tDept_name={employees.Department.Name}");

        }
    }
}
