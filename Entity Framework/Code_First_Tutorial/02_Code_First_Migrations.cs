using System;
using System.Collections.Generic;
using System.Linq;


namespace Code_First_Tutorial
{
    class _02_Code_First_Migrations
    {
        public static void MigrationsCodeFirst()
        {
            ShoppingContext context = new ShoppingContext();
            var results = from prod in context.ShopProducts
                          select prod;

            context.Database.Log = Console.Write;
            foreach (var prod in results)
            {
                Console.WriteLine($"{prod.Id}\t{prod.Category}\t{prod.ProductName}\t{prod.ShopName}");
            }
            //InsertSomeData();
        }

        public static void InsertSomeData()
        {
            ShoppingContext context = new ShoppingContext();
            Sample samp = new Sample() { SampleId = 1 };
            Sample samp2 = new Sample() { SampleId = 2 };
            context.Samples.AddRange(new List<Sample> { samp, samp2 });
            context.SaveChanges();
        }
    }
}
