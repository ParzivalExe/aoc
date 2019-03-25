using System;
using Xunit;
using aoc.api;

namespace aoc.test.y2015.day8 {

    public class Day8 {

        [Theory]
        [InlineData("tests/2015/day8/stringListTest.Input.txt", 0)]
        public void PartOne(string path, int result) {
            string[] strings = FileReader.ReadFile(path);
            int codeAmount = 0;
            int memoryAmount = 0;
            foreach(string countString in strings) {
                codeAmount += countString.Length;
            }


            Assert.Equal(result, codeAmount);
        }

    }

}