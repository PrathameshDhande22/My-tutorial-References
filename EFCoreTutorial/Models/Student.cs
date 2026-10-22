using EFCoreTutorial.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTutorial.Models
{
    // Creating the First Model
    // Applying the Configuration
    [EntityTypeConfiguration(typeof(StudentConfiguration))]
    [Index(nameof(Id), nameof(Age))]
    public class Student
    {
        // Creating the indexer property
        private readonly Dictionary<string, object> _data = new();
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public int Age { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string DisplayName { get; set; } = String.Empty;

        // Handling the concurrency
        [Timestamp]
        public byte[] Version { get; set; }

        public override string ToString()
        {
            return $"Student(Id={Id},FirstName={FirstName},LastName={LastName},Age={Age})";
        }

        // Configuring the indexer - creating the the object as an indexer
        public object this[string key]
        {
            get => _data[key];
            set => _data[key] = value;
        }

        // Navigational Properties
        public virtual ICollection<Address> Address { get; set; } = new List<Address>();
        public virtual StudentProfiles StudentProfile { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
