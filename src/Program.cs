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
                        bool isPrime = IsPrime(result);
                        var isPrimeStr = isPrime ? "prime" : "not prime";
                        Console.WriteLine($"is {isPrimeStr}");

                        if (!isPrime)
                        {
                            var factors = GetPrimeFactorization(result);

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

        static bool IsPrime(ulong numberToTest)
        {
            if (numberToTest <= 1)
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(numberToTest), message: "Integers less than 2 are invalid for prime test.");
            }
            switch (numberToTest)
            {
                case 2:
                case 3:
                case 5:
                case 7:
                    return true;
                default:
                    break;
            }

            if (numberToTest % 2 == 0 || numberToTest % 3 == 0 || numberToTest % 5 == 0)
            {
                return false;
            }

            for (uint i = 7; i < (numberToTest / 2); i += 2)
            {
                if (numberToTest % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static Dictionary<ulong, uint> GetPrimeFactorization(ulong n)
        {
            var factors = new Dictionary<ulong, uint>();

            if (IsPrime(n))
            {
                factors.Add(n, 1);
            }
            else
            {
                ulong factor = 2;
                var result = n;
                uint pow = 1;

                while (true)
                {
                    if (result % factor == 0)
                    {
                        result /= factor;
                        if (!factors.TryAdd(factor, pow))
                        {
                            factors[factor] = pow;
                        }

                        if (IsPrime(result))
                        {
                            if (!factors.ContainsKey(result))
                            {
                                factors.Add(result, 1);
                            }
                            else
                            {
                                factors[result] = factors.GetValueOrDefault(result) + 1;
                            }
                            break;
                        }

                        pow++;
                    }
                    else
                    {
                        pow = 1;
                        factor = GetNextPrime(factor);
                    }
                }
            }

            return factors;
        }

        static ulong GetNextPrime(ulong n)
        {
            do
            {
                n++;
            } while (!IsPrime(n));
            return n;
        }
    }
}
