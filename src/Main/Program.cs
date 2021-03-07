using System;
using System.Diagnostics;
using System.Globalization;
using Spectre.Console;

namespace Fenumbler
{
    static class Program
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

                if (!ulong.TryParse(input, out var result))
                {
                    Console.WriteLine("Fenumbler: Only positive 64-bit integers are valid for the second argument.");
                }
                else
                {
                    switch (command)
                    {
                        case "-isprime":
                            ShowPrimeFacts(result);
                            break;
                        case "-count":
                            var i = 0;
                            foreach (var prime in PrimeUtilties.GetFirstNPrimes(result))
                            {
                                Console.WriteLine($"{++i}: {prime}");
                            }
                            break;
                        case "-mersenne":
                            var j = 0;
                            foreach (var mersenne in PrimeUtilties.GetFirstNMersennes(result))
                            {
                                Console.WriteLine($"{++j}: {mersenne}");
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
            AnsiConsole.Render(
                new FigletText("Fenumbler")
                    .LeftAligned()
                    .Color(Color.Blue1));
            Console.WriteLine("Fenumbler:");
            Console.WriteLine(" Usage: [-isprime X] to check whether X is prime.");
            Console.WriteLine("     or [-count N] to return a count of the first N primes.");
            Console.WriteLine("     or [-mersenne N] to return a count of the first N mersenne numbers.");
        }

        private static void ShowPrimeFacts(ulong input)
        {
            try
            {
                var nfi = new CultureInfo( "en-US", false ).NumberFormat;
                nfi.NumberDecimalDigits = 0;
                var table = new Table()
                    .AddColumn($"[bold green3]{input.ToString("N", nfi)}[/]")
                    .AddColumn("Prime")
                    .AddColumn("Mersenne");
                

                var stopWatch = Stopwatch.StartNew();
                bool isPrime = input.IsPrime();
                bool isMersenne = input.IsMersenneNumber();
                
                var isPrimeStr = isPrime ? ":check_mark_button:" : ":cross_mark:";
                var isMersStr = isMersenne ? ":check_mark_button:" : ":cross_mark:";
                //Console.WriteLine($"{input} {isPrimeStr} and {isMersStr}.");

                table.AddRow("", $"{isPrimeStr}", $"{isMersStr}");
                
                AnsiConsole.Render(table);

                if (!isPrime)
                {
                    foreach (var factor in PrimeUtilties.GetPrimeFactorization(input))
                    {
                        var power = factor.Value > 1 ? $" ^ {factor.Value}" : string.Empty;
                        Console.WriteLine($" > {factor.Key}{power}");
                    }
                }

                stopWatch.Stop();
                if (stopWatch.ElapsedMilliseconds < 1000)
                {
                    Console.WriteLine("Calculation took less than a second.");
                }
                else
                {
                    Console.WriteLine($"Calculation took about {stopWatch.ElapsedMilliseconds / 1000} seconds.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"An error was encountered: {e.Message}");
            }
        }
    }
}
