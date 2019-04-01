using System;
using System.Linq;
using System.Collections.Generic;
using aoc.api;

namespace aoc.y2015.day10 {

    public static class LookAndSay {

        public static int CalculateNumberLength(ulong startingNumber, int counts) {
            string number = startingNumber.ToString();
            for (int i = 0; i < counts; i++) {
                System.Console.WriteLine("i: " + i);
                List<int> digits = number.ToString().Select(digit => int.Parse(digit.ToString())).ToList();
                digits.Add(0);
                string newNumber = "";
                int digitRepeatCount = 0;
                int repeatingDigit = -1;
                foreach (int digit in digits) {
                    if (digit == repeatingDigit) {
                        digitRepeatCount++;
                    }
                    else {
                        //Save old data
                        if (digitRepeatCount > 0) {
                            newNumber = newNumber.Substring(0, newNumber.Length - 1) + digitRepeatCount + newNumber.Substring(newNumber.Length - 1);
                        }
                        if (digit != 0) {
                            newNumber = newNumber + digit.ToString();
                            //collect new data
                            repeatingDigit = digit;
                            digitRepeatCount = 1;
                        }
                    }
                }
                number = newNumber;
            }
            return number.Length;
        }

        public static int CalculateNumberLengthNew(ulong startingNumber, int counts) {
            string number = startingNumber.ToString();
            for (int i = 0; i < counts; i++) {
                System.Console.WriteLine("i: " + i);
                //SplitAggregate from https://stackoverflow.com/questions/43669019/how-to-split-a-string-every-time-the-character-changes
                number = number
                    .Aggregate(
                        " ", 
                        (seed, next) => seed + (seed.Last() == next ? "" : " ") + next)
                    .Trim()
                    .Split(' ')
                    .Aggregate(
                        "", 
                        (accu, current) => accu + current.Length.ToString() + current.ElementAt(0));
            }
            return number.Length;
        }


    }

}