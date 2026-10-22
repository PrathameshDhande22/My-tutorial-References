using EFCoreTutorial.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTutorial.Models
{
    // Data Annotations Configuration
    [Table(name: "Addresses")]  // Specifying the Table name
    [Comment("Address of the table")]
    [EntityTypeConfiguration(typeof(AddressConfiguration))]
    public class Address
    {
        [Key]
        [Column(name: "AddressId", Order = 1)]  // Specifying the Table Name
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string StreetAddress1 { get; set; } = string.Empty;
        [Required]
        public string PinCode { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = string.Empty;
        public int StudentId { get; set; }

        // RelationShip
        public virtual Student Student { get; set; }

        public override string ToString()
        {
            return $"Address(Id={Id}, Name={Name}, " +
                   $"StreetAddress1={StreetAddress1}, PinCode={PinCode}, " +
                   $"City={City}, State={State}, StudentId={StudentId})";
        }
    }
}
