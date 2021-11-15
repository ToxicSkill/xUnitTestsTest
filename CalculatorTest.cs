using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace xUnitTest
{
    public class CalculatorTest
    {
        private readonly Calculator _sut;

        public CalculatorTest()
        {
            _sut = new Calculator();
        }

        [Fact(Skip = "This test is broken")]
        public void AddTwoNumbersShouldEqualThayEqual()
        {
            _sut.Add(8);
            _sut.Add(5);
            Assert.Equal(13, _sut.Value);
        }

        [Theory]
        [InlineData(13, 5, 8)]
        [InlineData(0, -3, 3)]
        [InlineData(0, 0, 0)]
        public void AddTwoNumbersShouldEqualThayEqualTheory(
            decimal expected,
            decimal firstAdd,
            decimal secondAdd)
        {
            _sut.Add(firstAdd);
            _sut.Add(secondAdd);
            Assert.Equal(expected, _sut.Value);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void AddManyNumbersShouldEqualThayEqualTheory(decimal expected,
            params decimal[] valuesToAdd)
        {
            foreach (var value in valuesToAdd)
            {
                _sut.Add(value);
            }
            
            Assert.Equal(expected, _sut.Value);
        }
        
        [Theory]
        [ClassData(typeof(DivisionTestData))]
        public void DivideManyNumbersTheory(decimal expected,
            params decimal[] valuesToAdd)
        {
            foreach (var value in valuesToAdd)
            {
                _sut.Divide(value);
            }
            
            Assert.Equal(expected, _sut.Value);
        }
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] {15, new decimal[] {10, 5}};
            yield return new object[] {15, new decimal[] {5, 5, 5}};
            yield return new object[] {20, new decimal[] {2, 10, 8}};
        }
    }

    public class DivisionTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {15, new decimal[] {60, 4}};
            yield return new object[] {1, new decimal[] {5, 5}};
            yield return new object[] {20, new decimal[] {200, 10}};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
 