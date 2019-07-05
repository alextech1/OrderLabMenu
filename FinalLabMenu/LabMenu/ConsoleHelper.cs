using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LabMenu
{
    public static class ConsoleHelper
    {
        public static int ReadInt32 ( )
        {
            return ReadInt32("You must enter a number");
        }

        public static int ReadInt32 ( int minValue, int maxValue )
        {
            return ReadInt32($"You must enter a value between {minValue} and {maxValue}", minValue, maxValue);
        }

        public static int ReadInt32 ( string message )
        {
            return ReadInt32(message, Int32.MinValue, Int32.MaxValue);
        }

        public static int ReadInt32 ( string message, int minValue, int maxValue )
        {
            do
            {
                int value;
                if (Int32.TryParse(Console.ReadLine(), out value) && (value >= minValue && value <= maxValue))
                    return value;

                Console.WriteLine(message);
            } while (true);
        }

        public static string ReadRegexStringValue(string pattern, string message)
        {
            Regex regex = new Regex(pattern);
            do
            {
                var value = Console.ReadLine();
                if (value != null && regex.IsMatch(value))
                {
                    return value;
                }

                Console.WriteLine(message);
            } while (true);
        }
    }
}
