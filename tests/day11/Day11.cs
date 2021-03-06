using System;
using Xunit;
using aoc.y2015.day11;

namespace aoc.test.y2015.day11 {

    public class Day11 {


        [Fact]
        public void PartOne() {
            Assert.Equal("vzbxxyzz", PasswordGenerator.GetNextPasswortFrom("vzbxkghb"));
        }

        [Fact]
        public void PartTwo() {
            Assert.Equal("vzcaabcc", PasswordGenerator.GetNextPasswortFrom("vzbxkghb", 2));
        }


        [Theory]
        [InlineData("abcdefgh", "abcdffaa")]
        [InlineData("ghijklmn", "ghjaabcc")]
        public void PartOneTest(string startingPassword, string expectedResult) {
            Assert.Equal(expectedResult, PasswordGenerator.GetNextPasswortFrom(startingPassword));
        }


    }

}