

namespace Tutorial
{
     class _01_Connection
    {
        public static void ConnectionString()
        {
            // String connection to connect with the SQL Server Database
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";

            // creating the connection
            SqlConnection conn = new SqlConnection(connection);

            // Open the Connection
            conn.Open();
            Console.WriteLine("connected to Database : {0}", conn.Database);

            // running the query
            string query = "select * from sales.staffs";

            // executing the query -> Execute method returns the number of rows affected
            int rowsaffected = conn.Execute(query);


            Console.WriteLine(rowsaffected);
        }
    }
}
