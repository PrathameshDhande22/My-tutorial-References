using EFCoreTutorial.Models;
using EFCoreTutorial.Models.Enums;

public static class StudentSeedData
{
    public static List<Course> Courses => new()
    {
        new() { Name = "C#" },
        new() { Name = "Entity Framework Core" },
        new() { Name = "ASP.NET Core" },
        new() { Name = "SQL Server" }
    };

    public static List<Student> Students
    {
        get
        {
            var courses = Courses;

            return new List<Student>
            {
                new()
                {
                    FirstName = "Rahul", LastName = "Sharma", Age = 21,
                    Courses = new List<Course> { courses[0], courses[1] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Rajesh", FatherlastName = "Sharma",
                        Gender = Gender.Male, DateOfBirth = new DateTime(2005, 1, 15),
                        BloodGroup = "O+"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "12 MG Road", PinCode = "400001", City = "Mumbai", State = "Maharashtra" },
                        new() { Name = "Hostel", StreetAddress1 = "Room 204, College Hostel", PinCode = "400076", City = "Mumbai", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Priya", LastName = "Patil", Age = 22,
                    Courses = new List<Course> { courses[0], courses[2] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Suresh", FatherlastName = "Patil",
                        Gender = Gender.Female, DateOfBirth = new DateTime(2004, 3, 20),
                        BloodGroup = "A+"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "24 Station Road", PinCode = "410206", City = "Panvel", State = "Maharashtra" },
                        new() { Name = "Office", StreetAddress1 = "Building 5, IT Park", PinCode = "400705", City = "Navi Mumbai", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Amit", LastName = "Deshmukh", Age = 20,
                    Courses = new List<Course> { courses[1], courses[3] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Vijay", FatherlastName = "Deshmukh",
                        Gender = Gender.Male, DateOfBirth = new DateTime(2006, 5, 10),
                        BloodGroup = "B+"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "8 Shivaji Nagar", PinCode = "411005", City = "Pune", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Sneha", LastName = "Kulkarni", Age = 21,
                    Courses = new List<Course> { courses[0], courses[1], courses[2] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Anil", FatherlastName = "Kulkarni",
                        Gender = Gender.Female, DateOfBirth = new DateTime(2005, 7, 12),
                        BloodGroup = "AB+"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "17 FC Road", PinCode = "411004", City = "Pune", State = "Maharashtra" },
                        new() { Name = "Hostel", StreetAddress1 = "Room 12, Student Hostel", PinCode = "411007", City = "Pune", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Vikas", LastName = "Jadhav", Age = 23,
                    Courses = new List<Course> { courses[2], courses[3] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Prakash", FatherlastName = "Jadhav",
                        Gender = Gender.Male, DateOfBirth = new DateTime(2003, 2, 8),
                        BloodGroup = "O-"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "9 College Road", PinCode = "422005", City = "Nashik", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Neha", LastName = "Shinde", Age = 22,
                    Courses = new List<Course> { courses[0], courses[3] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Mahesh", FatherlastName = "Shinde",
                        Gender = Gender.Female, DateOfBirth = new DateTime(2004, 4, 18),
                        BloodGroup = "A-"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "31 Main Road", PinCode = "416002", City = "Kolhapur", State = "Maharashtra" },
                        new() { Name = "Rental", StreetAddress1 = "Flat 3, Market Lane", PinCode = "400703", City = "Navi Mumbai", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Rohan", LastName = "More", Age = 20,
                    Courses = new List<Course> { courses[1], courses[2] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Dilip", FatherlastName = "More",
                        Gender = Gender.Male, DateOfBirth = new DateTime(2006, 6, 5),
                        BloodGroup = "B-"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "45 Market Street", PinCode = "402107", City = "Alibag", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Pooja", LastName = "Desai", Age = 21,
                    Courses = new List<Course> { courses[0], courses[1], courses[3] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Nitin", FatherlastName = "Desai",
                        Gender = Gender.Female, DateOfBirth = new DateTime(2005, 8, 22),
                        BloodGroup = "AB-"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "6 Temple Road", PinCode = "416416", City = "Sangli", State = "Maharashtra" },
                        new() { Name = "Hostel", StreetAddress1 = "Room 18, Campus Hostel", PinCode = "411008", City = "Pune", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Akash", LastName = "Pawar", Age = 22,
                    Courses = new List<Course> { courses[2], courses[3] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Ganesh", FatherlastName = "Pawar",
                        Gender = Gender.Male, DateOfBirth = new DateTime(2004, 9, 11),
                        BloodGroup = "O+"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "20 Bus Stand Road", PinCode = "413001", City = "Solapur", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Ananya", LastName = "Joshi", Age = 20,
                    Courses = new List<Course> { courses[0], courses[2] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Manoj", FatherlastName = "Joshi",
                        Gender = Gender.Female, DateOfBirth = new DateTime(2006, 11, 2),
                        BloodGroup = "A+"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "15 Garden Road", PinCode = "440010", City = "Nagpur", State = "Maharashtra" },
                        new() { Name = "Rental", StreetAddress1 = "Flat 5, Central Avenue", PinCode = "440012", City = "Nagpur", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Kunal", LastName = "Chavan", Age = 23,
                    Courses = new List<Course> { courses[1], courses[3] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Ramesh", FatherlastName = "Chavan",
                        Gender = Gender.Male, DateOfBirth = new DateTime(2003, 12, 9),
                        BloodGroup = "B+"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "11 River Road", PinCode = "415001", City = "Satara", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Isha", LastName = "Bhosale", Age = 21,
                    Courses = new List<Course> { courses[0], courses[1], courses[2] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Sanjay", FatherlastName = "Bhosale",
                        Gender = Gender.Female, DateOfBirth = new DateTime(2005, 10, 14),
                        BloodGroup = "AB+"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "28 Station Road", PinCode = "431001", City = "Chhatrapati Sambhajinagar", State = "Maharashtra" },
                        new() { Name = "Hostel", StreetAddress1 = "Room 7, College Hostel", PinCode = "411009", City = "Pune", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Sahil", LastName = "Kadam", Age = 22,
                    Courses = new List<Course> { courses[2], courses[3] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Vasant", FatherlastName = "Kadam",
                        Gender = Gender.Male, DateOfBirth = new DateTime(2004, 2, 17),
                        BloodGroup = "O-"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "33 Beach Road", PinCode = "400706", City = "Navi Mumbai", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Meera", LastName = "Naik", Age = 20,
                    Courses = new List<Course> { courses[0], courses[3] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Ashok", FatherlastName = "Naik",
                        Gender = Gender.Female, DateOfBirth = new DateTime(2006, 3, 25),
                        BloodGroup = "A-"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "14 Hill Road", PinCode = "415612", City = "Ratnagiri", State = "Maharashtra" },
                        new() { Name = "Rental", StreetAddress1 = "Flat 2, Station Lane", PinCode = "400708", City = "Navi Mumbai", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Omkar", LastName = "Salunkhe", Age = 21,
                    Courses = new List<Course> { courses[1], courses[2] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Dattatray", FatherlastName = "Salunkhe",
                        Gender = Gender.Male, DateOfBirth = new DateTime(2005, 4, 6),
                        BloodGroup = "B-"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "19 Market Road", PinCode = "431401", City = "Parbhani", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Rutuja", LastName = "Mane", Age = 22,
                    Courses = new List<Course> { courses[0], courses[1], courses[3] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Pravin", FatherlastName = "Mane",
                        Gender = Gender.Female, DateOfBirth = new DateTime(2004, 7, 19),
                        BloodGroup = "AB-"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "7 Lake View Road", PinCode = "416003", City = "Kolhapur", State = "Maharashtra" },
                        new() { Name = "Hostel", StreetAddress1 = "Room 31, University Hostel", PinCode = "411010", City = "Pune", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Aditya", LastName = "Gore", Age = 20,
                    Courses = new List<Course> { courses[2], courses[3] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Ravindra", FatherlastName = "Gore",
                        Gender = Gender.Male, DateOfBirth = new DateTime(2006, 8, 13),
                        BloodGroup = "O+"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "22 Main Street", PinCode = "422001", City = "Nashik", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Kavya", LastName = "Rane", Age = 21,
                    Courses = new List<Course> { courses[0], courses[2] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Milind", FatherlastName = "Rane",
                        Gender = Gender.Female, DateOfBirth = new DateTime(2005, 9, 28),
                        BloodGroup = "A+"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "10 Fort Road", PinCode = "400702", City = "Navi Mumbai", State = "Maharashtra" },
                        new() { Name = "Rental", StreetAddress1 = "Flat 8, Palm Avenue", PinCode = "400703", City = "Navi Mumbai", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Nikhil", LastName = "Wagh", Age = 23,
                    Courses = new List<Course> { courses[1], courses[3] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Subhash", FatherlastName = "Wagh",
                        Gender = Gender.Male, DateOfBirth = new DateTime(2003, 6, 21),
                        BloodGroup = "B+"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "35 Bazaar Road", PinCode = "444601", City = "Amravati", State = "Maharashtra" }
                    }
                },
                new()
                {
                    FirstName = "Sakshi", LastName = "Kale", Age = 22,
                    Courses = new List<Course> { courses[0], courses[1], courses[2], courses[3] },
                    StudentProfile = new StudentProfiles
                    {
                        FatherfirstName = "Hemant", FatherlastName = "Kale",
                        Gender = Gender.Female, DateOfBirth = new DateTime(2004, 12, 16),
                        BloodGroup = "O-"
                    },
                    Address = new List<Address>
                    {
                        new() { Name = "Home", StreetAddress1 = "42 Central Road", PinCode = "440001", City = "Nagpur", State = "Maharashtra" },
                        new() { Name = "Hostel", StreetAddress1 = "Room 15, Campus Hostel", PinCode = "411011", City = "Pune", State = "Maharashtra" }
                    }
                }
            };
        }
    }
}