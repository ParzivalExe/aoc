using System;
using System.Linq;
using System.Collections.Generic;
using aoc.api;

namespace aoc.y2015.day11 {

    public class PasswordGenerator {

        public static string GetNextPasswortFrom(string startingPassword) {
            string password = startingPassword;
            do {
                password = IncreasePassword(password);
            } while(!PasswordIsLegit(password) && password.Length == 8);
            return password;
        }

        public static string GetNextPasswortFrom(string startingPassword, int nextCount) {
            string password = startingPassword;
            for(int i = 0; i < nextCount; i++) {
                password = GetNextPasswortFrom(password);
            }
            return password;
        }

        public static bool PasswordIsLegit(string password) =>
            CountOfStringParts(new string[]{"i", "o", "l"}, password) == 0
                && NumberOfDoubleLetters(password) >= 2 
                && NumberOfIncresingThreeLetterFormationsXYZ(password) >= 1
                && NotMoreThanTwoEqualLettersBehind(password);
            

        public static string IncreasePassword(string password) {
            char[] passwordLetters = password.ToArray();
            for(int i = 7; i >= 0; i--) {
                if(passwordLetters[i] < 'z') {
                    passwordLetters[i] = (char) ((int) passwordLetters[i] + 1);
                    return new string(passwordLetters);
                }else{
                    passwordLetters[i] = 'a';
                }
            }
            return null;
        }


        private static int NumberOfDoubleLetters(string password) =>
            password
                .Aggregate((characterNotToUse: "", lastCharacter: ' ', count: 0), (accuTuple, current) => 
                    (current == accuTuple.lastCharacter && !accuTuple.characterNotToUse.Contains(current)) 
                        ? (accuTuple.characterNotToUse + current, ' ', accuTuple.count+1) 
                        : (accuTuple.characterNotToUse, current, accuTuple.count)).count;

        private static int CountOfStringParts(string[] parts, string usedString) =>
            parts.Aggregate(0, (count, part) => usedString.Contains(part) ? count+1 : count);

        private static int NumberOfIncresingThreeLetterFormationsXYZ(string usedString) {
            string buffer = "";
            int count = 0;
            foreach(char character in usedString) {
                if(character == buffer.LastOrDefault()+1) {
                    if(buffer.Length >= 2) {
                        count++;
                    }else{
                        buffer += character;
                    }
                }else{
                    buffer = character.ToString();
                }
            }
            return count;
        }
           

        private static bool NotMoreThanTwoEqualLettersBehind(string usedString) =>
            usedString
                .Substring(2, usedString.Length-2)
                .AggregatingIfFalseBreak((current, index) => 
                    usedString.ElementAt(index) != current          //index +2 -2 = index cause starting at index 2 with .substring (+2) and going back 2 steps (-2) 
                    || usedString.ElementAt(index+1) != current);   //index +2 -1 = index +1 cause starting at index 2 with .substring (+2) and going back 1 step (-1)


    }

}