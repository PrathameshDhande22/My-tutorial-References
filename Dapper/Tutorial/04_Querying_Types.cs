

namespace Tutorial
{
    class _04_Querying_Types
    {
        public static void QueryingTypes()
        {
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            Console.WriteLine("connected to Database : {0}", conn.Database);

            // Query First method
            string joinquery = "select * from sales.staffs";

            // query first method using dynamic
            var dynamicresult = conn.QueryFirst(joinquery);
            Console.WriteLine(dynamicresult);


            // using strongly types result
            var stronglyresult = conn.QueryFirst<Staffs>(joinquery);
            // returns only first result
            Console.WriteLine($"staff_id={stronglyresult.staff_id}, first_name={stronglyresult.first_name}\n");


            // Query First or Default method
            var type2resultdynamic = conn.QueryFirstOrDefault<Staffs>(joinquery);
            Console.WriteLine($"staff_id={type2resultdynamic.staff_id}, first_name={type2resultdynamic.first_name}\n");

            // query single
            var type3resultdynamic = conn.QuerySingle<int>("select count(*) from sales.staffs");
            Console.WriteLine(type3resultdynamic);

            // query single or default
            var type4resultdynamic = conn.QuerySingleOrDefault("select * from sales.staffs where staff_id=11");
            if (type4resultdynamic == null)
            {
                Console.WriteLine("these is null");
            }
            

            // query multiple
            var type5resultdynamic = conn.QueryMultiple("select * from sales.staffs where staff_id=11; select * from production.brands where brand_id in (1,2,3)");
            foreach (var t in type5resultdynamic.Read()) // read() method reads the next grid result from the result obtained
            {
                Console.WriteLine(t);
            }
            foreach (var t1 in type5resultdynamic.Read())
            {
                Console.WriteLine(t1);
            }




        }
    }
}
