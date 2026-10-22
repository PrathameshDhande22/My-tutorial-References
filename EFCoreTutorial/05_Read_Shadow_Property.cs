using EFCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial
{
    internal class _05_Read_Shadow_Property : Runner
    {
        public async Task RunAsync()
        {
            // Initialize the context object
            var context = new ApplicationDbContext();

            // Read the data from the students along with Shadow Property
            var students = context.Students.Select(st => new
            {
                Id = st.Id,
                DisplayName = st.DisplayName,
                StudentObj = st,
                CreatedAt = EF.Property<DateTime>(st, "CreatedAt")
            }).ToList();

            foreach (var stud in students)
            {
                Console.WriteLine(stud);
                // Reading the indexer property
                Console.WriteLine("Indexer Property Reading");
                Console.WriteLine(stud.StudentObj["UpdatedAt"]);
            }
        }
    }
}
