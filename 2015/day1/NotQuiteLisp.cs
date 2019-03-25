using System;
using System.Linq;

namespace aoc.test.y2015.day1 {

    public static class NotQuiteLisp {

        public static int driveElevator(string cmd) =>
            cmd.Select(CommandToMovement).Sum();

        public static int enterBasement(string cmd) {
            char[] moveCommands = cmd.ToCharArray();
            int floor = 0;
            for(int i = 0; i < moveCommands.Length; i++) {
                floor = GetNewFloor(floor, moveCommands[i]);
                if(floor == -1) {
                    return i+1;
                }
            }
            return -1;
        }

        private static int GetNewFloor(int oldFloor, char moveCommand) {
                if(moveCommand == '(') {
                    return oldFloor + 1;
                }else if(moveCommand == ')') {
                    return oldFloor - 1;
                }else{
                    throw new ArgumentException("The char moveCommand is limited to '(' and ')'. You have used " + moveCommand + " instead!");
                }
        }

        private static int CommandToMovement(char command) {
                if(command == '(') {
                    return + 1;
                }else if(command == ')') {
                    return - 1;
                }
                return 0;
        }

    }

}