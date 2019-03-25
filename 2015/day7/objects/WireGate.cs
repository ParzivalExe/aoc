namespace aoc.y2015.day7.objects {

    public class WireGate : LogicGate
    {

        public string input {get; set;}

        public WireGate(string input) {
            this.input = input;
        }

        public ushort CalculateValue(WireConstructor constructor) {
            return constructor.GetWireWithId(input).GetValue(constructor);
        }
    }

}