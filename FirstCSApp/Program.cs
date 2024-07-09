// Run - Ctrl+F5
// Format Code: C + K->F

// this is comment

/*
    block comment
 */

// -------------------- console --------------------
//Console.BackgroundColor = ConsoleColor.Red;
//Console.ForegroundColor = ConsoleColor.White;
//Console.WindowWidth = 50; 

Console.WriteLine("Hello, World!" + "!" + "!");

// Escape: \n \t \" \'
Console.WriteLine("Hello,\n\"Vlad\"\t\t!");

//Console.Clear();

// --------------- data types ---------------
// type name = value;

string city = "Rivne";
char symbol = '$';      // 2 B

// integer
byte b = 255;           // 1 B
short age = 21;         // 2 B
int number = 1000;      // 4 B
long width = 45909999L; // 8 B

// real
float height = 120.5F;  // 4 B
double koef = 10.8;     // 8 B
decimal price = 4M;     // 16 B

// emmet: cw -> Console.WriteLine();

// --------- type conversion: (type)expression ---------
Console.WriteLine(12);


// ------------ operators: + - * / % ------------
Console.WriteLine(2 + 2 * 2);
Console.WriteLine("One " + "Two...");
Console.WriteLine("Result: " + 120 * 1.2);

Console.WriteLine("I'am from " + city + ", and you?");  // concatenation 
Console.WriteLine($"I'am from {city}, and you?");       // interpolation

// TASK: convert hours to minues
int h = 24;

const int minutesInHour = 60;
// minutesInHour = 70; // error

Console.WriteLine($"Minutes: {h * minutesInHour}");

Console.Write("Enter hours to convert: ");

// ---------- type convert: Convert...()
// ---------- convert from string: type.Parse()

int input = int.Parse(Console.ReadLine());

Console.WriteLine($"Minutes: {input * minutesInHour}m");

// ------------ Math ------------
Console.WriteLine("2^32 = " + Math.Pow(2, 32));

Console.WriteLine("Floor: " + Math.Floor(4.99));    // 4
Console.WriteLine("Ceiling: " + Math.Ceiling(4.1)); // 5
Console.WriteLine("Round: " + Math.Round(4.5));     // 5

Console.WriteLine($"Mix: {Math.Floor(Math.Pow(4, 2) * 2.2)}");
