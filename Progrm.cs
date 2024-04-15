using System.Text;

namespace Generate_Random_values
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            int choice;
            do
            {
                Console.WriteLine("Enter 1 To Generate Random Number ");
                Console.WriteLine("Enter 2 To Generate Random String ");
                Console.WriteLine("Enter 0 To Exict The Program ");
                Console.Write("Your Choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        GenerateRandomNumber();
                        break;
                    case 2:
                        GenerateRandomString();
                        break;
                     case 0:
                        Console.WriteLine("Thank You!");
                        break;

                    default:
                        Console.WriteLine("Invalid option ,Try again");
                        break;
                }
            }while (choice != 0);
                
        }

        static void GenerateRandomNumber()
        {
            Console.Write("Enter The Minimum Value: ");
            if (!int.TryParse(Console.ReadLine(), out int min))
            {
                Console.WriteLine("Invalid input for minimum value.");
                return;
            }

            Console.Write("Enter The Maximum Value: ");
            if (!int.TryParse(Console.ReadLine(), out int max))
            {
                Console.WriteLine("Invalid input for maximum value.");
                return;
            }

            var rnd = new Random();
            var num = rnd.Next(min, max);
            Console.WriteLine($"Your Random Number : {num}");
        }
        static void GenerateRandomString()
        {
            Console.Write("Enter The Length Of The String: ");
            if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
            {
                Console.WriteLine("Invalid input for string length.");
                return;
            }

            Console.Write("\nInclude Capital Letters (Yes/No): ");
            bool includeCapital = Console.ReadLine().Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);

            Console.Write("Include Small Letters (Yes/No): ");
            bool includeSmall = Console.ReadLine().Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);

            Console.Write("Include Symbols (Yes/No): ");
            bool includeSymbols = Console.ReadLine().Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);

            Console.Write("Include Numbers (Yes/No): ");
            bool includeNumbers = Console.ReadLine().Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);

            GenerateRandomString(length, includeCapital, includeSmall, includeSymbols, includeNumbers);
        }

        static void GenerateRandomString(int length, bool includeCapital, bool includeSmall, bool includeSymbols, bool includeNumbers)
        {
            StringBuilder sb = new StringBuilder();
            if (includeCapital)
                sb.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            if (includeSmall)
                sb.Append("abcdefghijklmnopqrstuvwxyz");
            if (includeSymbols)
                sb.Append("!@#$%^&*");
            if (includeNumbers)
                sb.Append("0123456789");

            if (sb.Length == 0)
            {
                Console.WriteLine("No character set selected for generating random string.");
                return;
            }

            var rnd = new Random();
            StringBuilder res = new StringBuilder();
            while (res.Length < length)
            {
                int index = rnd.Next(0, sb.Length);
                res.Append(sb[index]);
            }
            Console.WriteLine($"Your Random String: {res}");
        }
    }
}
