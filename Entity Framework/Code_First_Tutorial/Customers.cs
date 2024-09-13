using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Tutorial
{
    [Table("Visitor", Schema = "visit")]  // Specifiying the table name as Visitor and schema name as schema
    public class Customers
    {
        [Key] // Specifiying these property as the Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Specifying the database generated value as none which in turn will not insert the identity column.
        public int VisitorId { get; set; }
        [MaxLength(30)] // these will create the column with nvarchar(30)
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Specifying the column name as different and also changing the order of the column
        [Column("Stays", Order = 4)]
        public string Address { get; set; }
        public int PinCode { get; set; }

        [Required] // Setting the column as not null in the database while creating
        public int PhoneNumber { get; set; }

        [NotMapped] // EF will not map these Property.
        public int Count { get; set; }

        [ForeignKey("ShopProducts")] // Specifying the ForeignKey with its another name.
        public int ProductID { get; set; }

        // these contains the One to many relationship
        public ShopProducts ShopProducts { get; set; }

    }
}
