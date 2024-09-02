
namespace Tutorial
{
    class _05_Querying_Practice
    {
        public static void QueryingPractice()
        {
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            Console.WriteLine("connected to Database : {0}", conn.Database);

            // can we query a function - yes
            var resultunknown = conn.Query("Select top 5 * from getProductsByBrandName('Cruisers Bicycles')");
            foreach(var item in resultunknown)
            {
                Console.WriteLine(item);
            }

            // can we execute a stored procedure using query - yes
            var result2unknown = conn.Query("exec spProductByBrand 'Electra'");
            foreach (var item in result2unknown)
            {
                Console.WriteLine(item);
            }
            
            string connection2 = "Server=localhost;Database=sampleDB;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn2 = new SqlConnection(connection2);
            conn2.Open();

            // can we use insert statement in the query method -- yes
            var result3unknown = conn2.Query("insert into Student values (130,'chahar',3,34)");
            foreach(var item in result3unknown)
            {
                Console.WriteLine(item);
            }

            // these returns the result of only one query if we try to query multiple rows
            var results = conn.Query("select * from sales.staffs; select * from sales.stores");
            Console.WriteLine(results);
            foreach (var res in results)
            {
                Console.WriteLine(res);
            }
        }
    }
}
