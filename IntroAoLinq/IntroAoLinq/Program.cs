

namespace IntroAoLinq
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            // Specify the data source
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            // Define the query expression
            var result  = numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * 10);

            // Execute the query
            foreach(int x in result) {  Console.WriteLine(x); }

        }
    }
}