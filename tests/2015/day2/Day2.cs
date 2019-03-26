using System;
using System.Linq;
using Xunit;
using aoc.api;
using aoc.y2015.day2;

namespace aoc.test.y2015.day2 {

    public class Day2 {

        [Fact]
        public void PartOne() {
            string[] presents = GetPresentsFromFile("tests/2015/day2/Presents.Input.txt");

            Assert.Equal(1598415, presents.Select(present => Present.CalculateSurface(present)).Sum());
        }

        [Fact]
        public void PartTwo() {
            string[] presents = GetPresentsFromFile("tests/2015/day2/Presents.Input.txt");

            Assert.Equal(3812909, presents.Select(present => Present.CalculateRibbon(present)).Sum());
        }

        [Theory]
        [InlineData("2x3x4", 58)]
        [InlineData("1x1x10", 43)]
        public void PartOneTest(string presentDimensions, int result) {
            Assert.Equal(result, Present.CalculateSurface(presentDimensions));
        }

        [Theory]
        [InlineData("2x3x4", 34)]
        [InlineData("1x1x10", 14)]
        [InlineData("3x3x2", 28)]
        public void PartTwoTest(string presentDimensions, int result) {
            Assert.Equal(result, Present.CalculateRibbon(presentDimensions));
        }

    
        private string[] GetPresentsFromFile(string path) =>
            FileReader.ReadFile(path);



    }

}