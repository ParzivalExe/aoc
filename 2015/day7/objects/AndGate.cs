using System;

namespace aoc.y2015.day7.objects {

    public class AndGate : LogicGate 
    {

        private string firstInput = null;
        private ushort firstValue = 0;
        private string secondInput;

        public AndGate(string firstInput, string secondInput) {
            this.firstInput = firstInput;
            this.secondInput = secondInput;
        }
        public AndGate(ushort firstValue, string secondInput) {
            this.firstValue = firstValue;
            this.secondInput = secondInput;
        }

        public ushort CalculateValue(WireConstructor constructor)
        {
            if(firstInput != null) {
                firstValue = constructor.GetWireWithId(firstInput).GetValue(constructor);
            }
            ushort secondValue = constructor.GetWireWithId(secondInput).GetValue(constructor);

            return (ushort) ((int) (firstValue) & (int) (secondValue));
        }
    }

}