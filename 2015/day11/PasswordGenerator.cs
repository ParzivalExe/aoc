using System;
using System.Linq;
using System.Collections.Generic;

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

        public static bool PasswordIsLegit(string password) {
            if(!ContainsOneOfStringParts(new string[]{"i", "o", "l"}, password)) {
                if(NumberOfDoubleLetters(password) >= 2) {
                    if(NumberOfIncresingThreeLetterFormationsXYZ(password) >= 1) {
                        if(NotMoreThanTwoEqualLettersBehind(password)) {
                                return true;
                        }
                    }
                }
            }
            return false;
        }

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


        private static int NumberOfDoubleLetters(string password) {
            string characterNotToUse = "";
            char lastCharacter = ' ';
            int count = 0;
            foreach(char character in password) {
                if(character == lastCharacter && !characterNotToUse.Contains(character)) {
                    count++;
                    lastCharacter = ' ';
                    characterNotToUse = characterNotToUse + character;
                }else{
                    lastCharacter = character;
                }
            }
            return count;
        }

        private static bool ContainsStringPart(string part, string usedString) {
            return usedString.Contains(part);
        }
        private static bool ContainsOneOfStringParts(string[] parts, string usedString) {
            int containsCount = 0;
            foreach(string part in parts) {
                if(ContainsStringPart(part, usedString)) {
                    containsCount++;
                }
            }
            return containsCount > 0;
        }

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
           

        private static bool NotMoreThanTwoEqualLettersBehind(string usedString) {
            for(int i = 2; i < usedString.Length; i++) {
                char character = usedString.ElementAt(i);
                if(usedString.ElementAt(i-2) == character && usedString.ElementAt(i-1) == character) {
                    return false;
                }
            }
            return true;
        }


    }

}