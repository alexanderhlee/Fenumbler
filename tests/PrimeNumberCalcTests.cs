using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PrimeNumberCalc.Tests
{
    public class PrimeNumberCalcTests
    {
        [Fact]
        public void OneIsNotAPrimeNumber()
        {
            var actual = PrimeNumberUtils.IsPrime(1);
            Assert.False(actual);
        }
        
        [Fact]
        public void TwoIsAPrimeNumber()
        {
            var actual = PrimeNumberUtils.IsPrime(2);
            Assert.True(actual);
        }
        
        [Fact]
        public void OneHundredIsNotAPrimeNumber()
        {
            var actual = PrimeNumberUtils.IsPrime(100);
            Assert.False(actual);
        }
        
        [Fact]
        public void FortyNineIsNotAPrimeNumber()
        {
            var actual = PrimeNumberUtils.IsPrime(49);
            Assert.False(actual);
        }

        [Fact]
        public void HundredthPrimeNumberIs541()
        {
            var actual = PrimeNumberUtils.GetFirstNPrimes(100);
            ulong expected = 541;
            Assert.Equal(expected, actual.Last());
        }
        
        [Fact]
        public void VsaucePrime()
        {
            var actual = PrimeNumberUtils.GetFirstNPrimes(3336);
            ulong expected = 30941;
            Assert.Equal(expected, actual.Last());
        }
        
        [Fact]
        public void PF_Of_10()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {2, 1},
                {5, 1}
            };

            var actual = PrimeNumberUtils.GetPrimeFactorization(10);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_11()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {11, 1}
            };

            var actual = PrimeNumberUtils.GetPrimeFactorization(11);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_25()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {5, 2}
            };

            var actual = PrimeNumberUtils.GetPrimeFactorization(25);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PF_Of_30()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {2, 1},
                {3, 1},
                {5, 1}
            };

            var actual = PrimeNumberUtils.GetPrimeFactorization(30);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_256()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {2, 8}
            };

            var actual = PrimeNumberUtils.GetPrimeFactorization(256);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_420()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {2, 2},
                {3, 1},
                {5, 1},
                {7, 1}
            };

            var actual = PrimeNumberUtils.GetPrimeFactorization(420);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_999()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {3, 3},
                {37, 1}
            };

            var actual = PrimeNumberUtils.GetPrimeFactorization(999);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_7546()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {2, 1},
                {7, 3},
                {11, 1}
            };

            var actual = PrimeNumberUtils.GetPrimeFactorization(7546);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_34643()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {7, 3},
                {101, 1}
            };

            var actual = PrimeNumberUtils.GetPrimeFactorization(34643);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_11111111111111111111()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {11, 1},
                {41, 1},
                {101, 1},
                {271, 1},
                {3541, 1},
                {9091, 1},
                {27961, 1}
            };

            var actual = PrimeNumberUtils.GetPrimeFactorization(11111111111111111111);
            
            Assert.Equal(expected, actual);
        }

    }
}
