using System.Collections.Generic;
using System.Linq;

namespace aoc.y2015.day12.objects {

    public class ObjectJSON : EntryJSON{


        public ObjectJSON(List<EntryJSON> fields) : base(fields) {}


        public override int GetWholeValue() =>
            ((List<EntryJSON>)value).Aggregate(0, (accu, current) => accu + current.GetWholeValue());

    }

}