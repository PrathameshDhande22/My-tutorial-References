using EFCoreTutorial.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EFCoreTutorial.Models
{
    [EntityTypeConfiguration(typeof(CourseConfiguration))]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigational Properties
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            return $"Course(Id={Id}, Name={Name})";
        }
    }
}
