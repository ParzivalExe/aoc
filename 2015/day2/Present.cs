using System.Collections.Generic;
using System;
using System.Linq;

namespace aoc.y2015.day2 {

    public class Present {

        public int Width {get; private set;}
        public int Height {get; private set;}
        public int Length {get; private set;}

        public int Volume {get {
            return Width * Height * Length;
        }}

        private Present(IEnumerable<int> lengths) {
            this.Width = lengths.ElementAt(0);
            this.Height = lengths.ElementAt(1);
            this.Length = lengths.ElementAt(2);
        }

        public static Present CreatePresentFromDimention(string dimension) {
            var edges = dimension
                .Split('x')
                .Select(s => Int32.Parse(s));
            return new Present(edges);
        }
    

    }

}