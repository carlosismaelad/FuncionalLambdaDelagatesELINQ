using LinqSimilarASql.Entities;

namespace LinqSimilarASql
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            Category cat1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category cat2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category cat3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            // data source for LINQ expression
            List<Product> products = new List<Product>() {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = cat2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = cat1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = cat3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = cat2 },
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = cat1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = cat2 },
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = cat3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = cat3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = cat2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = cat3 },
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = cat1 }
            };

            var r1 =
                from p in products
                where p.Category.Tier == 1 && p.Price < 900.0
                select p;
            Print("Tier 1 and Proce < 900.00:", r1);

            Console.WriteLine("-------------------");

            var r2 = 
                from p in products
                where p.Category.Name == "Tools"
                select p.Name;
            Print("Names of products from Tools:", r2 );

            Console.WriteLine("-------------------");

            var r3 =
                from p in products
                where p.Name[0] == 'C' || p.Name[0] == 'c'
                select new
                {
                    p.Name,
                    p.Price,
                    CategoryName = p.Category.Name
                };
            Print("Names started with C an anonymous object:", r3);

            Console.WriteLine("-------------------");

            var r4 =
                from p in products
                where p.Category.Tier == 1
                orderby p.Name
                orderby p.Price
                select p;
            Print("Tier 1 order by price then by name:", r4);

            Console.WriteLine("-------------------");

            var r5 =
                (from p in r4
                 select p).Skip(2).Take(4);
            Print("Tier 1 order by price then by name skip 2 take 4:", r5);

            Console.WriteLine("-------------------");

            var r6 =
                from p in products
                group p by p.Category;
            foreach (IGrouping<Category, Product> group in r6)
            {
                Console.WriteLine("Category " + group.Key.Name + ": ");
                foreach (Product p in group)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }
           
        }

        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T item in collection) Console.WriteLine(item);
        }
    }
}