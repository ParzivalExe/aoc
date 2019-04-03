namespace aoc.y2015.day12.objects {

    public abstract class EntryJSON {

        public object value {get; set;}

        public EntryJSON(object value) {
            this.value = value;
        }

        public abstract int GetWholeValue();

    }

}