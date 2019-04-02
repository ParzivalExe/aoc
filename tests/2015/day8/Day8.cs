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
            Assert.Equal(expectedResult, StringLengthCalculator.CalculateDifferenceBetweenCodeAndMemory(FileReader.ReadFile(path)));
        }

        [Theory]
        [InlineData("tests/2015/day8/stringList.Input.txt", 2085)]
        public void PartTwo(string path, int expectedResult) {
            Assert.Equal(expectedResult, StringLengthCalculator.CalculateDifferenceBetweenEncodeAndCode(FileReader.ReadFile(path)));
        }

        [Theory]
        [InlineData("tests/2015/day8/stringListTest.Input.txt", 1)]
        public void PartOneTest(string path, int result) {
            string lengthString = FileReader.ReadFile(path)[0];
            int newLength = StringLengthCalculator.GetInMemoryLength(lengthString);
            Assert.Equal(result, newLength);
        }

        [Theory]
        [InlineData("tests/2015/day8/stringListTest.Input.txt", 5)]
        public void PartTwoTest(string path, int result) {
            string lengthString = FileReader.ReadFile(path)[0];
            int stringLength = lengthString.Length;
            int stringLengthWithEscapeSequences = StringLengthCalculator.AddEscapeSequencesAndGetLength(lengthString);
            Assert.Equal(result, stringLengthWithEscapeSequences - stringLength);
        }


    }

}