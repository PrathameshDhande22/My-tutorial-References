

using System.Text.RegularExpressions;

namespace Tutorial
{
    class _03_Custom_Extension_methods
    {
        public static void CustomExtensionmethodUsage()
        {
            // using the custom created extension method
            List<int> nos = new() { 1, 2, 3, 4, 5, 6 };
            foreach (int i in nos)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // custom extension method
            List<int> newnos = nos.MultiplyBy(5);
            foreach (int i in newnos)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            string word = "dhande";
            Console.WriteLine(word.AddNextCharacterToEach());
        }
    }



    // to create extension methods class must be static and methods must also be static with the parameter of this keyword for which class you want extension methods.
    static class MethodsClass
    {
        // these methods multiply by 2 in all the list these extension method is applied to List class
        public static List<int> MultiplyBy(this List<int> a, int b)
        {
            return a.Select(no => no * b).ToList();
        }

        public static string AddNextCharacterToEach(this string word)
        {
            if (Regex.Count(word, @"\s") != 0)
            {
                throw new Exception("The word must not contain any spaces");
            }
            char[] chars = word.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)((int)chars[i] + 1);
            }
            return String.Join("", chars.AsEnumerable());
        }
    }
}
