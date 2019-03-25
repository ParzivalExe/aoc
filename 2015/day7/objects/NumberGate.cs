namespace aoc.y2015.day7.objects {

    public class NumberGate : LogicGate
    {

        public ushort number {get; set;}

        public NumberGate(ushort number) {
            this.number = number;
        }

        public ushort CalculateValue(WireConstructor constructor) {
            return number;
        }
    }

}