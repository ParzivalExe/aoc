using System;
using Xunit;
using aoc.api;
using aoc.y2015.day2;

namespace aoc.test.y2015.day2 {

    public class Day2 {

        [Fact]
        public void PartOne() {
            Present[] presents = GetPresentsFromFile("tests/2015/day2/Presents.Input.txt");

            Console.WriteLine("WrappingPaper: " + PresentCalculator.CalculateWrappingPaper(presents));
        }

        [Fact]
        public void PartTwo() {
            Present[] presents = GetPresentsFromFile("tests/2015/day2/Presents.Input.txt");

            Console.WriteLine("Ribbon: " + PresentCalculator.CalculateRibbon(presents));
        }

    
        private Present[] GetPresentsFromFile(string path) {
            string[] presentsString = FileReader.ReadFile(path);
            Present[] presents = new Present[presentsString.Length];
            for(int i = 0; i < presentsString.Length; i++) {
                presents[i] = new Present(presentsString[i]);
            }
            return presents;
        }


    }

}