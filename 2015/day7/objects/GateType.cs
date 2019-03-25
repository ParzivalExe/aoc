using System;

namespace aoc.y2015.day7.objects {
    public enum GateType {
        NUMBER_GATE, WIRE_GATE, AND_GATE, OR_GATE, LSHIFT_GATE, RSHIFT_GATE, NOT_GATE
    }

    public static class GateTypeConvert {
        public static GateType GetGateTypeFromString(string parseString) {
            if(parseString.Equals("AND", StringComparison.InvariantCultureIgnoreCase)) {
                return GateType.AND_GATE;
            }else if(parseString.Equals("OR", StringComparison.InvariantCultureIgnoreCase)) {
                return GateType.OR_GATE;
            }else if(parseString.Equals("LSHIFT", StringComparison.InvariantCultureIgnoreCase)) {
                return GateType.LSHIFT_GATE;
            }else if(parseString.Equals("RSHIFT", StringComparison.InvariantCultureIgnoreCase)) {
                return GateType.RSHIFT_GATE;
            }else if(parseString.Equals("NOT", StringComparison.InvariantCultureIgnoreCase)) {
                return GateType.NOT_GATE;
            }
            return GateType.NUMBER_GATE;
        }
    }
}