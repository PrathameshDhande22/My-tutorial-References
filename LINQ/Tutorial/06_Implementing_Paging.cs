

namespace Tutorial
{
    class _06_Implementing_Paging
    {
        public static void PagingINLInq()
        {
            List<Product> products = new Data().GetProducts();

            int pageno = 2;
            int pageSize = 5;

            // skip method as the name says it skips the no of rows and take method just like the fetch first or next sql query it will fetch givennoofrows.
            var results = products.Skip(pageno * 5).Take(pageSize);
            foreach (Product pro in results)
            {
                Console.WriteLine($"Id={pro.product_id}, Name={pro.product_name}, year={pro.model_year}, list_price={pro.list_price}");
            }
        }
    }
}
