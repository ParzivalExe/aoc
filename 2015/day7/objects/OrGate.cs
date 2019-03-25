using System;

namespace aoc.y2015.day7.objects {

    public class OrGate : LogicGate
    {
        private string firstInput;
        private string secondInput;

        public OrGate(string firstInput, string secondInput) {
            this.firstInput = firstInput;
            this.secondInput = secondInput;
        }
        

        public ushort CalculateValue(WireConstructor constructor) {
            ushort firstValue = constructor.GetWireWithId(firstInput).GetValue(constructor);
            ushort secondValue = constructor.GetWireWithId(secondInput).GetValue(constructor);

            return (ushort) ((int) firstValue | (int) secondValue);
        }

    }

}