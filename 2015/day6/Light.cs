using System;

namespace aoc.y2015.day6 {

    public class Light {

        public bool lightsOn {get; set;} = false;

        public int brightness {get; set;} = 0;
        

        public void toggleLight() {
            //Change light
            lightsOn = !lightsOn;
        }

        public void increaseBrightness(int amount) {
            brightness += amount;
        }
        public void decreaseBrightness(int amount) {
            brightness -= amount;
            if(brightness < 0) {
                brightness = 0;
            }
        }

    }

}