using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Tutorial
{
    class _03_Code_First_Stored_procedure
    {
        public static void CAllStoredprocedure()
        {
            ShoppingContext context = new ShoppingContext();
            foreach(var res in context.sp_GetProducts())
            {
                Console.WriteLine(res.ProductName);
            }
        }
    }
}
