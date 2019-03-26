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
            // engine.goPath(path, 1);
            // Console.WriteLine("Amount of Houses Santa has delivered to: " + engine.usedPositions.Count);

            // engine.goPath(path, 2);
            // Console.WriteLine("amoutn of Houses Santa and Robo has delivered to: " + engine.usedPositions.Count);
        }
        

    }

}