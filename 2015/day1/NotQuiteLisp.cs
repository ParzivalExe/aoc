using System;
using System.Collections.Generic;
using System.Linq;
using aoc.api;

namespace aoc.test.y2015.day1 {

    public static class NotQuiteLisp {

        public static int driveElevator(string cmd) =>
            cmd
                .Select(CommandToMovement)
                .Sum();

        public static int enterBasement(string cmd) => 
            cmd
                .Select(CommandToMovement)
                .AggregatingTakeWhile(
                    1, 
                    (current, accu) => accu + current, 
                    (current, accu) => !IsInKeller(accu))
                .Count();
        
        

        private static int CommandToMovement(char command) {
                if(command == '(') {
                    return + 1;
                }else if(command == ')') {
                    return - 1;
                }
                return 0;
        }

        private static bool IsInKeller(int floor) {
            return floor == -1;
        }


        

    }

}