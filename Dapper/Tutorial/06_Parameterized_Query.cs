

namespace Tutorial
{
    class _06_Parameterized_Query
    {
        public static void ParameterizedQuery()
        {
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            Console.WriteLine("connected to Database : {0}", conn.Database);
            
            // to send the query as the parameter here the variable is declared using @staff_id same should be passed in param arguments of the all Query methods both the variable named should be matched
            var results = conn.QuerySingle<Staffs>("select * from sales.staffs where staff_id=@staff_id", param:new{ staff_id=2});
            Console.WriteLine($"{results.first_name} {results.last_name} {results.email}");

            // to send the string query
            var results2 = conn.QuerySingle<Staffs>("Select * from sales.staffs where first_name=@staff_name", new { staff_name = "Virgie" });
            Console.WriteLine($"{results2.first_name} {results2.last_name} {results2.email}");
        }
    }
}
