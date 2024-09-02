
namespace Tutorial
{
    public class Product
    {
        public int product_id { get; set; }
        public string product_name { get; set; } = String.Empty;
        public int brand_id { get; set; }
        public int category_id { get; set; }
        public short model_year { get; set; }
        public decimal list_price { get; set; }
    }

    public class Brand
    {
        public int brand_id { get; set; }
        public string brand_name { get; set; } = String.Empty;
    }
    public class Category
    {
        public int category_id { get; set; }
        public string category_name { get; set; } = String.Empty;
    }

    public class Employee
    {
        public int id { get; set; }
        public string fullname { get; set; } = String.Empty;
        public int managerId { get; set; }
        public DateTime Dateofjoining { get; set; }
        public string city { get; set; } = String.Empty;
    }



    class Data
    {
        public SqlConnection GetConnection()
        {
            string connection = "Server=localhost;Database=tutorial;Trusted_Connection = true; TrustServerCertificate = True;Data Source = SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            return conn;
        }

        public List<Product> GetProducts()
        {
            return this.GetConnection().Query<Product>("Select top 100 * from production.products").ToList();
        }

        public List<Brand> GetBrands()
        {
            return this.GetConnection().Query<Brand>("Select * from production.brands").ToList();
        }

        public List<Category> GetCategories()
        {
            return this.GetConnection().Query<Category>("Select * from production.categories").ToList();
        }

        public List<Employee> GetEmployees()
        {
            return this.GetConnection().Query<Employee>("Select * from employee").ToList();
        }


    }
}
