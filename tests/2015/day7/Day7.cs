using System;
using Xunit;

using aoc.y2015.day7.objects;
using aoc.y2015.day7;
using aoc.api;

namespace aoc.test.y2015.day7 {

    public class Day7 {

        [Theory]
        [InlineData("tests/2015/day7/construction.Input.txt", 3176)]
        [InlineData("tests/2015/day7/constructionPartTwo.Input.txt", 14710)]
        public void PartOneAndTwo(string path, int result) {
            
            string[] constructionPlan = FileReader.ReadFile(path);

            WireConstructor constructor = new WireConstructor(constructionPlan);

            Assert.Equal(result, constructor.GetValueForWire("a", "root"));
        }

    }

}