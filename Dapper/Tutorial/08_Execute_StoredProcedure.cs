

namespace Tutorial
{
    class _08_Execute_StoredProcedure
    {
        public static void ExecuteStoredProcedure()
        {
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            Console.WriteLine("connected to Database : {0}", conn.Database);

            // Executing the stored Procedure using execute method
            string storedProcedure1 = "exec spProductByBrand @brandname";
            int rowsAffected = conn.Execute(storedProcedure1, new { brandname = "Electra" });
            Console.WriteLine(rowsAffected);

            // another way just passed the procedure name but make sure the parameter name should be same as the declaration
            Console.WriteLine("\nUsing the Command type ");
            string storedprocedure2 = "spproductbybrand";
            int rowsAffected2 = conn.Execute(storedprocedure2, new { brand_name = "Electra" }, commandType: CommandType.StoredProcedure);
            Console.WriteLine(rowsAffected2);

            conn.Close();
        }
    }
}
