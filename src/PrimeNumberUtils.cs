using System;
using System.Collections.Generic;

namespace PrimeNumberCalc
{
	public static class PrimeNumberUtils
	{ 
		public static bool IsPrime(ulong numberToTest)
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

        public static Dictionary<ulong, uint> GetPrimeFactorization(ulong n)
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

        public static ulong GetNextPrime(ulong n)
        {
	        do
	        {
		        n++;
	        } while (!IsPrime(n));
	        return n;
        }
	}
}