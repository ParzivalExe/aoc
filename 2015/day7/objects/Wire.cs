using System;

namespace aoc.y2015.day7.objects {

    public class Wire {

        private LogicGate logicGate;

        private bool valueCalculated = false;
        private ushort value;

        public Wire(LogicGate logicGate) {
            this.logicGate = logicGate;
        }

        public ushort GetValue(WireConstructor constructor) {
            if(!valueCalculated) {
                value = logicGate.CalculateValue(constructor);
            }
            return value;
        }

    }

}