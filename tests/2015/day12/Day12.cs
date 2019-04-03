using Xunit;
using System;
using aoc.y2015.day12;
using aoc.api;

namespace aoc.test.y2015.day12 {

    public class Day12 {

        [Fact]
        public void PartOne() {
            JSONDecoder jsonDecoder = new JSONDecoder(FileReader.ReadFile("tests/2015/day12/json.Input.txt")[0]);
            Assert.Equal(117966, jsonDecoder.AddValuesTogether());
        }

        [Theory]
        [InlineData("[1,2,3]", 6)]
        [InlineData("{\"a\":2,\"b\":4}", 6)]
        [InlineData("[[[3]]]", 3)]
        [InlineData("{\"a\":{\"b\":4},\"c\":-1}", 3)]
        [InlineData("[1,[2,-2,2],3],{\"a\":-1,\"b\":-2,\"c\":-3}", 0)]
        [InlineData("{\"a\":[-1,1]}", 0)]
        [InlineData("[-1,{\"a\":1}]", 0)]
        [InlineData("[]", 0)]
        [InlineData("{}", 0)]
        public void PartOneTest(string source, int expectedResult) {
            JSONDecoder jsonDecoder = new JSONDecoder(source);
            Assert.Equal(expectedResult, jsonDecoder.AddValuesTogether());
        }   

    }

}