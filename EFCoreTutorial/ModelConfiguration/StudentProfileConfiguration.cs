using EFCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreTutorial.ModelConfiguration
{
    public class StudentProfileConfiguration : IEntityTypeConfiguration<StudentProfiles>
    {
        public void Configure(EntityTypeBuilder<StudentProfiles> builder)
        {
            // Index configuration using fluent api
            builder.HasIndex(profile => new { profile.StudentId, profile.Id })
                .HasDatabaseName("IX_StudentProfiles_ID_StudentId")
                .IsUnique();

            // Converting the Enum to string
            builder.Property(profile => profile.Gender)
                .HasConversion<string>();

            // Configure the one to one relationship
            builder.HasOne(prof => prof.Student)
                .WithOne(st => st.StudentProfile)
                .HasForeignKey<StudentProfiles>(stprof => stprof.StudentId)
                .IsRequired()
                .HasConstraintName("FK_StudentProfiles_Student_StudentId");
        }
    }
}
