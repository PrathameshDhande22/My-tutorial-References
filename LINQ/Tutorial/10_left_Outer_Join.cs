

namespace Tutorial
{
    class _10_left_Outer_Join
    {
        public static void LeftOuterJoinLINQ()
        {
            List<Product> listproduct = new Data().GetProducts();
            List<Brand> listbrand = new Data().GetBrands();

            // left outer join using linq query
            var results = from brand in listbrand
                          join product in listproduct
                          on brand.brand_id equals product.brand_id into leftouter
                          from product in leftouter.DefaultIfEmpty()
                          select new { Product = product == null ? new Product() { product_id = 0, product_name = "No Product" } : product, Brand = brand };

            //printing results
            foreach (var res in results)
            {
                Console.WriteLine($"ID={res.Product.product_id}\tname={res.Product.product_name}\tcat_id={res.Brand.brand_id}\tCat_name={res.Brand.brand_name}");
            }
            Console.WriteLine();

            // using extension method
            var results2 = listbrand.GroupJoin(listproduct, b => b.brand_id, p => p.brand_id, (b, p) => new { p, b })
                            .SelectMany(res => res.p.DefaultIfEmpty(), (a, b) => new { Product = b == null ? new Product() { product_id = 0, product_name = "No Product" } : b, Brand = a.b });

            foreach (var res in results2)
            {
                Console.WriteLine($"ID={res.Product.product_id} | name={res.Product.product_name} | brand_name ={res.Brand.brand_name}");
                
            }
        }
    }
}
