using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyThreading
{
    public static class App
    {
        private static ConcurrentDictionary<int, (int original, int fibonacci, int factorial)> dict = new();
        public static async Task AppExecuteAsync()
        {
            Func<int, int> fibonacci = null;
            Func<int, int> factorial = null;
            fibonacci = Memoizer.Memoize((int n) => Fibonacci(n, fibonacci));
            factorial = Memoizer.Memoize((int n) => Factorial(n, factorial));

            Console.WriteLine("Enter numbers: ");
            var input = Console.ReadLine();
            var numbers = new List<int>();

            foreach (var str in input.Split(' '))
            {
                if (int.TryParse(str, out var num))
                {
                    numbers.Add(num);
                }
            }

            foreach (var number in numbers)
            {
                var fibTask = Task.Run(() => fibonacci(number));
                var facTask = Task.Run(() => factorial(number));

                await Task.WhenAll(fibTask, facTask);

                dict.TryAdd(number, (number, fibTask.Result, facTask.Result));
            }

            foreach (var item in dict)
            {
                Console.WriteLine(
                    $"Number: {item.Value.original}, " +
                    $"Fibonacci: {item.Value.fibonacci}, " +
                    $"Factorial: {item.Value.factorial}");
            }
        }

        private static int Fibonacci(int n)
        {
            return Fibonacci(n, Fibonacci);
        }

        private static int Fibonacci(int n, Func<int, int> fibonacci)
        {
            if (n <= 2)
                return 1;

            return fibonacci(n - 1) + fibonacci(n - 2);
        }

        private static int Factorial(int n)
        {
            return Factorial(n, Factorial);
        }

        private static int Factorial(int n, Func<int, int> factorial)
        {
            if (n < 2)
                return 1;

            return n * Factorial(n - 1);
        }
    }
}
