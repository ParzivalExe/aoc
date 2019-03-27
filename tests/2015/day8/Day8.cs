using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using aoc.api;
using aoc.y2015.day8;

namespace aoc.test.y2015.day8 {

    public class Day8 {

        [Theory]
        [InlineData("tests/2015/day8/stringList.Input.txt", 1370)]
        public void PartOne(string path, int expectedResult) {
            string[] lengthStrings = FileReader.ReadFile(path);
            int result = lengthStrings
                .Aggregate(
                    0, 
                    (accu, current) => 
                        accu 
                        + StringLengthCalculator.GetInCodeLength(current) 
                        - StringLengthCalculator.GetInMemoryLength(current).Count());

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("tests/2015/day8/stringListTest.Input.txt", 32)]
        public void PartOneTest(string path, int result) {
            string lengthString = FileReader.ReadFile(path)[0];

            string newLengthString = StringLengthCalculator.GetInMemoryLength(lengthString).Aggregate("", (accu, current) => accu + current);

            Assert.Equal(result, newLengthString.Length);
        }

    }

}