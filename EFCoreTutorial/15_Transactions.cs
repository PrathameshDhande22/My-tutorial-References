using EFCoreTutorial.Models;
using EFCoreTutorial.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EFCoreTutorial
{
    internal class _15_Transactions : Runner
    {
        public async Task RunAsync()
        {
            // Initialize the transaction
            var context = new ApplicationDbContext();

            // Initiating the Transactions
            using var transaction =await context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
            {

                // Creating the student
                Student student = new Student()
                {
                    Age = 10,
                    FirstName = "Samridh",
                    LastName = "Kulkarni",
                    Courses = [new Course() { Name = "Java" }],
                    StudentProfile = new StudentProfiles()
                    {
                        BloodGroup = "AB+",
                        DateOfBirth = new DateTime(2003, 04, 22),
                        FatherfirstName = "FA",
                        FatherlastName = "FLA",
                        Gender = Gender.Other
                    }

                };

                context.Students.Add(student);

                context.SaveChanges();

                // Commit the transaction
                transaction.Commit();
            }
        }
    }
}