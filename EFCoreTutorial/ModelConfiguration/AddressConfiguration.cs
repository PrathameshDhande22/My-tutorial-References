using EFCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreTutorial.ModelConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Configuring the Relationship
            builder.HasOne(a => a.Student)
                .WithMany(st => st.Address)
                .HasForeignKey(a => a.StudentId)
                .HasConstraintName("FK_Address_Student_StudentId");
        }
    }
}
