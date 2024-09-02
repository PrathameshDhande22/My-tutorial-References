
namespace Tutorial
{
    class _05_Projection_Operators
    {
        public static void ProjectionOperatorsINLINQ()
        {
            List<Product> products = new Data().GetProducts();

            Func<Product, Product> getCorrectProductName = (p) =>
            {
                p.product_name = p.product_name.Substring(0, p.product_name.LastIndexOf("-") - 1);
                return p;
            };


            // select method
            var results = from prod in products where prod.model_year == 2016 orderby prod.list_price descending select getCorrectProductName(prod);
            foreach (var res in results)
            {
                Console.WriteLine(res.product_name);
            }
            Console.WriteLine();

            // same using select many method
            var results2 = products.Where((p) => p.model_year == 2016).OrderByDescending(p => p.list_price);
            foreach (var res in results2)
            {
                Console.WriteLine(res.product_name);
            }

            // getting the product which price is higher in 2016
            var results3 = from prod in products
                           where prod.list_price == (from pr in products where pr.model_year == 2016 select pr.list_price).Max() select prod;
            foreach(var pro in results3)
            {
                Console.WriteLine($"Id={pro.product_id}, Name={pro.product_name}, year={pro.model_year}, list_price={pro.list_price}");
            }
            Console.WriteLine();
            foreach(Product pro in products)
            {
                Console.WriteLine($"Id={pro.product_id}, Name={pro.product_name}, year={pro.model_year}, list_price={pro.list_price}");
            }
            Console.WriteLine();

            // multi ordering
            var results4 = from pr in products orderby pr.list_price,pr.model_year descending,pr.product_name select pr;
            foreach (Product pro in results4)
            {
                Console.WriteLine($"Id={pro.product_id}, Name={pro.product_name}, year={pro.model_year}, list_price={pro.list_price}");
            }

        }
    }
}
