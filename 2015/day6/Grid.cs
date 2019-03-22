using System;
using System.Collections.Generic;

namespace aoc.y2015.day6 {

    public class Grid {

        private const int LOC_COMMAND = 0;
        private const int LOC_START_POSITION = 1;
        private const int LOC_END_POSITION = 2;

        private const string CMD_TURN_ON = "turn_on";
        private const string CMD_TURN_OFF = "turn_off";
        private const string CMD_TOGGLE = "toggle";

        public Light[,] lights;

        public Grid(int width, int height) {
            //Create all lights
            lights = new Light[height, width];
            for(int y = 0; y < height; y++) {
                for(int x = 0; x < width; x++) {
                    lights[y, x] = new Light();
                }
            }
        }

        private void ToggleLights(int xStart, int yStart, int xEnd, int yEnd) {
            Light[,] toggleLights = GetAllLightsInArea(xStart, yStart, xEnd, yEnd);
            for(int y = 0; y < toggleLights.GetLength(0); y++) {
                for(int x = 0; x < toggleLights.GetLength(1); x++) {
                    toggleLights[y, x].toggleLight();
                }
            }
        }

        private void ChangeLightsTo(int xStart, int yStart, int xEnd, int yEnd, bool lightsOn) {
            Light[,] turnOnLights = GetAllLightsInArea(xStart, yStart, xEnd, yEnd);
            int testLength = turnOnLights.GetLength(1);
            for(int y = 0; y < turnOnLights.GetLength(0); y++) {
                for(int x = 0; x < turnOnLights.GetLength(1); x++) {
                    turnOnLights[y, x].lightsOn = lightsOn;
                }
            }
        }

        private Light[,] GetAllLightsInArea(int xStart, int yStart, int xEnd, int yEnd) {
            Light[,] selectedLights = new Light[xEnd-xStart+1, yEnd-yStart+1];
            int xRelative = 0;
            int yRelative = 0;
            for(int y = yStart; y <= yEnd; y++) {
                for(int x = xStart; x <= xEnd; x++) {
                    selectedLights[yRelative, xRelative] = this.lights[y, x];
                    xRelative++;
                }
                xRelative = 0;
                yRelative++;
            }
            return selectedLights;
        }

        public int GetAmountOfLightsInState(bool lightsOn) {
            int count = 0;
            for(int y = 0; y < lights.GetLength(0); y++) {
                for(int x = 0; x < lights.GetLength(0); x++) {
                    if(lights[y, x].lightsOn == lightsOn) {
                        count++;
                    }
                }
            }
            return count;
        }

        public void PerformCommand(string command) {
            string[] splitCommand = SplitCommand(command);
            int xStart = GetPositionFromString(splitCommand[LOC_START_POSITION])[0];
            int yStart = GetPositionFromString(splitCommand[LOC_START_POSITION])[1];
            int xEnd = GetPositionFromString(splitCommand[LOC_END_POSITION])[0];
            int yEnd = GetPositionFromString(splitCommand[LOC_END_POSITION])[1];

            if(splitCommand[LOC_COMMAND].Equals(CMD_TURN_ON)) {
                ChangeLightsTo(xStart, yStart, xEnd, yEnd, true);
            }else if(splitCommand[LOC_COMMAND].Equals(CMD_TURN_OFF)) {
                ChangeLightsTo(xStart, yStart, xEnd, yEnd, false);
            }else if(splitCommand[LOC_COMMAND].Equals(CMD_TOGGLE)) {
                ToggleLights(xStart, yStart, xEnd, yEnd);
            }
        }

        private string[] SplitCommand(string command) {
            List<string> splitCommand = new List<string>(command.Split(' '));
            //turn on and turn off must be converted to turn_on and turn_off
            if(splitCommand.Count == 5) {
                if(splitCommand[1].Equals("on")) {
                    splitCommand[0] = CMD_TURN_ON;
                }else if(splitCommand[1].Equals("off")) {
                    splitCommand[0] = CMD_TURN_OFF;
                }else{
                    throw new ArgumentException("The command is not right because the length is to high without on or off at 2. position");
                }
                splitCommand.RemoveAt(1);
            }else if(splitCommand.Count == 4 && splitCommand[LOC_COMMAND].Equals("toggle")) {
                splitCommand[LOC_COMMAND] = CMD_TOGGLE;
            }
            splitCommand.RemoveAt(2);
            return splitCommand.ToArray();
        }

        /*[0] = x -- [1] = y*/
        private int[] GetPositionFromString(string position) {
            string[] splitPosition = position.Split(',');
            return new int[] {Int32.Parse(splitPosition[0]), Int32.Parse(splitPosition[1])};
        }

    }

}