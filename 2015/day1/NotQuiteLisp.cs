using System.Linq;
using aoc.api;

namespace aoc.y2015.day1
{

    public static class NotQuiteLisp {

        public static int GetFloor(string instructions) =>
            instructions
                .Select(CommandToMovement)
                .Sum();

        public static int FindPositionOfBasement(string instructions) => 
            instructions
                .Select(CommandToMovement)
                .AggregatingTakeWhile(
                    0, 
                    (accu, current) => accu + current, 
                    (accu, current) => IsAboveBasement(accu))
                .Count();
        

        private static int CommandToMovement(char command) =>
            (command == '(') ? +1 : -1;

        private static bool IsAboveBasement(int floor) =>
            floor >= 0;
    }
}