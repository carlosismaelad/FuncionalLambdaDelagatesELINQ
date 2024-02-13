using ExerLinq.Entities;
using System.Security.Cryptography;

namespace ExerLinq
{
    using System.Globalization;
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            List<Product> list = new List<Product>();

            Console.Write("Enter the full path file: ");
            string path = Console.ReadLine();

            // opening and reading the file
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(",");
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                    list.Add(new Product(name, price));
                }
            }

            var averagePrice = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine($"The average price of the products is:  {averagePrice.ToString("F2", CultureInfo.InvariantCulture)}");

            var names = list.Where(p => p.Price < averagePrice).OrderByDescending(p => p.Name).Select(p => p.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}