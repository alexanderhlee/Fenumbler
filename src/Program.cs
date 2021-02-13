using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PrimeNumberCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"{Environment.NewLine}Is your number prime? Greater than 1 is valid. Anything else to EXIT");
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

                            foreach (var item in factors)
                            {
                                Console.WriteLine($" > {item.Key} ^ {item.Value}");
                            }
                        }
                        stopWatch.Stop();
                        if (stopWatch.ElapsedMilliseconds < 1000)
                        {
                            Console.WriteLine("Less than 1 second");
                        }
                        else
                        {
                            Console.WriteLine($"Elapsed time for calculation {stopWatch.ElapsedMilliseconds / 1000}");
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
