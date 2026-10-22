using EFCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EFCoreTutorial.ModelConfiguration
{
    // Using the Grouping Configuration as the per table separate configuration
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        // Implement these method
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Each Property Configuration
            builder.Property(p => p.FirstName).HasMaxLength(40);
            builder.Property(p => p.LastName).HasMaxLength(40);
            builder.Property(p => p.Age).HasDefaultValue(0);

            // Configuring the computed column
            builder.Property(p => p.DisplayName)
                .HasComputedColumnSql("[FirstName] + [LastName]", stored: true);

            // Creating the shadow property
            builder.Property<DateTime>("CreatedAt");

            // Applying the Query filters at the global level
            builder.HasQueryFilter(st => st.Age > 10);

            // Configure the indexer Property
            //builder.IndexerProperty<String>("NickName").IsRequired(false).HasMaxLength(40);
            //builder.IndexerProperty<DateTime>("UpdatedAt");

        }
    }
}
