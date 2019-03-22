using System;
using Xunit;
using aoc.y2015.day4;

namespace aoc.test.y2015.day4 {

    public class Day4 {

        
        [Theory]
        [InlineData("yzbqklnj", "00000")]
        public void PartOne(string key, string firstPart) {
            MD5Calculator md5Calculator = new MD5Calculator();
            int number = md5Calculator.CalculateMD5WithSmallNumber(key, firstPart);

            System.Console.WriteLine("MD5 smallest Number with 00000 in Front: " + number);
        }

        [Theory]
        [InlineData("yzbqklnj", "000000")]
        public void PartTwo(string key, string firstPart) {
            MD5Calculator md5Calculator = new MD5Calculator();
            int number = md5Calculator.CalculateMD5WithSmallNumber(key, firstPart);

            System.Console.WriteLine("MD5 smallest Number with 000000 in Front: " + number);
        }

    }
}