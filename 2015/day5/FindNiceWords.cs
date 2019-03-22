namespace aoc.y2015.day5 {

    public static class FindNiceWords {

        public static int FindNiceWordCountInLetter(string[] letter) {
            int count = 0;
            foreach(string word in letter) {
                if(IsWordNice(word)) {
                    count++;
                }
            }
            return count;
        }

        public static int FindNiceWordCountInLetterWithNewMethod(string[] letter) {
            int count = 0;
            foreach(string word in letter) {
                if(IsWordNiceWithNewMethod(word)) {
                    count++;
                }
            }
            return count;
        }

        public static bool IsWordNice(string word) {
            StringDetectiv detectiv = new StringDetectiv(word);
            return (detectiv.NumberOfVowels() >= 3) && (detectiv.NumberOfDoubleLetters() >= 1) && (!detectiv.ContainsOneOfStringParts(new string[] {"ab", "cd", "pq", "xy"}));
        }

        public static bool IsWordNiceWithNewMethod(string word) {
            StringDetectiv detectiv = new StringDetectiv(word);
            return (detectiv.NumberOfLetterFormationXYX() > 0) && (detectiv.NumberOfLetterFormationXYRepeating() > 0);
        }

    }

}