using System;
using Xunit;
using aoc.api;
using aoc.y2015.day6;

namespace aoc.test.y2015.day6 {

    public class Day6 {

        [Theory]
        [InlineData("tests/2015/day6/lightCommandsTest.Input.txt", 4)]
        public void PartOne(string path, int result) {
            string[] commands = FileReader.ReadFile(path);
            Grid grid = new Grid(1000, 1000);

            foreach(string command in commands) {
                grid.PerformCommand(command);
            }

            Assert.Equal(result, grid.GetAmountOfLightsInState(true));
        }

    }

}