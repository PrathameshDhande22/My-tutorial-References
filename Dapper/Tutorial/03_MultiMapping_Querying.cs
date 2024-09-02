
using System.Collections.Specialized;

namespace Tutorial
{

    class Store
    {
        public int Store_id { get; set; }
        public string Store_name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public List<Staffs> Staffs { get; set; }
    }

    class _03_MultiMapping_Querying
    {
        public static void MultiQuerying()
        {
            // creating the connection
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            Console.WriteLine("connected to Database : {0}", conn.Database);

            string joinquery = "select * from sales.stores as store join sales.staffs as staff on store.store_id=staff.store_id";

            // Multimapping mapping -> one to many relationship

            // storing all in the dictionary
            Dictionary<int, Store> stores = new Dictionary<int, Store>();

            var items = conn.Query<Store, Staffs, Store>(joinquery, (store, staffs) =>
            {
                Store tempstore;

                if (!stores.TryGetValue(store.Store_id, out tempstore))
                {
                    tempstore = store;
                    tempstore.Staffs = new List<Staffs>();
                    stores.Add(store.Store_id, tempstore);
                }
                tempstore.Staffs.Add(staffs);
                return tempstore;
            }, splitOn: "staff_id").Distinct();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Store_id} {item.Store_name}");
                foreach (Staffs staff in item.Staffs)
                {
                    Console.WriteLine($"{staff.staff_id} {staff.first_name}");
                }
                Console.WriteLine();
            }

            foreach (KeyValuePair<int, Store> pair in stores)
            {
                Console.WriteLine($"{pair.Key}=> {pair.Value.Store_id}, {pair.Value.Store_name} =>");
                Console.WriteLine("Staffs in Stores : ");
                foreach (Staffs staff in pair.Value.Staffs)
                {
                    Console.WriteLine($"{staff.staff_id},{staff.first_name},{staff.first_name},{staff.active},{staff.email}");
                }
                Console.WriteLine();
            }

            conn.Close();

        }
    }
}
