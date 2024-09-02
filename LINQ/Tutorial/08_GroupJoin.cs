
namespace Tutorial
{
    class _08_GroupJoin
    {
        public static void GroupJoinLINQ()
        {
            List<Product> products = new Data().GetProducts().Take(70).ToList();
            List<Brand> brands = new Data().GetBrands().ToList();

            // using extension methods
            var results = brands.GroupJoin(products, b => b.brand_id, p => p.brand_id, (brand, product) =>
            { return new { Product = product.OrderByDescending(p => p.list_price), Brand = brand }; });

            // printing the results
            foreach (var res in results)
            {
                Console.WriteLine($"ID={res.Brand.brand_id}, Name={res.Brand.brand_name}");
                foreach (var brandProduct in res.Product)
                {
                    Console.WriteLine($"\tId={brandProduct.product_id}, Name={brandProduct.product_name}, Price={brandProduct.list_price}");

                }
                //Console.WriteLine(res);
            }
            Console.WriteLine();

            // using linq query
            var results2 = from brand in brands
                           join product in products
                           on brand.brand_id equals product.brand_id into newgroup
                           select new { Brand = brand, Product = newgroup };
            foreach (var res in results2)
            {

                Console.WriteLine($"ID={res.Brand.brand_id}, Name={res.Brand.brand_name}");
                foreach (var brandProduct in res.Product)
                {
                    Console.WriteLine($"\tId={brandProduct.product_id}, Name={brandProduct.product_name}, Price={brandProduct.list_price}");

                }
            }
            Console.WriteLine();

        }
    }
}

