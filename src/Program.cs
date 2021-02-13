using System;
using System.Diagnostics;
using System.Linq;

namespace PrimeNumberCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Enter a number to test or [-run] to run the program.");
            }
            else
            {
                var arg = args[0];
                switch (arg)
                {
                    case "-run":
                        Main2(null);
                        break;
                    default:
                        if (ulong.TryParse(arg, out var result))
                        {
                            var isPrime = PrimeNumberUtils.IsPrime(result);
                            var isPrimeStr = isPrime ? "prime" : "not prime";
                            Console.WriteLine($"{result} is {isPrimeStr}");
                        }
                        break;
                }    
            }
        }
        
        static void Main2(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"{Environment.NewLine}Is your number prime? Greater than 1 is valid. Anything else to EXIT.");
                var test = Console.ReadLine();

                if (ulong.TryParse(test, out var result))
                {
                    try
                    {
                        var stopWatch = Stopwatch.StartNew();
                        bool isPrime = PrimeNumberUtils.IsPrime(result);
                        var isPrimeStr = isPrime ? "prime" : "not prime";
                        Console.WriteLine($"is {isPrimeStr}");

                        if (!isPrime)
                        {
                            var factors = PrimeNumberUtils.GetPrimeFactorization(result);

                            foreach (var factor in factors)
                            {
                                var power = factor.Value > 1 ? $" ^ {factor.Value}" : string.Empty;
                                Console.WriteLine($" > {factor.Key}{power}");
                            }
                        }
                        stopWatch.Stop();
                        if (stopWatch.ElapsedMilliseconds < 1000)
                        {
                            Console.WriteLine("Less than 1 second");
                        }
                        else
                        {
                            Console.WriteLine($"{stopWatch.ElapsedMilliseconds / 1000} seconds");
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }               
            }
        }
    }
}
