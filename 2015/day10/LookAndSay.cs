using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using aoc.api;

namespace aoc.y2015.day10 {

    public static class LookAndSay {

        // public static int CalculateNumberLength(ulong startingNumber, int counts) {
        //     string number = startingNumber.ToString();
        //     for (int i = 0; i < counts; i++) {
        //         System.Console.WriteLine("i: " + i);
        //         List<int> digits = number.ToString().Select(digit => int.Parse(digit.ToString())).ToList();
        //         digits.Add(0);
        //         string newNumber = "";
        //         int digitRepeatCount = 0;
        //         int repeatingDigit = -1;
        //         foreach (int digit in digits) {
        //             if (digit == repeatingDigit) {
        //                 digitRepeatCount++;
        //             }
        //             else {
        //                 //Save old data
        //                 if (digitRepeatCount > 0) {
        //                     newNumber = newNumber.Substring(0, newNumber.Length - 1) + digitRepeatCount + newNumber.Substring(newNumber.Length - 1);
        //                 }
        //                 if (digit != 0) {
        //                     newNumber = newNumber + digit.ToString();
        //                     //collect new data
        //                     repeatingDigit = digit;
        //                     digitRepeatCount = 1;
        //                 }
        //             }
        //         }
        //         number = newNumber;
        //     }
        //     return number.Length;
        // }

        public static int CalculateNumberLengthNew(ulong startingNumber, int counts) {
            string number = startingNumber.ToString();
            for (int i = 0; i < counts; i++) {
                number = CalculateNewNumberString(number);
                System.Console.WriteLine("i: " + i + ", numbers: " + number);
            }
            return number.Length;
        }

        public static string CalculateNewNumberString(string oldNumberString) =>
                oldNumberString
                    .Aggregate((seed: new StringBuilder(), count: 0, repeat: 'n', index: 0), (accu, next) => CreateNewNumberStringFromParams(accu, next, oldNumberString.Length)).seed.ToString();

        private static (StringBuilder, int, char, int) CreateNewNumberStringFromParams((StringBuilder seed, int count, char repeat, int index) accu, char next, int oldNumberLength) {
            if(accu.seed.ToString().LastOrDefault() == next) {
                if(accu.index >= oldNumberLength - 1) {
                    accu.seed.Insert(accu.seed.Length - 1, accu.count+1);
                }
                return (accu.seed, accu.count+1, accu.repeat, accu.index+1);
            }else {
                if (accu.index != 0) {
                    accu.seed.Insert(accu.seed.Length - 1, accu.count);
                }
                accu.seed.Append(next);
                if (accu.index >= oldNumberLength - 1) {
                    accu.seed.Insert(accu.seed.Length - 1, 1);
                }
                return (accu.seed, 1, next, accu.index + 1);
            }
        }


    }

}