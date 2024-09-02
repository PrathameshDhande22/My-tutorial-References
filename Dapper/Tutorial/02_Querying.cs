
using Dapper;
namespace Tutorial
{

    // creating the class to get rid of the dynamic object result
    class Staffs
    {
        // creating the properties to map the result from the database to class
        public int staff_id { get; set; } = 00;
        public string first_name { get; set; } = "notname";
        public string last_name { get; set; } = "notname";
        public string email { get; set; } = "not@email.com";
        //public string Phone { get; set; }
        public int active { get; set; } = 10;
        public int store_id { get; set; } = 0;
        public int manager_id { get; set; } = 0;
    }

    // Mapping one to one relationship
    file class Store
    {
        public int Store_id { get; set; }
        public string Store_name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }

    file class StaffStore
    {
        public Store store { get; set; }
        public Staffs staffs { get; set; }
    }


    class _02_Querying
    {
        public static void Querying()
        {
            // creating the connection
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            Console.WriteLine("connected to Database : {0}", conn.Database);

            string query = "select * from sales.staffs";

            // Querying it returns the dynamic type of the result
            foreach (var item in conn.Query(query).ToList())
            {
                Console.WriteLine(item);
            }

            // querying with the Strongly Typed results
            foreach (var items in conn.Query<Staffs>(query))
            {
                // returns the ienumerable result of the staffs class
                Console.WriteLine(items.staff_id + " " + items.first_name + " " + items.last_name + " " + items.store_id + " " + items.active);
            }

            // query with join query
            string joinquery = "select * from sales.staffs as staff join sales.stores as store on staff.store_id=store.store_id";

            var storesandstaffs = conn.Query<Staffs, Store, StaffStore>(joinquery, (staff, store) =>
            {
                StaffStore stst = new StaffStore();
                stst.staffs = staff;
                stst.store = store;
                return stst;
            }, splitOn: "store_id");

            foreach (var stst in storesandstaffs)
            {
                Console.WriteLine($" Staff => {stst.staffs.staff_id} {stst.staffs.first_name} {stst.staffs.last_name}\nStore=>{stst.store.Store_id} {stst.store.Store_name}\n");
            }

            
        }
    }
}
