using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc.y2015.day2 {
    public class PresentCalculator {
        
        public Present present {get; private set;}

        public PresentCalculator(string dimension) {
            this.present = Present.CreatePresentFromDimention(dimension);
        }

        private IEnumerable<int> CalculateSurfaces() {
            yield return present.Width * present.Height;
            yield return present.Height * present.Length;
            yield return present.Width * present.Length;
            yield return present.Width * present.Height;
            yield return present.Height * present.Length;
            yield return present.Width * present.Length;
        }

        private int CalculateSmallestCircumference() {
            var edges = new List<int>() {present.Width, present.Height, present.Length};
            var orderedCircumferences = edges
                .OrderBy(edge => edge);
            return 2 * (orderedCircumferences.ElementAt(0) + orderedCircumferences.ElementAt(1));
        }

        public int CalculateTotalSurface() {
            IEnumerable<int> surfaces = CalculateSurfaces();
            return surfaces.Sum() + surfaces.Min();
        }

        public int CalculateRibbon() {
            return CalculateSmallestCircumference() + present.Volume;
        }


    }
}