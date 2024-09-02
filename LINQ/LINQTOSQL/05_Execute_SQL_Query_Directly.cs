using System;

namespace LINQTOSQL
{
    class _05_Execute_SQL_Query_Directly
    {
        public static void ExecuteQueryDirectly()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            int rowsAffected = dc.ExecuteCommand("select * from student");
            Console.WriteLine("rows Affected={0}", rowsAffected);

            // you can also directly call the queries but make sure to infer the return type of the results
            var res = dc.ExecuteQuery<Student>("select * from student");
            foreach (var row in res)
            {
                Console.WriteLine(row.name + " " + row.school);
            }
            Console.WriteLine();

            // execteing the queries by passing the parameters in the SQL Query
            var res2 = dc.ExecuteQuery<Student>("select * from student where rollno in ({0},{1},{2})", 5,10,2);
            foreach (var row in res2)
            {
                Console.WriteLine(row.name + " " + row.school);
            }

            // Executing some command
            int rowsaffect = dc.ExecuteCommand("Delete from student where rollno in ({0},{1},{2})", 5, 10, 2);
            Console.WriteLine("Rows Affected : {0}",rowsaffect);
        }
    }
}
