

namespace Tutorial
{
    class _12_StoredProcedure_Outputparameter
    {
        public static void ExecuteStoredProcedureWithOutput()
        {
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            // Executing the stored procedure which has the output parameter
            DynamicParameters param = new DynamicParameters();
            param.Add("@cityname", "Sacramento", DbType.String, direction: ParameterDirection.Input); // adding the input parameter the variable must be same as the stored procedure has in the declaration
            param.Add("@totalcustomers", dbType: DbType.Int32, direction: ParameterDirection.Output); // declaration of output parameter

            // execute the stored procedure
            var results = conn.Execute("spGetTotalCustomersFromCity",param, commandType: CommandType.StoredProcedure);
            Console.WriteLine(results);
            // getting the value of the output parameter
            Console.WriteLine("Total Customers : {0}",param.Get<int>("@totalcustomers"));



            /*            // Executing the stored procedure which has error
                        var errorres = conn.Execute("getError", commandType: CommandType.StoredProcedure);
                        Console.WriteLine(errorres); // Throws error*/

        }
    }
}
