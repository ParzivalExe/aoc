using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc.y2015.day2 {
    public static class Present {
        
        public static IEnumerable<int> CalculateSurfaces((int x, int y, int z) tuple) {
            yield return tuple.x * tuple.y;
            yield return tuple.y * tuple.z;
            yield return tuple.x * tuple.z;
            yield return tuple.x * tuple.y;
            yield return tuple.y * tuple.z;
            yield return tuple.x * tuple.z;
        }

        public static int CalculateVolume(IEnumerable<int> sideLengths) =>
            sideLengths
                .Aggregate((a, b) => a * b);

        public static int CalculateSmallestScope(IEnumerable<int> sides) {
            sides = sides
                .OrderBy(side => side)
                .Select(side => side * 2);
            return sides.ElementAt(0) + sides.ElementAt(1);
        }

        public static IEnumerable<int> GetSideLengthsFromDimensions(string dimensions) =>
            dimensions
                .Split('x')
                .Select(s => Int32.Parse(s));

        public static int CalculateSurface(string dimensions) { 
            var lengths = GetSideLengthsFromDimensions(dimensions);
            IEnumerable<int> surfaces = CalculateSurfaces((lengths.ElementAt(0), lengths.ElementAt(1), lengths.ElementAt(2)));
            return surfaces.Sum() + surfaces.Min();
        }

        public static int CalculateRibbon(string dimensions) {
            var lengths = GetSideLengthsFromDimensions(dimensions);
            return CalculateSmallestScope(lengths) 
                + lengths.ElementAt(0) * lengths.ElementAt(1) * lengths.ElementAt(2);
        }

    }
}