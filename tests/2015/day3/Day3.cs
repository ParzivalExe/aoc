using System;
using Xunit;
using aoc.api;
using aoc.y2015.day3;

namespace aoc.test.y2015.day3 {

    public class Day3 {

        [Fact]
        public void PartOne() {
            string path = FileReader.ReadFile("tests/2015/day3/delivery.Input.txt")[0];

            MovementEngine engine = new MovementEngine();
            engine.goPath(path, 1);
            Assert.Equal(2565, engine.usedPositions.Count);
        }

        [Fact]
        public void PartTwo() {
            string path = FileReader.ReadFile("tests/2015/day3/delivery.Input.txt")[0];

            MovementEngine engine = new MovementEngine();
            engine.goPath(path, 2);
            Assert.Equal(2639, engine.usedPositions.Count);
        }

        [Theory]
        [InlineData("^>v<", 4)]
        public void PartOneTest(string path, int countResult) {
            MovementEngine engine = new MovementEngine();
            engine.goPath(path, 1);
            Assert.Equal(countResult, engine.usedPositions.Count);
        }


        [Theory]
        [InlineData("^>v<", 3)]
        public void PartTwoTest(string path, int countResult) {
            MovementEngine engine = new MovementEngine();
            engine.goPath(path, 2);
            Assert.Equal(countResult, engine.usedPositions.Count);
        }


        

    }

}