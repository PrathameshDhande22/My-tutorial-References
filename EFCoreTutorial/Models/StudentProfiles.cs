using EFCoreTutorial.ModelConfiguration;
using EFCoreTutorial.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EFCoreTutorial.Models
{
    [EntityTypeConfiguration(typeof(StudentProfileConfiguration))]
    public class StudentProfiles
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        [MaxLength(50)]
        public String FatherfirstName { get; set; } = string.Empty;
        [MaxLength(50)]
        public String FatherlastName { get; set; } = string.Empty;
        // Converting the Enum to json
        [Required]
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? BloodGroup { get; set; }

        // navigational properties
        public virtual Student Student { get; set; }

        public override string ToString()
        {
            return $"StudentProfile(Id={Id}, StudentId={StudentId}, " +
                   $"FatherfirstName={FatherfirstName}, " +
                   $"FatherlastName={FatherlastName}, Gender={Gender}, " +
                   $"DateOfBirth={DateOfBirth:yyyy-MM-dd}, BloodGroup={BloodGroup})";
        }
    }
}
