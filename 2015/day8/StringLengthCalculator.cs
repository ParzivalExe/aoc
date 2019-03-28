using System;
using System.Collections.Generic;
using System.Linq;
using aoc.api;

namespace aoc.y2015.day8 {

    public static class StringLengthCalculator {


        public static int GetInCodeLength(string calculateString) =>
            calculateString.Length;


        // public static IEnumerable<char> GetInMemoryLength(string calculateString) =>
        //     calculateString.AggregatingStepOver((current, index) => LookForEscapeSequence(current, calculateString, index));

        public static int GetInMemoryLength(string calculateString) {
            calculateString = calculateString.Substring(1, calculateString.Length-2);
            return calculateString
                        .AggregatingStepOver(
                            (current, index) => LookForEscapeSequence(current, calculateString, index))
                        .Count();
        }

        public static int AddEscapeSequences(string calculateString) {
            return calculateString
        }

        // private static int LookForEscapeSequence(char lookChar, string wholeString, int index) {
        //     if(lookChar == '\\' && 
        //         (wholeString.ElementAt(index-1) == '\\' 
        //         || wholeString.ElementAt(index+1) == '\"')) {
        //         return 1;
        //     }else if(lookChar == 'x' && wholeString.ElementAt(index-1) == '\\' && Uri.IsHexDigit(wholeString.ElementAt(index+1)) && Uri.IsHexDigit(wholeString.ElementAt(index+2))) {
        //          return 3;
        //     }
        //     return 0;
        // }

        private static (int oversteps, char replacement) LookForEscapeSequence(char lookChar, 
                            string wholeString, int index) {
            if(lookChar == '\\' && wholeString.ElementAt(index+1) == '\\') {
                return (2, '\\');
            }else if(lookChar == '\\' && wholeString.ElementAt(index+1) == '\"') {
                return (2, '\"');
            }else if(lookChar == '\\' && NextDigitsAreHexString(wholeString.Substring(index+1, 3))) {
                return (4, '%');
            }
            return (0, 'N');
        }

        private static bool NextDigitsAreHexString(string toTest) =>
            (toTest.ElementAt(0) == 'x' && Uri.IsHexDigit(toTest.ElementAt(1)) && Uri.IsHexDigit(toTest.ElementAt(2)));

    }

}