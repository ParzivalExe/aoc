using System;
using System.Collections.Generic;
using System.Linq;
using aoc.api;

namespace aoc.y2015.day8 {

    public static class StringLengthCalculator {


        public static int GetInCodeLength(string calculateString) =>
            calculateString.Length;


        public static IEnumerable<char> GetInMemoryLength(string calculateString) =>
            calculateString.AggregatingStepOver((current, index) => LookForEscapeSequence(current, calculateString, index));

        private static int LookForEscapeSequence(char lookChar, string wholeString, int index) {
            if(lookChar == '\\' && 
                (wholeString.ElementAt(index-1) == '\\' 
                || wholeString.ElementAt(index+1) == '\"')) {
                return 1;
            }else if(lookChar == 'x' && wholeString.ElementAt(index-1) == '\\' && Uri.IsHexDigit(wholeString.ElementAt(index+1)) && Uri.IsHexDigit(wholeString.ElementAt(index+2))) {
                return 3;
            }
            return 0;
        }

    }

}