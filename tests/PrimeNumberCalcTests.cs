using System;
using System.Collections.Generic;
using System.Linq;
using fenumbler.PrimeUtilties;
using Xunit;

namespace PrimeNumberCalc.Tests
{
    public class PrimeNumberCalcTests
    {
        [Fact]
        public void OneIsNotAPrimeNumber()
        {
            var actual = PrimeUtilties.IsPrime(1);
            Assert.False(actual);
        }
        
        [Fact]
        public void TwoIsAPrimeNumber()
        {
            var actual = PrimeUtilties.IsPrime(2);
            Assert.True(actual);
        }
        
        [Fact]
        public void OneHundredIsNotAPrimeNumber()
        {
            var actual = PrimeUtilties.IsPrime(100);
            Assert.False(actual);
        }
        
        [Fact]
        public void FortyNineIsNotAPrimeNumber()
        {
            var actual = PrimeUtilties.IsPrime(49);
            Assert.False(actual);
        }

        [Fact]
        public void HundredthPrimeNumberIs541()
        {
            var actual = PrimeUtilties.GetFirstNPrimes(100);
            ulong expected = 541;
            Assert.Equal(expected, actual.Last());
        }
        
        [Fact]
        public void VsaucePrime()
        {
            var actual = PrimeUtilties.GetFirstNPrimes(3336);
            ulong expected = 30941;
            Assert.Equal(expected, actual.Last());
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 5)]
        [InlineData(5, 7)]
        [InlineData(49, 53)]
        public void GetNextPrimeReturnsCorrectValue(ulong input, ulong expected)
        {
            var actual = PrimeUtilties.GetNextPrime(input);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_10()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {2, 1},
                {5, 1}
            };

            var actual = PrimeUtilties.GetPrimeFactorization(10);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_11()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {11, 1}
            };

            var actual = PrimeUtilties.GetPrimeFactorization(11);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_25()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {5, 2}
            };

            var actual = PrimeUtilties.GetPrimeFactorization(25);
            
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

            var actual = PrimeUtilties.GetPrimeFactorization(30);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_250()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {2, 1},
                {5, 3}
            };

            var actual = PrimeUtilties.GetPrimeFactorization(250);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PF_Of_256()
        {
            var expected = new Dictionary<ulong, uint>
            {
                {2, 8}
            };

            var actual = PrimeUtilties.GetPrimeFactorization(256);
            
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

            var actual = PrimeUtilties.GetPrimeFactorization(420);
            
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

            var actual = PrimeUtilties.GetPrimeFactorization(999);
            
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

            var actual = PrimeUtilties.GetPrimeFactorization(7546);
            
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

            var actual = PrimeUtilties.GetPrimeFactorization(34643);
            
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

            var actual = PrimeUtilties.GetPrimeFactorization(11111111111111111111);
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(7, true)]
        [InlineData(15, true)]
        [InlineData(16, false)]
        [InlineData(22, false)]
        [InlineData(31, true)]
        [InlineData(33, false)]
        [InlineData(255, true)]
        [InlineData(256, false)]
        [InlineData(257, false)]
        [InlineData(ulong.MaxValue, true)]
        [InlineData(ulong.MaxValue - 1, false)]
        public void IsMersenneNumberTestIsValid(ulong test, bool expected)
        {
            var actual = test.IsMersenneNumber();
            Assert.Equal(expected, actual);
        }
    }
}
