using System;
using System.Diagnostics;
using System.Linq;

namespace PrimeNumberCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                ShowUsage();
            }
            else
            {
                var command = args[0];
                var input = args[1];

                if (!uint.TryParse(input, out var result))
                {
                    Console.WriteLine("PrimeCalc: Only positive 32-bit integers are valid for the second argument.");
                }
                else
                {
                    switch (command)
                    {
                        case "-isprime":
                            ShowPrimeFacts(result);
                            break;
                        case "-count":
                            ulong nextPrime = 1;
                            for (int i = 1; i <= result; i++)
                            {
                                nextPrime = PrimeNumberUtils.GetNextPrime(nextPrime);
                                Console.WriteLine($"{i}: {nextPrime}");
                            }
                            break;
                        default:
                            ShowUsage();
                            break;
                    }    
                }
            }
        }

        private static void ShowUsage()
        {
            Console.WriteLine("PrimeCalc:");
            Console.WriteLine(" Usage: [-isprime X] to check whether X is prime.");
            Console.WriteLine("     or [-count N] to return a count of the first N primes.");
        }

        private static void ShowPrimeFacts(uint input)
        {
            try
            {
                var stopWatch = Stopwatch.StartNew();
                bool isPrime = PrimeNumberUtils.IsPrime(input);
                var isPrimeStr = isPrime ? "prime" : "not prime";
                Console.WriteLine($"{input} is {isPrimeStr}");

                if (!isPrime)
                {
                    var factors = PrimeNumberUtils.GetPrimeFactorization(input);

                    foreach (var factor in factors)
                    {
                        var power = factor.Value > 1 ? $" ^ {factor.Value}" : string.Empty;
                        Console.WriteLine($" > {factor.Key}{power}");
                    }
                }

                stopWatch.Stop();
                if (stopWatch.ElapsedMilliseconds < 1000)
                {
                    Console.WriteLine("Calculation took less than a second");
                }
                else
                {
                    Console.WriteLine($"Calculation took about {stopWatch.ElapsedMilliseconds / 1000} seconds");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"An error was encountered: {e.Message}");
            }
        }
    }
}
