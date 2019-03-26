using System.Collections.Generic;
using System;
using System.Linq;

namespace aoc.y2015.day2 {

    public class Present {

        public int Width {get; set;}
        public int Height {get; set;}
        public int Length {get; set;}

        public Present(IEnumerable<int> lengths) {
            this.Width = lengths.ElementAt(0);
            this.Height = lengths.ElementAt(1);
            this.Length = lengths.ElementAt(2);
        }

    

    }

}