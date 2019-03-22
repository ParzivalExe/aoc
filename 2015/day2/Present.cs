using System;

namespace aoc.y2015.day2 {
    public class Present {

        public int x { get; set;} 
        public int y { get; set;}
        public int z { get; set;}

        public Present(string dimensions) {
            string[] dimensionArray = dimensions.Split('x');
            this.x = Int32.Parse(dimensionArray[0]);
            this.y = Int32.Parse(dimensionArray[1]);
            this.z = Int32.Parse(dimensionArray[2]);
        }
        public Present(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }


    }
}