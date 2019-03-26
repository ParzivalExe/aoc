using System;
using System.Linq;
using Xunit;
using aoc.api;
using aoc.y2015.day2;

namespace aoc.test.y2015.day2 {

    public class Day2 {

        [Fact]
        public void PartOne() {
            var dimensions = GetPresentsFromFile("tests/2015/day2/Presents.Input.txt");

            Assert.Equal(1598415, dimensions.Select(CalculcateSurface).Sum());
        }

        [Fact]
        public void PartTwo() {
            var dimensions = GetPresentsFromFile("tests/2015/day2/Presents.Input.txt");

            Assert.Equal(3812909, dimensions.Select(CalculateRibbon).Sum());
        }

        [Theory]
        [InlineData("2x3x4", 58)]
        [InlineData("1x1x10", 43)]
        public void PartOneTest(string dimension, int expectedResult) {
            Assert.Equal(expectedResult, CalculcateSurface(dimension));
        }

        [Theory]
        [InlineData("2x3x4", 34)]
        [InlineData("1x1x10", 14)]
        [InlineData("3x3x2", 28)]
        public void PartTwoTest(string dimension, int expectedResult) {
            Assert.Equal(expectedResult, CalculateRibbon(dimension));
        }

        public int CalculcateSurface(string dimension) =>
            new PresentCalculator(dimension).CalculateTotalSurface();


        public int CalculateRibbon(string dimension) =>
            new PresentCalculator(dimension).CalculateRibbon();
    
        private string[] GetPresentsFromFile(string path) =>
            FileReader.ReadFile(path);



    }

}