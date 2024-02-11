using DemoComLinq.Entities;

namespace DemoComLinq
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            Category cat1 = new Category() { Id = 1, Name = "Tools", Tier = 2};
            Category cat2 = new Category() { Id = 2, Name = "Computers", Tier = 1};
            Category cat3 = new Category() { Id = 3, Name = "Electronics", Tier = 1};

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

           
            var result_1 = products.Where(x => x.Category.Tier == 1 && x.Price < 900.0);
            Print("All products Tier 1 and Price < 900.00", result_1);

            Console.WriteLine("-------------------------");

            var result_2 = products.Where(x => x.Category.Name == "Tools").Select(x => x.Name);
            Print("Names of products from Tool", result_2);

            Console.WriteLine("-------------------------");

            var result_3 = products.Where(x => x.Name[0] == 'c' || x.Name[0] == 'C').Select(x => new {x.Name, x.Price, CategoryName = x.Category.Name});
            // criamos um objeto anônimo na expressão lambda e um alias para o nome da categoria
            Print("Names of all products that start with the letter C", result_3);

            Console.WriteLine("-------------------------");

            var result_4 = products.Where(x => x.Category.Tier == 1).OrderBy(x => x.Price).ThenBy(x => x.Name);
            // ordena por preço e quando são iguais ordena por nome
            Print("Tier 1 order by price then by name", result_4);

            Console.WriteLine("-------------------------");

            var result_5 = result_4.Skip(2).Take(4);
            Print("Tier 1 order by price then by name skip 2 take 4", result_5);

            Console.WriteLine("-------------------------");

            var result_6 = products.First();
            Console.WriteLine("First element: " + result_6);

            Console.WriteLine("-------------------------");

            var result_7 = products.Where(x => x.Price > 3000.0).FirstOrDefault();
            Console.WriteLine("First or default product with price bigger than 3000.00: " + result_7);

            Console.WriteLine("-------------------------");

            // SingleOrDefaul:
            // usamos SingleOrDefault para controlar se o que eu queremos receber é um IEnumerable ou um Product
            // Com o SingleOrDefaul, result_8 é do tipo Product, sem ele ela passa a ser do tipo IEnumerable
            // Só podemos usar o SingleOrDefaul onde o resultado é um único elemento ou nenhum, quando o resultamos é mais de um não podemos usá-lo.
            var result_8 = products.Where(x => x.Id == 3).SingleOrDefault();
            Console.WriteLine("Single or default test 1: " + result_8);
            var result_9 = products.Where(x => x.Id == 30).SingleOrDefault();
            Console.WriteLine("Single or default test 2: " + result_9);

            Console.WriteLine("-------------------------");

            // AGREGATIONS EXPRESSIONS

            var result_10 = products.Max(x => x.Price); 
            // retorna o máximo usando apenas Max() ou podemos usar uma expressão para filtrar
            // mas sem a expressão o programa retorna uma exceção porque teremos que implementar o IComparable na nossa classe
            Console.WriteLine("Max Price: " + result_10);

            Console.WriteLine("-------------------------");

            var result_11 = products.Min(x => x.Price);
            Console.WriteLine("Min Price: " + result_11);

            Console.WriteLine("-------------------------");

            var result_12 = products.Where(x => x.Category.Id == 1).Sum(x => x.Price);
            Console.WriteLine("The sum of the values of the all products in category 1: " + result_12);

            Console.WriteLine("-------------------------");

            var result_13 = products.Where(x => x.Category.Id == 1).Average(x => x.Price);
            Console.WriteLine("The average of the price of the all products in category 1: " + result_13);

            Console.WriteLine("-------------------------");

            var result_14 = products.Where(x => x.Category.Id == 5).Select(x => x.Price).DefaultIfEmpty(0.00).Average();
            // Criamos uma lista vazia com o id 5 que não existe
            // informamos ao programa que se a lista for vazia atribua o valor 0.00
            // aplicamos a operação Average sem argumentos porque já o repassamos no Select.
            Console.WriteLine("A protection for the division by 0 operation : " + result_14);

            Console.WriteLine("-------------------------");

            var result_15 = products.Where(x => x.Category.Id == 1).Select(x => x.Price).Aggregate((x, y) => x + y);
            Console.WriteLine("Category 1 Aggregate sum: " + result_15);

            Console.WriteLine("-------------------------");

            var result_16 = products.Where(x => x.Category.Id == 5).Select(x => x.Price).Aggregate(0.0, (x, y) => x + y);
            // Retornaria uma exceção porque criamos uma lista vazia
            // tratamos a exceção atribuinco um valor padrão inical no Aggregate
            Console.WriteLine("Category 5 Aggregate sum: " + result_16);
            Console.WriteLine();

            Console.WriteLine("-----------Grouping by category-------------");

            var result_17 = products.GroupBy(x => x.Category);
            foreach (IGrouping<Category, Product> group in result_17)
            {
                Console.WriteLine("Category " + group.Key.Name + ": ");
                foreach(Product product in group)
                {
                    Console.WriteLine(product);
                }
                Console.WriteLine();
            }


        }

        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach(T item in collection) Console.WriteLine(item);
        }
    }
}