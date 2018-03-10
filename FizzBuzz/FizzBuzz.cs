using System;

namespace FizzBuzz
{
    public static class FizzBuzz
    {
        public static string Eval(int n)
        {
            if (n % 3 == 0 && n % 5 == 0)
            {
                return "FizzBuzz";
            }
            if (n % 3 == 0)
            {
                return "Fizz";
            }
            if (n % 5 == 0)
            {
                return "Buzz";
            }
            return n.ToString();
        }

        public static int Main(string[] args)
        {
            for (var i = 1; i <= 100; i++)
            {
                Console.WriteLine(Eval(i));
            }
            return 0;
        }
    }
}
