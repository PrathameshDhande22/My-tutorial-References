
namespace Code_First_Tutorial
{
    class _01_Code_First_Basics
    {
        public static void GettingStarted()
        {
            ShopProducts shopProducts = new ShopProducts() { Id = 1, ProductName = "Titan Watch XL30", Price = 1233, Quantity = 20, ShopName = "Watch sales and Enterprises" };
            ShopProducts shopProducts2 = new ShopProducts() { Id = 24, ProductName = "Timex Watch C3", Price = 677, Quantity = 2, ShopName = "Watch sales and Enterprises" };

            Customers cust1 = new Customers() { VisitorId = 3, Count = 2, Address = "vashi", FirstName = "Palak", LastName = "Paner", PhoneNumber = 1223344, PinCode = 401203, ProductID = 24 };

            ShoppingContext shoppingContext = new ShoppingContext();
            shoppingContext.Customers.Add(cust1);
            shoppingContext.ShopProducts.Add(shopProducts);
            shoppingContext.ShopProducts.Add(shopProducts2);
            shoppingContext.SaveChanges();

        }
    }
}
