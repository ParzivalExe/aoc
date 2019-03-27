using aoc.y2015.day7.objects;
using System;
using System.Collections.Generic;
using aoc.api;

namespace aoc.y2015.day7 {

    public class WireConstructor {

        public Dictionary<string, Wire> wires = new Dictionary<string, Wire>();

        public WireConstructor(string[] constructionPlan) {
            Construct(constructionPlan);
        }

        public int GetValueForWire(Wire wire, string oldwire) {
            return wire.GetValue(this);
        }
        public int GetValueForWire(string wireId, string oldwire) {
            return GetValueForWire(GetWireWithId(wireId), oldwire);
        }

        public Wire GetWireWithId(string id) {
            return wires[id];
        }

        //<-----------------------------------------------------------/*CONSTRUCTION-METHODS*/---------------------------------------------------------->//

        private void Construct(string[] constructionPlan) {
            foreach(string constructionCommand in constructionPlan) {
                PerformConstructionCommand(constructionCommand);
            }
        }

        private void PerformConstructionCommand(string constructionCommand) {
            object[] command = SplitConstructionCommand(constructionCommand);

            //Create and init LogicGate
            LogicGate logicGate = null;
            switch((GateType)command[0]) {
                case GateType.NUMBER_GATE: {
                    logicGate = new NumberGate((ushort) command[1]);
                    break;
                }
                case GateType.WIRE_GATE: {
                    logicGate = new WireGate((string) command[1]);
                    break;
                }
                case GateType.AND_GATE: {
                    if(Helper.StringHasOnlyDigits((string)command[1])) {
                        logicGate = new AndGate(ushort.Parse((string)command[1]), (string) command[2]);
                    }else{
                        logicGate = new AndGate((string) command[1], (string) command[2]);
                    }
                    break;
                }
                case GateType.OR_GATE: {
                    logicGate = new OrGate((string) command[1], (string) command[2]);
                    break;
                }
                case GateType.LSHIFT_GATE: {
                    logicGate = new LShiftGate((string) command[1], (int) command[2]);
                    break;
                }
                case GateType.RSHIFT_GATE: {
                    logicGate = new RShiftGate((string) command[1], (int) command[2]);
                    break;
                }
                case GateType.NOT_GATE: {
                    logicGate = new NotGate((string) command[1]);
                    break;
                }
            }

            
            
            //Create Wire and save it
            Wire wire = new Wire(logicGate, (string) command[3]);
            wires[(string) command[3]] = wire;
        }



        /*[0] = GATE_TYPE (in enum GateType), [1] = firstGateValue, [2] = secondGateValue (if not needed null), [3] = wireID */
        private object[] SplitConstructionCommand(string constructionCommand) {
            string[] splitCommand = constructionCommand.Split(' ');
            switch(splitCommand.Length) {
                case 3: {
                    //Always NumberGate or WireGate because it is the only gate that isn't even described because really it isn't really a gate but more an allocation
                    if(Helper.StringHasOnlyDigits(splitCommand[0])) {
                        return new object[] {GateType.NUMBER_GATE, ushort.Parse(splitCommand[0]), null, splitCommand[2]};
                    }else{
                        return new object[] {GateType.WIRE_GATE, splitCommand[0], null, splitCommand[2]};
                    }
                }
                case 4: {
                    //Always a NOT-Gate because it is the only gate that only needs 1 value and therefor is only 4 instead of the regular 5 parameters long
                    //!WARNING!: The first value is mission so the position of all the values are one off (for example: secondValue is at [1])
                    return new object[] {GateType.NOT_GATE, splitCommand[1], null, splitCommand[3]};
                }
                case 5: {
                    //Every other command. To seperate them you have to look at [1] because here the name of this gate is written
                    GateType gateType = GateTypeConvert.GetGateTypeFromString(splitCommand[1]);
                    switch(gateType) {
                        case GateType.LSHIFT_GATE: case GateType.RSHIFT_GATE: {
                            return new object[] {gateType, splitCommand[0], Int32.Parse(splitCommand[2]), splitCommand[4]};
                        }
                        default: {
                            return new object[] {gateType, splitCommand[0], splitCommand[2], splitCommand[4]};
                        }
                    }
                }
            }
            return null;
        }

    }

}