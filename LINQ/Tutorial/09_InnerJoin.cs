

namespace Tutorial
{
    class _09_InnerJoin
    {
        public static void InnerJoininLINQ()
        {
            List<Product> listproducts = new Data().GetProducts().Take(70).ToList();
            List<Category> listCategory = new Data().GetCategories().ToList();

            // Inner join using JOIN Extension method
            var results = listproducts.Join(listCategory, p => p.category_id, c => c.category_id, (p, c) => new { Product = p, Category = c }).OrderBy((a) => a.Category.category_name);

            // printing the results
            foreach (var res in results)
            {
                Console.WriteLine($"ID={res.Product.product_id}\tname={res.Product.product_name}\tcat_id={res.Category.category_id}\tCat_name={res.Category.category_name}");
            }
            Console.WriteLine();

            // Inner join using Query
            var results2 = (from product in listproducts
                            join category in listCategory
                            on product.category_id equals category.category_id
                            select new { Product = product, Category = category }).OrderBy(a => a.Category.category_name);
            // printing the results
            foreach (var res in results2)
            {
                Console.WriteLine($"ID={res.Product.product_id}\tname={res.Product.product_name}\tcat_id={res.Category.category_id}\tCat_name={res.Category.category_name}");
            }


        }
    }
}
