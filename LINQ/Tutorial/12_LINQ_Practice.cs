

namespace Tutorial
{
    class _12_LINQ_Practice
    {
        public static void LINQPracticeQuestions()
        {
            /* Write a program in C# Sharp to find the number of an array and the square of each number. */
            int[] nos = new[] { 1, 2, 3, 4, 5, 6, };

            var res3 = from no in nos
                      select new { Number = no, Square = no * no };
            foreach (var n in res3)
            {
                Console.WriteLine($"Number={n.Number} Square={n.Square}");
            }
            Console.WriteLine();

            /* Write a program in C# Sharp to display the number and frequency of a given number from an array. */
            int[] nos2 = new[] { 5, 5, 5, 5, 7, 6, 2, 6, 7, 2, 2, 5, 8, 10 };

            var res2 = from no in nos2
                       group no by no into egroup
                       select new { egroup.Key, egroup };
            foreach (var re in res2)
            {
                Console.WriteLine($"Number={re.Key} Frequency={re.egroup.Count()}");
            }

            // Self Join
            List<Employee> employees = new Data().GetEmployees();

            var results = from emp in employees
                          join emp2 in employees
                          on emp.managerId equals emp2.id
                          select new { emp2 };
            foreach(var res in results)
            {
                Console.WriteLine($"manager={res.emp2.id} name={res.emp2.fullname} date={res.emp2.Dateofjoining.Date}");
            }

            
        }
    }
}
