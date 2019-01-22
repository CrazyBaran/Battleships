using Shouldly;
using System;
using Xunit;

namespace Battleships.Tests
{
    public class LetterToNumberConverterTests
    {
        [Theory]
        [InlineData('a', 1)]
        [InlineData('A', 1)]
        [InlineData('Z', 26)]
        [InlineData('$', null)]
        public void ReturnsExpectedResult(char letter, int? expectedResult)
        {
            letter.ToNumber().ShouldBe(expectedResult);
        }
    }
}
