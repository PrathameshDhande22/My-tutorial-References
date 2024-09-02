
namespace Tutorial
{
    class _02_Querying_Custom_Objects
    {
        public static void QueryCustomObjects()
        {
            Data products = new Data();
            List<Product> listofproduct = products.GetProducts();

            Console.WriteLine("\ncustom iterating");
            foreach(Product pro in listofproduct)
            {
                Console.WriteLine($"Id={pro.product_id}, Name={pro.product_name}");
            }
            Console.WriteLine();

            // Querying the custom object -> applying the condition and ordering the queries
            // fetching the products for year 2017 and have price greater than 800
            var results = from prod in listofproduct where prod.model_year == 2017 && prod.list_price >800 select prod;
            var count = results.Count();
            var maxPrice = results.Max(pr=>pr.list_price);

            Console.WriteLine("Total products Fetched = {0}",count);
            Console.WriteLine("Max Priced Products = {0}",maxPrice);
            foreach (Product pro in results.ToList())
            {
                Console.WriteLine($"Id={pro.product_id}, Name={pro.product_name}, year={pro.model_year}, list_price={pro.list_price}");
            }
            listofproduct.Where(pr => pr.model_year == 2017);

        }
    }
}
