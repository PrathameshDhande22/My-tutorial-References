
namespace Tutorial
{
   class _10_ExecuteScalar
    {
        public static void ExecuteScalarmethodofDapper()
        {
            // Execute Scalar method -> returns only one column of one row
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            // these returns the result of only one query
            var results = conn.Query("select * from sales.staffs; select * from sales.stores");
            Console.WriteLine(results);
            foreach(var res in results)
            {
                Console.WriteLine(res);
            }

            // Executing the scalar method
            var results2 = conn.ExecuteScalar("select * from sales.staffs where staff_id=2");
            Console.WriteLine(results2);  // returns only one column of one row

            // execuiting the scalar method with aggregation function
            var results3 = conn.ExecuteScalar("Select count(*) from sales.Staffs");
            Console.WriteLine(results3);  // as thesee query returns 

        }
    }
}
