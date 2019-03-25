using System;

namespace aoc.y2015.day7.objects {

    public class LShiftGate : LogicGate {

        private string input;
        private int value;

        public LShiftGate(string input, int value) {
            this.input = input;
            this.value = value;
        }

        public ushort CalculateValue(WireConstructor constructor) {
            ushort firstValue = constructor.GetWireWithId(input).GetValue(constructor);

            return (ushort) ((int) firstValue << value);
        }

    }

}