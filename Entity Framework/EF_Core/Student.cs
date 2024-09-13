

using System.ComponentModel.DataAnnotations;

namespace EF_Core
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public Grade Grade { get; set; }

    }
}
