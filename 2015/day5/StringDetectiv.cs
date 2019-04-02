using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc.y2015.day5 {

    public class StringDetectiv {

        string usedString {get; set;}

        public StringDetectiv(string usedString) {
            this.usedString = usedString;
        }

        public bool ContainsStringPart(string part) {
            return usedString.Contains(part);
        }
        public bool ContainsOneOfStringParts(string[] parts) {
            int containsCount = 0;
            foreach(string part in parts) {
                if(ContainsStringPart(part)) {
                    containsCount++;
                }
            }
            return containsCount > 0;
        }

        public int NumberOfChars(char[] searchChars) {
            int count = 0;
            for(int i = 0; i < searchChars.Length; i++) {
                count += usedString.Count(f => f == searchChars[i]);
            }
            return count;
        }
        public int NumberOfVowels() {
            return NumberOfChars(new Char[] {'a', 'e', 'i', 'o', 'u'});
        }

        public int NumberOfDoubleLetters() {
            char lastCharacter = ' ';
            int count = 0;
            foreach(char character in usedString) {
                if(character == lastCharacter) {
                    count++;
                }
                lastCharacter = character;
            }
            return count;
        }

        public int NumberOfLetterFormationXYX() {
            int count = 0;
            char[] characters = usedString.ToCharArray();
            List<char> formationBuffer = new List<char>();
            foreach(char character in characters) {
                if(formationBuffer.Count == 0) {
                    formationBuffer.Add(character);
                }else{
                    if(character != formationBuffer.Last() && formationBuffer.Count < 3) {
                        if(formationBuffer.Count == 2) {
                            if (formationBuffer[0] == character) {
                                //FormationBuffer is Finished with xyx-Formation -> clear Buffer and count++;
                                formationBuffer.Clear();
                                count++;
                            }else{
                                //FormationBuffer is at last letter but this one doesn't apply to first one -> remove first and add this one
                                formationBuffer.RemoveAt(0);
                                formationBuffer.Add(character);
                            }
                        }else{
                            //FormationBuffer is at 2nd letter and this letter is different than the first one -> Add letter to FormationBuffer
                            formationBuffer.Add(character);
                        }
                    }else{
                        //FormationBuffer is above size 3 or this letter is like the last one -> Remove first and add this one
                        formationBuffer.RemoveAt(0);
                        formationBuffer.Add(character);
                    }
                }
            }
            return count;
        }

        public int NumberOfLetterFormationXYRepeating() {
            int count = 0;
            char[] character = RemoveTreeTimesRepeat(usedString.ToCharArray());
            List<string> formations = new List<string>();
            for(int i = 1; i < character.Length; i++) {
                string formation = character[i-1].ToString() + character[i].ToString();
                if(!formations.Contains(formation)) {
                    formations.Add(formation);
                }else{
                    count++;
                }
            }
            return count;
        }

        private char[] RemoveTreeTimesRepeat(char[] characters) {
            List<char> newCharacters = characters.ToList();
            int repeatTimes = 0;
            char repeatingChar = ' ';
            for(int i = 0; i < characters.Length; i++) {
                if(repeatingChar == characters[i]) {
                    switch(repeatTimes) {
                        case 1: {
                            repeatTimes++;
                            break;
                        }
                        case 2: {
                            newCharacters.RemoveAt(i-2);
                            newCharacters.RemoveAt(i-1);
                            newCharacters.RemoveAt(i);
                            repeatTimes = 0;
                            repeatingChar = ' ';
                            break;
                        }
                    }
                }else{
                    repeatTimes = 1;
                    repeatingChar = characters[i];
                }
            }
            return newCharacters.ToArray();
        }


        


    }

}