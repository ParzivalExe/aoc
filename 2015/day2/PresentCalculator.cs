using System;

namespace aoc.y2015.day2 {

    public static class PresentCalculator {

        public static int CalculateWrappingPaper(Present[] presents) {
            int wrappingPaper = 0;
            foreach(Present present in presents) {
                wrappingPaper += CalculateWrappingPaperForPresent(present);
            }
            return wrappingPaper;
        }

        public static int CalculateRibbon(Present[] presents) {
            int ribbon = 0;
            foreach(Present present in presents) {
                ribbon += CalculateRibbonForPresent(present);
            }
            return ribbon;
        }


        private static int CalculateWrappingPaperForPresent(Present present) { 
            int[] surfaces = CalculateSurfaces(present);
            int wrappingPaper = CalculateWrappingPaperForSurfaces(surfaces);
            int wrappingPaperExtra = CalculateMinimum(surfaces);
            return wrappingPaper + wrappingPaperExtra;
        }

        private static int CalculateRibbonForPresent(Present present) {
            int[] borders = new int[] {
                present.x, present.y, present.z
            };
            Array.Sort(borders);
            return borders[0]*2 + borders[1]*2 + CalculateVolume(present);
        }


        private static int[] CalculateSurfaces(Present present) {
            return new int[] {
                present.x * present.y, present.x * present.z, present.y * present.z
            };
        }

        private static int CalculateVolume(Present present) {
            return present.x * present.y * present.z;
        }


        private static int CalculateMinimum(int[] numbers) {
            int minimum = numbers[0];
            foreach(int number in numbers) {
                if(number < minimum) {
                    minimum = number;
                }
            }
            return minimum;
        }

        private static int CalculateWrappingPaperForSurfaces(int[] surfaces) {
            int wrappingPaper = 0;
            foreach(int surface in surfaces) {
                wrappingPaper += surface*2;
            }
            return wrappingPaper;
        }

    }

}