

namespace Tutorial
{
    class _16_BulkInsert
    {
        public static void InsertinBulkinSQL()
        {
            string connection = "Server=localhost;Database=sampleDB;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            // SQLBulkCopy copies the data source from other form can be datatable or datarow to SqL Server tables

            // creating the datatable based on the table of Employee
            DataTable employeeDatatable = new DataTable("Employee");

            // adding the columns
            employeeDatatable.Columns.AddRange(new[] { new DataColumn("Id"), new DataColumn("name"), new DataColumn("Gender"), new DataColumn("Salary"), new DataColumn("DepartmentId") });

            // adding the rows
            employeeDatatable.Rows.Add(9, "John", "Male", 23000, 2);
            employeeDatatable.Rows.Add(10, "Barry", "Male", 34000, 3);
            employeeDatatable.Rows.Add(11, "Emily", "Female", 3000, 4);

            SqlBulkCopy sqlbulkCopy = new SqlBulkCopy(conn); // creating the instance of SQLBulkCopy by passing the connection in the constructor.

            // Specifying the destination table name
            sqlbulkCopy.DestinationTableName = "Employee";

            // Mappings the column
            sqlbulkCopy.ColumnMappings.Add("Id","Id");
            sqlbulkCopy.ColumnMappings.Add("Name", "Name");
            sqlbulkCopy.ColumnMappings.Add("Gender", "Gender");
            sqlbulkCopy.ColumnMappings.Add("Salary", "Salary");
            sqlbulkCopy.ColumnMappings.Add("DepartmentId", "DepartmentId");

            // Adding the datatable in the sqlbulk copy
            sqlbulkCopy.WriteToServer(employeeDatatable);

            Console.WriteLine("Successfully Bulk Inserted");
        }
    }
}
