using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc.y2015.day3 {

    public class MovementEngine {



        // public List<string> usedPositions {get;} = new List<string>();
        public IEnumerable<Position> usedPositions {get;}

        // public void goPath(string path, int santaCount) {
        //     usedPositions.Clear();

        //     char[] moveCommands = path.ToCharArray();
        //     int santaMovingRightNow = 0;
        //     Position[] actualPositions = createActualPositions(santaCount);

        //     usedPositions.Add(actualPositions[santaMovingRightNow].ToString());

        //     foreach(char moveCommand in moveCommands) {
        //         actualPositions[santaMovingRightNow] = GetPositionWithOffset(actualPositions[santaMovingRightNow], moveCommand);
                
        //         PositionVisited(actualPositions[santaMovingRightNow]);

        //         santaMovingRightNow = increaseIntInsideBoundary(santaMovingRightNow, santaCount);
        //     }
        // }

        public void GoPath(string path, int santaCount) {
            //path.Aggregate()
        }

        /* private IEnumerable<TAccumulate> MoveSanta<TSource, TAccumulate>(
            this IEnumerable<TSource> sources,
            TSource seed, 
            Func<TAccumulate, TSource, TAccumulate> func, 
            Func<TAccumulate, TSource, bool> predicate) {



        } */



        // private int increaseIntInsideBoundary(int oldInt, int boundary) {
        //     if(oldInt < boundary-1) {
        //         oldInt++;
        //     }else{
        //         oldInt = 0;
        //     }
        //     return oldInt;
        // }

        // private Position[] createActualPositions(int size) {
        //     Position[] actualPositions = new Position[size];
        //     for(int i = 0; i < actualPositions.Length; i++) {
        //         actualPositions[i] = new Position(0, 0);
        //     }
        //     return actualPositions;
        // }

        // private void PositionVisited(Position position) {
        //     if(!usedPositions.Contains(position.ToString())) {
        //         usedPositions.Add(position.ToString());
        //     }
        // }

        // private Position GetPositionWithOffset(Position position, char moveCommand) {
        //     switch(moveCommand) {
        //         case '^': {
        //             position.y += 1;
        //             break;
        //         } 
        //         case '>': {
        //             position.x += 1;
        //             break;
        //         }
        //         case 'v': {
        //             position.y += -1;
        //             break;
        //         }
        //         case '<': {
        //             position.x += -1;
        //             break;
        //         }
        //     }
        //     return position;
        // }

    }

}