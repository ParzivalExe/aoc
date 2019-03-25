using System;

namespace aoc.y2015.day7.objects {

    public class NotGate : LogicGate 
    {

        private string input;

        public NotGate(string input) {
            this.input = input;
        }

        public ushort CalculateValue(WireConstructor constructor)
        {
            ushort firstValue = constructor.GetWireWithId(input).GetValue(constructor);

            return (ushort) (~(int) firstValue);
        }
    }

}