using System;
using Xunit;
using aoc.api;
using aoc.y2015.day5;

namespace aoc.test.y2015.day5 {

    public class Day5 {

        [Theory]
        [InlineData("tests/2015/day5/letterTest.Input.txt", 2)]
        [InlineData("tests/2015/day5/letter.Input.txt", 236)]
        public void PartOne(string path, int niceOnes) {
            string[] letter = FileReader.ReadFile(path);
            
            Assert.Equal(niceOnes, FindNiceWords.FindNiceWordCountInLetter(letter));
        }

        [Theory]
        [InlineData("tests/2015/day5/letterTestNewMethod.Input.txt", 2)]
        [InlineData("tests/2015/day5/letter.Input.txt", 51)]
        public void PartTwo(string path, int niceOnes) {
            string[] letter = FileReader.ReadFile(path);

            Assert.Equal(niceOnes, FindNiceWords.FindNiceWordCountInLetterWithNewMethod(letter));
        }

    }

}