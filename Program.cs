using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Day3_CS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int min = 0, max = 100;
            var numbers = await GetPrimeNumbersAsync(min, max);
            PrintNumbers(numbers);
        }
        static async Task<List<int>> GetPrimeNumbersAsync(int min, int max)
        {
            var list = new List<int>();
            var results = await Task.Factory.StartNew(() =>
            {

                for (int i = min; i <= max; i++)
                {
                    if (IsPrimeNumberBasic(i))
                    {
                        list.Add(i);
                    }
                }
                return list;

            });
            return results;
        }
        static void PrintNumbers(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
        static bool IsPrimeNumberBasic(int number)
        {
            int i;
            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0) return false;
            }
            if (i == number) return true;
            return false;
        }
    }
}
