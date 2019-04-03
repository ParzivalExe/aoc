using System.Collections.Generic;
using System.Linq;

namespace aoc.y2015.day12.objects {

    public class FileJSON {

        public List<EntryJSON> entries {get; private set;}

        public FileJSON(List<EntryJSON> entries) {
            this.entries = entries;
        }

        public int AddWholeValuesTogether() =>
            entries.Aggregate(0, (accu, current) => accu + current.GetWholeValue());
    }   

}