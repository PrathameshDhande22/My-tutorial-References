

namespace Tutorial
{
    class _04_AggregateFunctions
    {
        public static void AggregateFunctionsinLINQ()
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Simple max function
            Console.WriteLine(numbers.Max());

            // Selecting max where nos are odd
            Console.WriteLine(numbers.Where(no => no % 2 == 1).Max());

            // average of all the numbers
            Console.WriteLine(numbers.Average());

            // Aggregate function 
            Console.WriteLine(numbers.Aggregate((a, b) => a + b));
            // Aggregate function with seed
            Console.WriteLine(numbers.Aggregate(100, (a, b) => a + b));

            // ordering the data by descending order
            Data prods= new Data();
            List<Product> products = prods.GetProducts();
            var results = from prod in products where prod.model_year == 2017 orderby prod.list_price descending select prod;

            // selecting only first 5 rows
            var res=results.ToList()[1..10];
            foreach(var pro in res)
            {
                Console.WriteLine($"Id={pro.product_id}, Name={pro.product_name}, year={pro.model_year}, list_price={pro.list_price}");
            }

        }
    }
}
