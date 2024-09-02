

namespace Tutorial
{
    class _09_ExecuteReader
    {
        public static void ExecuteReaderMethodofDapper()
        {
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            // Execute reader
            string query1 = "Select * from sales.stores";
            var results = conn.ExecuteReader(query1);
            while (results.Read())
            {
                // reading the data
                Console.WriteLine($"{results["store_id"]} {results["store_name"]} {results["Phone"]}");
            }
            results.Dispose();

            // Executing the stored procedure
            string procedurestring = "spProductByBrand @brand_name";
            var results2= conn.ExecuteReader(procedurestring,new { brand_name="Electra"});
            while (results2.Read())
            {
                // reading the data
                Console.WriteLine($"{results2["product_id"]} {results2["product_name"]}");
            }
            results2.Dispose();

            // inserting the record using execute reader
            string insQuery1 = "insert into production.brands values ('adidas');";
            var resultsnew=conn.ExecuteReader(insQuery1);
            while (resultsnew.Read())
            {
                Console.WriteLine(resultsnew);
            }




        }
    }
}
