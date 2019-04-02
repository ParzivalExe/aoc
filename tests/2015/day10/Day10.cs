using Xunit;
using aoc.y2015.day10;

namespace aoc.test.y2015.day10 {

    public class Day10 {


        [Fact]
        public void PartOne() {
            Assert.Equal(492982, LookAndSay.CalculateNumberLengthNew(1321131112, 40));
        }

        [Fact]
        public void PartTwo() {
            Assert.Equal(0, LookAndSay.CalculateNumberLengthNew(1321131112, 50));
        }

        [Theory]
        [InlineData(1, 5, 6)]
        public void PartOneTest(ulong startNumber, int repeates, int expectedResult) {
            Assert.Equal(expectedResult, LookAndSay.CalculateNumberLengthNew(startNumber, repeates));
        }

        [Theory]
        [InlineData("1", "11")]
        [InlineData("11", "21")]
        [InlineData("112", "2112")]
        [InlineData("2112", "122112")]
        [InlineData("1321131112", "11131221133112")]
        public void TestNumberStringCalculation(string stringToCalculate, string expectedResult) {
            Assert.Equal(expectedResult, LookAndSay.CalculateNewNumberString(stringToCalculate));
        }

    }

}