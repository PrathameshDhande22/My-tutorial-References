
namespace Tutorial
{
    class _17_DapperPractice
    {
        public static void PracticingDapper()
        {
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            DynamicParameters parammeters = new DynamicParameters();
            parammeters.Add("@Brand_Name", "Trek", DbType.String, ParameterDirection.Input);
            var res = conn.Query("spProductByBrand", parammeters, commandType: CommandType.StoredProcedure);
            foreach(var r in res)
            {
                Console.WriteLine(r);
            }

        }
    }
}
