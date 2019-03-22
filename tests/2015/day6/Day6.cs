using System;
using Xunit;
using aoc.api;
using aoc.y2015.day6;

namespace aoc.test.y2015.day6 {

    public class Day6 {

        [Theory]
        [InlineData("tests/2015/day6/lightCommandsTest.Input.txt", 1999, 2996002)]
        [InlineData("tests/2015/day6/lightCommands.Input.txt", 400410, 15343601)]
        public void PartOne(string path, int result, int resultBrightness) {
            string[] commands = FileReader.ReadFile(path);
            Grid grid = new Grid(1000, 1000);

            foreach(string command in commands) {
                grid.PerformCommand(command);
            }

            Assert.Equal(result, grid.GetAmountOfLightsInState(true));
            Assert.Equal(resultBrightness, grid.GetTotalBrightness());
        }

    }

}