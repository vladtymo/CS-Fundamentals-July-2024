using System.Threading.Channels;

namespace _11_delegates
{
    delegate double Operation(double a, double b);
    delegate T Modificator<T>(T value);

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------- Delegates --------------");

            Operation? op = Add;
            op += Div;
            //op = null;

            op?.Invoke(1, 1); // null skip
            op(1, 1);

            Console.WriteLine("Result: " + op.Invoke(20, 7));

            // Delegates is a MulticastDelegate
            // [+=] - add new method reference
            // [-=] - remove a method reference

            op += Mult;
            op += Sub;
            op -= Mult;

            Console.WriteLine("Result: " + op(20, 7)); // Sub result

            // array of delegates
            Operation[] operations = { Add, Sub, Mult, Div };

            Console.Write("Enter A = ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Enter B = ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("Operations:\n" +
                "1 - Add\n" +
                "2 - Substract\n" +
                "3 - Multiply\n" +
                "4 - Division");

            Console.Write("Enter operation: ");
            int action = int.Parse(Console.ReadLine());

            var result = operations[action - 1].Invoke(a, b);
            Console.WriteLine("Your operation result: " + result);

            // ------------------- callbacks
            int[] numbers = [1, 5, 2, 5, -1, 99, 120, -66, 5];

            ChangeArray(numbers, Increment);
            ChangeArray(numbers, Negative);

            ChangeArray(numbers, delegate (int n) { return n * n; });
            ChangeArray(numbers, (n) => n + n);

            foreach (var i in numbers) Console.Write(i + " "); Console.WriteLine();

            // ----------- Built-in Delegates: Action | Predicate | Func
            // Action - can has input parameters but void return type
            Action greeting = () => Console.WriteLine("Hello");
            Action<string> greeting2 = (login) => Console.WriteLine("Hello, dear " + login);

            // Func - has return type
            Func<double, double, double> func = Mult;

            // Predicate - returns boolean type
            Predicate<int> isEven = (x) => x % 2 == 0;

            greeting();
            greeting2("vladtymo");
            Console.WriteLine(func(4, 4));
            Console.WriteLine(isEven(6));
        }

        static void ChangeArray(int[] arr, Modificator<int> modificator) // modificator - callback method
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = modificator(arr[i]);
            }
        }

        static int Increment(int n) => n + 1;
        static int Negative(int n) => n * -1;

        static double Add(double a, double b)
        {
            Console.WriteLine("Adding numbers");
            return a + b;
        }
        static double Sub(double a, double b) => a - b;
        static double Mult(double a, double b) => a * b;
        static double Div(double a, double b) => a / b;
    }
}