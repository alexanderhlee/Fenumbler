using System;
using System.Collections.Generic;

namespace PrimeNumberCalc
{
	public static class PrimeNumberUtils
	{ 
		public static bool IsPrime(ulong n)
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

			for (uint i = 7; i < (n / 2); i += 2)
			{
				if (n % i == 0)
				{
					return false;
				}
			}

			return true;
		}

		public static IEnumerable<KeyValuePair<ulong, uint>> GetPrimeFactorization(ulong n)
        {
            uint pow = 1;
            var division = n;
            var result = new KeyValuePair<ulong, uint>(n, 1);
            bool done = false;
            ulong factor = 2;

            do
            {
	            if (division <= 1 || IsPrime(division))
	            {
		            done = true;
		            yield return result;
	            }
	            else
	            {
		            if (division % factor != 0)
		            {
			            pow = 1;
			            factor = GetNextPrime(factor);
		            }
		            else
		            {
			            do
			            {
				            result = new KeyValuePair<ulong, uint>(factor, pow);
				            division /= factor;
				            pow++;
			            } while (division % factor == 0);

			            if (division == 1)
			            {
				            done = true;
			            }
			            else
			            {
				            if (IsPrime(division))
				            {
					            uint newPow = 1;
					            if (result.Key == division)
					            {
						            newPow = result.Value + 1;
					            }
					            else
					            {
						            yield return result;
					            }
					            result = new KeyValuePair<ulong, uint>(division, newPow);
					            done = true;
				            }
				            else
				            {
					            pow = 1;
					            factor = GetNextPrime(factor);
				            }
			            }

			            yield return result;
		            }
	            }
            } while (!done);
        }

        private static ulong GetNextPrime(ulong n)
        {
	        do
	        {
		        n++;
	        } while (!IsPrime(n));
	        return n;
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
	}
}