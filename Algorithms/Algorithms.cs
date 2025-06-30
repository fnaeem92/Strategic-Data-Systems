using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        // 1. Calculate the factorial of a number
        public static int GetFactorial(int n)
        {
            if (n < 0) throw new ArgumentException("n must be a non-negative integer.");

            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        // 2. Format a list of string
        public static string FormatSeparators(params string[] items)
        {
            if (items.Length == 0)
            {
                return string.Empty;
            }

            if (items.Length == 1)
            {
                return items[0];
            }

            if (items.Length == 2)
            {
                return string.Join(" and ", items); 
            }

            return string.Join(", ", items, 0, items.Length - 1) + " and " + items[items.Length - 1];
        }
    }
}
