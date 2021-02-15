using System;
using System.Collections.Generic;

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

		            var isPrime = test.IsPrime();
		            if (test == 1 || isPrime)
		            {
			            done = true;
			            if (isPrime)
			            {
				            uint newPow = 1;
				            if (result.Key == test)
				            {
					            newPow = result.Value + 1;
				            }
				            else
				            {
					            yield return result;
				            }
				            result = new KeyValuePair<ulong, uint>(test, newPow);
			            }
		            }
		            else
		            {
			            pow = 1;
			            factor = GetNextPrime(factor);
		            }
	            
		            yield return result;
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

		private static ulong GetNextPrime(ulong n)
		{
			do
			{
				n++;
			} while (!n.IsPrime());
			return n;
		}
	}
}