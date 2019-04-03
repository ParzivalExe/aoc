namespace aoc.y2015.day12.objects {

    public class ValueJSON : EntryJSON{

        public ValueJSON(object value) : base(value) {}


        public override int GetWholeValue() { 
            if(value.GetType() == typeof(int)) {
                return (int) value;
            }
            return 0;
        }

    }

}