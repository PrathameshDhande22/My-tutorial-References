

namespace Tutorial
{
    class _11_Parameters
    {
        public static void ParametersTypesinDapper()
        {
            string connection = "Server=localhost;Database=BikeStores;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            /* Anonymous Types */
            string query1 = "select * from sales.stores where store_id=@storeid"; // declaring the parameter using @variable name.
            var results = conn.Query(query1, new { storeid = 2 }); // passing the parameter value using new keyword and in {} brackets
            foreach (var res in results)
            {
                Console.WriteLine(res);
            }

            // with many parameter
            string query2 = "insert into production.brands values (@brand_name)";
            var results2 = conn.Execute(query2, new[] // creating the parameter array to pass many parameter
            {
                            new{brand_name="Asus"},// passing the same which we used previously to pass single value.
                            new{brand_name="Nike"}
                        });
            Console.WriteLine(results2);

            /* dynamic Parameter */
            // usage with single dynamic parameter
            DynamicParameters parameters = new DynamicParameters();
            // adding the parameters to it
            parameters.Add("@storeid", 2, dbType: DbType.Int32, direction: ParameterDirection.Input);

            // passing the parameter to the query method
            var results3 = conn.QuerySingle(query1, parameters);
            Console.WriteLine(results2);

            // getting the value from the dynamic parameters
            Console.WriteLine(parameters.Get<int>("@storeid"));

            /* List type */
            // getting the staff of id with 1,2,3
            string query3 = "select * from sales.staffs where staff_id in @ids"; // declaring the in clause with ids parameter
            var results4 = conn.Query(query3, new { ids = new[] { 1, 2, 3 } });
            foreach (var res in results3)
            {
                Console.WriteLine(res);
            }

            /* String Type */
            string query4 = "select * from sales.staffs where first_name=@name";

            // creating the dbstring class instance
            Console.WriteLine("\nUsing Dbstring");
            DbString nameparam = new DbString() { Value = "Kali", Length = 50, IsAnsi = false }; // treats as varchar
            DynamicParameters params4 = new DynamicParameters();
            params4.Add("@name", nameparam, dbType: DbType.String, direction: ParameterDirection.Input);
            var results5 = conn.QuerySingle(query4, params4);
            Console.WriteLine(results4);

            /* Table Valued parameter */

            string connection2 = "Server=localhost;Database=sampleDB;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn2 = new SqlConnection(connection2);
            conn2.Open();

            // creating the datatable based on the matching columns as defined in type.
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new[] { new DataColumn("id", typeof(int)), new DataColumn("name"), new DataColumn("branchid"), new DataColumn("age") });
            dt.Rows.Add(217, "Gravers", 6, 23);
            dt.Rows.Add(498, "Saviour", 3, 27);
            dt.Rows.Add(812, "nothing", 4, null); // one row with null values


            var tableValued = dt.AsTableValuedParameter("StudentTableType"); // converting the datatable to tablevaluedParameter and passing the table type name

            var results6 = conn2.Execute("spAddMoreStudent", new { studentTableType = tableValued }, commandType: CommandType.StoredProcedure);

            Console.WriteLine("\nRows added using TVP = {0}", results5);

        }
    }
}
