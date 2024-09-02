

namespace Tutorial
{
    class _01_Getting_Started
    {
        public static void BasicsOfLINQ()
        {
            // simple query
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            // getting all the numbers
            IEnumerable<int> nos = from num in numbers select num;
            foreach (int n in nos)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            // printing all the odd numbers using where clause
            IEnumerable<int> oddnos = from num in numbers where num % 2 == 1 select num;
            foreach (int n in oddnos)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            // getting all the even numbers 
            IEnumerable<int> evenos = from num in numbers where num % 2 != 1 select num;
            foreach (int n in evenos)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            // writing the LINQ queries using Lambda expression
            IEnumerable<int> evennos = numbers.Where<int>((no) =>
            {
                if (no % 2 != 1)
                {
                    return true;
                }
                return false;
            });
            foreach (int n in evennos)
            {
                Console.Write(n + " ");
            }
        }
    }
}
