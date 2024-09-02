

namespace Tutorial
{
    class _11_Cross_Join
    {
        public static void CrossJOINLINQ()
        {
            List<Product> listproduct = new Data().GetProducts().Take(5).ToList();
            List<Brand> listbrand=new Data().GetBrands().Take(2).ToList();

            // Cross join should produce 5*2=10 items with joining brand name to every product available in the list.

            // cross join using LINQ Query
            var results = from brand in listbrand
                          from product in listproduct
                          select new { brand, product };
            // printing the results
            foreach(var res in results)
            {
                Console.WriteLine($"{res.brand.brand_name} \t{res.product.product_name}");
            }
            Console.WriteLine();

            // using extension method
            var results2 = listbrand.SelectMany(b => listproduct, (brand, listprod) => new { brand, listprod });
            foreach (var res in results2)
            {
                Console.WriteLine($"{res.brand.brand_name} \t{res.listprod.product_name}");
            }

        }
    }
}
