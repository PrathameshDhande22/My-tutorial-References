using EFCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTutorial
{
    internal class _08_LoadingData : Runner
    {
        public async Task RunAsync()
        {
            var context = new ApplicationDbContext();

            // Eager loading - Loading using Include
            var students = context.Students
                            .Where(st => st.Age >= 23)
                            .Include(st => st.Address)
                            .Include(st => st.StudentProfile)
                            .ToList();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student}\n\n{student.StudentProfile}");
                Console.WriteLine("Courses\n");
                foreach(Course course in student.Courses)
                {
                    Console.WriteLine(course);
                }
                Console.WriteLine("\nAddress\n");
                foreach(Address address in student.Address)
                {
                    Console.WriteLine(address);
                }
            }
        }
    }
}
