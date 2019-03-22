using System;

namespace aoc.y2015.day6 {

    public class Light {

        public bool lightsOn {get; set;} = false;
        
        public void toggleLight() {
            //Change light
            lightsOn = !lightsOn;
        }

    }

}