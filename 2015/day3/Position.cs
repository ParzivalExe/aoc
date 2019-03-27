using System;

namespace aoc.y2015.day3 {

    public class Position {

        public int x {get; set;}
        public int y {get; set;}

        public Position(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public Position(string positionString) {
            string[] coordinates = positionString.Split(',');
            x = Int32.Parse(coordinates[0]);
            y = Int32.Parse(coordinates[1]);
        }

        public Position ApplyOffset((int xOffset, int yOffset) offsetTuble) {
            x += offsetTuble.xOffset;
            y += offsetTuble.yOffset;
            return this;
        }

        public override string ToString() {
            return x + "," + y;
        }

    }

}