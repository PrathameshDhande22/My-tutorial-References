

namespace Tutorial
{
    class _14_Buffered_NonBuffered
    {
        public static void NonBufferedQueries()
        {
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            // Buffered Approach
            Console.WriteLine("\nbuffered Approach");
            string query = "select * from sales.staffs";
            var Results = conn.Query(query);
            foreach (var Result in Results)
            {
                Console.WriteLine(Result);
            }


            // unbuffered Approach
            Console.WriteLine("\nUnbuffered Approach");
            var resultsnonbuff = conn.Query<Staffs>(query,buffered:false); // argument buffered set to false to set the unbuffered approach
            Console.WriteLine(resultsnonbuff);
            foreach(var Result in resultsnonbuff)
            {
                Console.WriteLine(Result.staff_id);
            }
        }
    }
}
