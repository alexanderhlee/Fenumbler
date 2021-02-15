using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PrimeNumberCalcTests")]
namespace PrimeNumberCalc
{
	public static class PrimeNumberUtils
	{ 
		public static bool IsPrime(this ulong n)
		{
			switch (n)
			{
				case 2:
				case 3:
				case 5:
				case 7:
					return true;
			}

			if (n <= 1 || n % 2 == 0 || n % 3 == 0 || n % 5 == 0)
			{
				return false;
			}

			for (uint i = 7; i <= Math.Sqrt(n); i += 2)
			{
				if (n % i == 0)
				{
					return false;
				}
			}

			return true;
		}
		
		public static bool IsMersenneNumber(this ulong n)
		{
			return n == GetNextMersenne(n - 1);
		}

		public static IEnumerable<KeyValuePair<ulong, uint>> GetPrimeFactorization(ulong input)
        {
            uint pow = 1;
            var test = input;
            var result = new KeyValuePair<ulong, uint>(input, 1);
            var done = false;
            ulong factor = 2;
            
            if (test <= 1 || test.IsPrime())
            {
	            done = true;
	            yield return result;
            }

            while (!done)
            {
	            if (test % factor != 0)
	            {
		            pow = 1;
		            factor = GetNextPrime(factor);
	            }
	            else
	            {
		            do
		            {
			            result = new KeyValuePair<ulong, uint>(factor, pow);
			            test /= factor;
			            pow++;
		            } while (test % factor == 0);
		            
		            yield return result;

		            if (test == 1)
		            {
			            done = true;
		            }
		            else if (test.IsPrime())
		            {
			            done = true;
			            result = new KeyValuePair<ulong, uint>(test, 1);
			            yield return result;
		            }
		            else
		            {
			            pow = 1;
			            factor = GetNextPrime(factor);
		            }
	            }
            }
        }

		public static IEnumerable<ulong> GetFirstNPrimes(ulong count)
        {
	        ulong nextPrime = 1;
	        for (ulong i = 1; i <= count; i++)
	        {
		        nextPrime = GetNextPrime(nextPrime);
		        yield return nextPrime;
	        }
        }
		
		public static IEnumerable<ulong> GetFirstNMersennes(ulong count)
		{
			ulong nextMersenne = 1;
			for (ulong i = 1; i <= count; i++)
			{
				nextMersenne = GetNextMersenne(nextMersenne);
				yield return nextMersenne;
			}
		}

		internal static ulong GetNextPrime(ulong n)
		{
			if (n <= 1)
			{
				return 2;
			}
			
			if (n % 2 == 0)
			{
				n--;
			}
			
			do
			{
				n += 2;
			} while (!n.IsPrime());
			
			return n;
		}
		
		private static ulong GetNextMersenne(ulong n)
		{
			ulong test = 2;
			do
			{
				test *= 2;
			} while (n >= test - 1);

			return test - 1;
		}
	}
}