using System.Collections.Generic;
using System.Linq;

namespace aoc.y2015.day12.objects {

    public class ArrayJSON : EntryJSON{


        public ArrayJSON(List<EntryJSON> array) : base(array) {}

        public override int GetWholeValue() =>
            ((List<EntryJSON>)value).Aggregate(0, (accu, current) => accu + current.GetWholeValue());

    }

}