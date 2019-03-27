using System;

namespace aoc.api {

    public static class Helper {

        public static bool StringHasOnlyDigits(string testString) {
            foreach(char character in testString) {
                if(character < '0' || character > '9') {
                    return false;
                }
            }
            return true;
        }


    }

}