using System;

namespace aoc.y2015.day9 {

    public class Route {

        public string Location1 {get; private set;}
        public string Location2 {get; private set;}
        public string[] Locations {get {
            return new string[] {Location1, Location2};
        }}
        public int distance {get; private set;}

        public Route(string routeString) {
            string[] routeStringSplit = routeString.Split(' ');
            Location1 = routeStringSplit[0];
            Location2 = routeStringSplit[2];
            distance = Int32.Parse(routeStringSplit[4]);
        }


    }

}