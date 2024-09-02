
namespace Tutorial
{
    class _13_Async_Methods
    {
        public async static Task AsyncMethodsofDapper()
        {
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            // calling the async methods of dapper
            string query1 = "select * from sales.stores";
            IEnumerable<Store> stores = await conn.QueryAsync<Store>(query1);
            Console.WriteLine("Executing others");
            foreach (Store store in stores)
            {
                Console.WriteLine($"{store.Store_id} {store.Store_name} {store.Email}");
            }
            


        }
    }
}
