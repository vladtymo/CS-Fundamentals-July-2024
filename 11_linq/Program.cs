using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _09_linq
{
    // LINQ (Language-Integrated Query)

    // Існує декілька різновидів LINQ:
    /*
        LINQ to Objects:        застосовується для роботи з масивами та колекціями
        LINQ to Entities:       використовується при зверненні до баз даних через технологію Entity Framework
        LINQ to Sql:            технологія доступу до даних у MS SQL Server
        LINQ to XML:            застосовується під час роботи з файлами XML
        LINQ to DataSet:        застосовується під час роботи з об'єктом DataSet
        Parallel LINQ (PLINQ):  використовується для виконання паралельної запитів 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] colors = { "red", "blue", "black", "yellow", "orange", "white", "gray" };
            int[] numbers = { 1, 6, -3, 12, 663, 992, -3, 1, -34, 40, -10, 0, 99, 123 };

            List<Product> products = new()
            {
                new Product("iPhone X", "Electronics", 430),
                new Product("Tesla Model 3", "Auto", 69000),
                new Product("Bicycle Ukraine", "Transport", 790),
                new Product("Adidas T-Shirt", "Clothes", 144),
                new Product("VW Passat B8", "Auto", 20430),
                new Product("Audi E-Tron", "Auto", 50000),
                new Product("Samsung S23", "Electronics", 1299),
            };
            ShowCollection(numbers, "Original");

            //Func<int, bool> checker = (x) => x >= 100;

            // Where(condition) - filter collection element by condition
            //var filtered = numbers.Where(IsTwoDigits);
            //var filtered = numbers.Where(delegate (int num) { return num.ToString().Length == 2; });
            var filtered = numbers.Where((i) => Math.Abs(i).ToString().Length == 2);

            ShowCollection(filtered, "Filtered");

            // OrderBy[Descending](key) - sort colllection by key value
            var sorted = numbers.OrderByDescending(x => Math.Abs(x));
            // numbers.OrderByDescending(x => x);
            var sortedByPrice = products.OrderBy(p => p.Price);

            ShowCollection(sorted, "Sorted");
            ShowCollection(sortedByPrice, "By Price", true);

            // Select(value) - map/convert all collection item to a different value
            var modules = numbers.Select(x => Math.Abs(x));
            var tags = numbers.Select(x => $"<{x}>");
            var models = products.Select(x => x.Model);
            // anonymous types: new { properties }
            var mapped = products.Select(x => new
            {
                Model = x.Model,
                Price = x.Price + "$",
                Discount = x.Price > 1000 ? 10 : 0
            });

            ShowCollection(modules, "Modules");
            ShowCollection(tags, "Tags");
            ShowCollection(models, "Models");

            // Aggregation methods:
            // Min([key]) Max([key])     - get max/min value by key
            // Sum([key]) Average([key]) - get sum/avg by key
            // Count([condition])        - get count of item by condition
            var maxNumber = numbers.Max();
            var totalPrice = products.Sum(p => p.Price);
            var avgPrice = products.Average(p => p.Price);
            var cheapest = products.Min(p => p.Price);
            var evenCount = numbers.Count(x => x % 2 == 0);

            Console.WriteLine($"Max number: {maxNumber}");
            Console.WriteLine($"Total price: {totalPrice}");
            Console.WriteLine($"Avg price: {avgPrice}");
            Console.WriteLine($"The cheapest product: {cheapest}");
            Console.WriteLine($"Even numbers: {evenCount}");

            // Take(count) - get the first element of count
            var top3 = numbers.OrderByDescending(x => x).Take(3);

            ShowCollection(top3, "TOP 3");

            // First([condition]) Last([condition]) - get first/last element,
            //                                        if there's no element - throw Exception
            var firstNum = numbers.First(x => x < 0);
            var lastNum = numbers.Last(x => x % 10 == 0 && x != 0);
            // FirstOrDefault([condition]) LastOrDefault([condition]) - get first/last element,
            //                                                          if there's no element - return default value
            var car = products.FirstOrDefault(p => p.Category == "AutoBlabla");

            // default values: numeric - 0, class - null

            Console.WriteLine($"First number: {firstNum}");
            Console.WriteLine($"Last number: {lastNum}");

            if (car == null)
                Console.WriteLine("Product not found!");
            else
                Console.WriteLine($"First auto: {car}");

            // GroupBy(key) - gorup all element by key
            var groups = products.GroupBy(p => p.Category);

            foreach (var group in groups)
            {
                // group - contains group items
                Console.WriteLine($"Group {group.Key}:");
                foreach (var i in group)
                {
                    Console.WriteLine('\t' + i.ToString());
                }
            }

            // -------------- lazy loading --------------
            var result = numbers.Where(x => x > 100);
            numbers[0] = 120;

            result = result.OrderByDescending(x => x).ToList(); // implicit loading
            numbers[1] = 999;

            ShowCollection(result, "Filered"); // ...120...
        }

        static void ShowCollection<T>(IEnumerable<T> collection, string? title = null, bool lines = false)
        {
            Console.Write($"{title ?? "Array"}: ");
            foreach (var item in collection)
            {
                Console.Write(item + " ");
                if (lines) Console.WriteLine();
            }
            Console.WriteLine();
        }

        //static bool IsTwoDigits(int number)
        //{
        //    return Math.Abs(number).ToString().Length == 2;
        //}
    }
}