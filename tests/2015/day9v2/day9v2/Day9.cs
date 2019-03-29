using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using aoc.y2015.day9v2;
using aoc.api;

namespace aoc.test.y2015.day9v2 {

    public class Day9 {

        [Theory]
        [InlineData("tests/2015/day9/routes.Input.txt", 207)]
        public void PartOne(string path, int expectedResult) {
            RoutePlanner planner = new RoutePlanner(FileReader.ReadFile(path));
            Assert.Equal(expectedResult, planner.GetShortestRouteLength());
        }

        [Theory]
        [InlineData("tests/2015/day9/routes.Input.txt", 785)]
        public void PartTwo(string path, int expectedResult) {
            RoutePlanner planner = new RoutePlanner(FileReader.ReadFile(path));
            // Assert.Equal(expectedResult, planner.GetLongestRouteLength());
        }


        [Theory]
        [InlineData("tests/2015/day9/routesTest.Input.txt", 691)]
        public void PartOneTest(string path, int expectedResult) {
            RoutePlanner planner = new RoutePlanner(FileReader.ReadFile(path));
            Assert.Equal(expectedResult, planner.GetShortestRouteLength());
        }

        [Theory]
        [InlineData("tests/2015/day9/routesTest2.Input.txt", 65)]
        public void PartOneTest2(string path, int expectedResult) {
            RoutePlanner planner = new RoutePlanner(FileReader.ReadFile(path));
            Assert.Equal(expectedResult, planner.GetShortestRouteLength());
        }

        [Theory]
        [InlineData("tests/2015/day9/routesTest.Input.txt", 1482)]
        public void PartTwoTest(string path, int expectedResult) {
            RoutePlanner planner = new RoutePlanner(FileReader.ReadFile(path));
            // Assert.Equal(expectedResult, planner.GetLongestRouteLength());
        }

    }
}