internal class Program
{
    enum Direction { Top = 1, Left, Right, Bottom };

    private static void Main(string[] args)
    {
        //Console.WriteLine(2 + 2 * 2);        // Int
        //Console.WriteLine(2 > 10);           // bool
        //Console.WriteLine("Vlad" == "Oleg"); // bool

        // login operator: > < >= <= == != && || !

        //IfElseExample();
        //SwitchExample();
        //EnumExample();
        //WhileLoopExample();
        //DoWhileLoopExample();
        //ForLoopExample();

        ArrayExample();

        Console.WriteLine("Have a good day!");
    }

    private static void IfElseExample()
    {
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        // check is user adult age >= 18
        if (age >= 18)
        {
            // code
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You have access!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You are too young! Go back latet...");
            Console.ResetColor();
        }

        Console.Write("Enter current weekday (1-7): ");
        int weekday = int.Parse(Console.ReadLine());

        if (weekday == 1) Console.WriteLine("Today is Monday!");
        else if (weekday == 2) Console.WriteLine("Today is Tuesday!");
        else if (weekday == 3) Console.WriteLine("Today is Wednesday!");
        else if (weekday == 4) Console.WriteLine("Today is Thursday!");
        else if (weekday == 5) Console.WriteLine("Today is Friday!");
        else if (weekday == 6) Console.WriteLine("Today is Satureday!");
        else if (weekday == 7) Console.WriteLine("Today is Sunday!");
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You entered incorrect weekday!");
            Console.ResetColor();
        }
    }
    private static void SwitchExample()
    {
        Console.Write("Enter current weekday (1-7): ");
        int weekday = int.Parse(Console.ReadLine());

        // switch (expression) { case value: code; }
        // break - go out of the block (switch, loop)
        switch (weekday)
        {
            case 1: Console.WriteLine("Today is Monday!"); break;
            case 2: Console.WriteLine("Today is Tuesday!"); break;
            case 3: Console.WriteLine("Today is Wednesday!"); break;
            case 4: Console.WriteLine("Today is Thursday!"); break;
            case 5: Console.WriteLine("Today is Friday!"); break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You entered incorrect weekday!");
                Console.ResetColor();
                break;
        }

        switch (weekday)
        {
            case 2:
            case 4:
                Console.WriteLine("Today you have a lesson!"); break;

            case 1:
            case 3:
            case 5:
            case 6:
            case 7:
                Console.WriteLine("You are free today!"); break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You entered incorrect weekday!");
                Console.ResetColor();
                break;
        }
    }
    private static void EnumExample()
    {
        Console.SetCursorPosition(20, 10);
        Console.WriteLine('@');

        Console.WriteLine("Enter direction:");
        Console.WriteLine((int)Direction.Top + " - Top");
        Console.WriteLine((int)Direction.Left + " - Left");
        Console.WriteLine((int)Direction.Right + " - Right");
        Console.WriteLine((int)Direction.Bottom + " - Bottom");

        var direction = (Direction)Enum.Parse(typeof(Direction), Console.ReadLine());

        switch (direction)
        {
            case Direction.Top:
                Console.SetCursorPosition(20, 9);
                Console.WriteLine('@');
                break;
            case Direction.Right:
                Console.SetCursorPosition(21, 10);
                Console.WriteLine('@');
                break;
            case Direction.Bottom:
                Console.SetCursorPosition(20, 11);
                Console.WriteLine('@');
                break;
            case Direction.Left:
                Console.SetCursorPosition(19, 10);
                Console.WriteLine('@');
                break;
        }
    }

    private static void WhileLoopExample()
    {
        int age = 0;

        while (age >= 0)
        {
            Console.Write("Enter your age: ");
            age = int.Parse(Console.ReadLine());

            if (age >= 18)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have access!");
                Console.ResetColor();
            }
        }
    }
    private static void DoWhileLoopExample()
    {
        int age = 0;

        do
        {
            Console.Write("Enter your age: ");
            age = int.Parse(Console.ReadLine());

        } while (age < 0);
    }
    private static void ForLoopExample()
    {
        Console.Write("Enter your name: ");
        var name = Console.ReadLine();

        //int count = 0;

        //while (count < 10)
        //{
        //    Console.WriteLine("Hello, dear " + name + "!");
        //    ++count;
        //}

        for (int i = 0; i < 10; ++i)
        {
            Console.WriteLine("Hello, dear " + name + "!");
        }
    }

    private static void ArrayExample()
    {
        string color1 = "Red";
        string color2 = "Green";

        // create array
        string[] colors = { "Red", "White", "Yello", "Blue", "Purple" };

        Console.WriteLine("Colors count: " + colors.Length);

        // доступ в масиві по індексу: починається з [0]

        colors[2] = "Brown";
        Console.WriteLine("Third item: " + colors[2]);

        Console.WriteLine(colors);

        for (int i = 0; i < colors.Length; i++)
        {
            Console.WriteLine("Item: " + colors[i]);
        }

        // Завдання: Знайти суму елементів масива
        double[] prices = { 340.5, 4, 100 };

        double summ = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            summ += prices[i];
        }

        Console.WriteLine($"Total price: {summ}$");

        // Завдання: ввести 5 чисел з клавіатури та відобразити середнє арифметичне
        int[] numbers = new int[5]; // розмір масива, всі елемменти = 0

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Enter {i+1} number: ");
            numbers[i] = int.Parse(Console.ReadLine());
        }

        // foreach - цикл автоматично перебирає елементи масива
        // * немає можливості змінити елемент
        // * немає доступу до індекса елемента
        foreach (int n in numbers)
        {
            Console.WriteLine("Number: " + n);
        }

        Console.WriteLine("Average: " + numbers.Average());
    }
}
