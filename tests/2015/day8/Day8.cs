using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using aoc.api;
using aoc.y2015.day8;

namespace aoc.test.y2015.day8 {

    public class Day8 {

        [Theory]
        [InlineData("tests/2015/day8/stringList.Input.txt", 1350)]
        public void PartOne(string path, int expectedResult) {
            string[] lengthStrings = FileReader.ReadFile(path);
            int result = lengthStrings
                .Aggregate(
                    0, 
                    (accu, current) => 
                        accu 
                        + StringLengthCalculator.GetInCodeLength(current) 
                        - StringLengthCalculator.GetInMemoryLength(current));

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("tests/2015/day8/stringList.Input.txt", 0)]
        public void PartTwo(string path, int expectedResult) {
            
        }

        [Theory]
        [InlineData("tests/2015/day8/stringListTest.Input.txt", 29)]
        public void PartOneTest(string path, int result) {
            string lengthString = FileReader.ReadFile(path)[0];

            // string newLengthString = StringLengthCalculator.GetInMemoryLength(lengthString).Aggregate("", (accu, current) => accu + current);
            int newLength = StringLengthCalculator.GetInMemoryLength(lengthString);

            Assert.Equal(result, newLength);
        }

        [Theory]
        [InlineData("tests/2015/day8/stringListTest.Input.txt", 29)]
        public void PartTwoTest(string path, int result) {
            string lengthString = FileReader.ReadFile(path)[0];
            int stringLength = lengthString.Length;
            // string newLengthString = StringLengthCalculator.GetInMemoryLength(lengthString).Aggregate("", (accu, current) => accu + current);
            int newLength = StringLengthCalculator.GetInMemoryLength(lengthString);

            Assert.Equal(result, newLength);
        }


    }

}