using System;

namespace aoc.y2015.day7.objects {

    public class RShiftGate : LogicGate {

        private string input;
        private int value;

        public RShiftGate(string input, int value) {
            this.input = input;
            this.value = value;
        }

        public ushort CalculateValue(WireConstructor constructor) {
            ushort firstValue = constructor.GetWireWithId(input).GetValue(constructor);

            return (ushort) ((int) firstValue >> value);
        }

    }

}