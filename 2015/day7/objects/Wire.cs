using System;

namespace aoc.y2015.day7.objects {

    public class Wire {

        private LogicGate logicGate;

        private bool valueCalculated = false;
        private ushort value;
        private string id;

        public Wire(LogicGate logicGate, string id) {
            this.logicGate = logicGate;
            this.id = id;
        }

        public ushort GetValue(WireConstructor constructor) {
            if(!valueCalculated) {
                value = logicGate.CalculateValue(constructor);
                valueCalculated = true;
            }
            return value;
        }

    }

}