using System.Text.RegularExpressions;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите 2 числа: ");

            Match match;
                        
            while (!(match = Regex.Match(Console.ReadLine(), @"^(?<num1>\d{1,10})\s*\+\s*(?<num2>\d{1,10})$")).Success)
            {
                Console.WriteLine("Неправильный ввод");
                Console.Write("Введите 2 числа: ");
            }

            var num1Converted = double.Parse(match.Groups["num1"].Value);
            var num2Converted = double.Parse(match.Groups["num2"].Value);

            var sum = num1Converted + num2Converted;
            Console.WriteLine($"{num1Converted} + {num2Converted} = {sum}");
        }
    }
}
