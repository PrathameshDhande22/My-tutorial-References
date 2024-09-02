

namespace Tutorial
{
    class _07_GroupBy_Operator
    {
        public static void GroupByOperator()
        {
            // Grouping by single key
            List<Product> products = new Data().GetProducts().Take(30).ToList();

            // Using Query
            var results = from prod in products
                          group prod by prod.model_year;

            foreach (var pro in results)
            {
                Console.WriteLine("{0} - {1}", pro.Key, pro.Count());
            }
            Console.WriteLine();

            // Using Extension method
            var results2 = products.GroupBy(p => p.model_year);
            foreach (var pro in results2)
            {
                Console.WriteLine("{0} - {1}", pro.Key, pro.Count());
            }
            Console.WriteLine();

            // using group by with orderby
            var results3 = from prod in products
                           group prod by prod.model_year into modelyear
                           orderby modelyear.Key descending
                           select modelyear;
            foreach (var pro in results3)
            {
                Console.WriteLine("{0} - {1}", pro.Key, pro.Count());
                Console.WriteLine("--------------------");
                foreach (Product pr in pro)
                {
                    Console.WriteLine($"Id={pr.product_id}, Name={pr.product_name}, year={pr.model_year}, list_price={pr.list_price}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // using group by to get all the details with it
            var results4 = from prod in products
                           group prod by prod.brand_id into brandid
                           orderby brandid.Key ascending
                           select new { BrandID = brandid.Key, Prods = brandid.OrderBy(pr => pr.list_price) };
            foreach (var pros in results4)
            {
                Console.WriteLine("BrandID={0} - Count={1}", pros.BrandID, pros.Prods.Count());
                Console.WriteLine("----------------");
                foreach (Product pro in pros.Prods)
                {
                    Console.WriteLine($"Id={pro.product_id}, Name={pro.product_name}, year={pro.model_year}, list_price={pro.list_price}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Grouping by multiple keys using query
            var results5 = from prod in products
                           group prod by new {  prod.brand_id, prod.model_year } into brandYearGroup
                           orderby brandYearGroup.Key.model_year descending, brandYearGroup.Key.brand_id ascending,brandYearGroup
                           select new { Year = brandYearGroup.Key.model_year, BrandId = brandYearGroup.Key.brand_id, Prods = brandYearGroup.OrderByDescending(pr=>pr.list_price) };
            foreach(var pros in results5)
            {
                Console.WriteLine("{0} Year \t{1} BrandID\tCount={2}",pros.Year,pros.BrandId,pros.Prods.Count());
                Console.WriteLine("-------------------------");
                foreach(Product pro in pros.Prods)
                {
                    Console.WriteLine($"Id={pro.product_id}, Name={pro.product_name}, year={pro.model_year}, list_price={pro.list_price}");
                }
                Console.WriteLine();
            }




        }
    }
}
