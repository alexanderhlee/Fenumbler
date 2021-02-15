using System.Collections.Generic;
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
    }
}
