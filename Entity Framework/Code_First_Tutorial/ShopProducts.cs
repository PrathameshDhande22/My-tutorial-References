using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Tutorial
{
    public class ShopProducts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Specifying the database generated value as none which in turn will not insert the identity column.
        public int Id { get; set; }
        //[Index] // Specifying these property as a unique index.
        public string ShopName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        // These contains one to many relationship
        public ICollection<Customers> Customers { get; set; }
    }
}
