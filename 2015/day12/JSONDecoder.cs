using System;
using System.Collections.Generic;
using System.Linq;
using aoc.api;
using aoc.y2015.day12.objects;

namespace aoc.y2015.day12 {

    public class JSONDecoder {

        private FileJSON fileJson;

        public JSONDecoder(string json) {
            List<EntryJSON> entries = new List<EntryJSON>();
            string[] layer0Entries = SplitValuesOfFirstLayer(json);
            foreach (string layer in layer0Entries) {
                entries.Add(GetEntryFromLayer(layer));
            }
            fileJson = new FileJSON(entries);
        }

        public int AddValuesTogether() {
            return fileJson.AddWholeValuesTogether();
        }


        private EntryJSON GetEntryFromLayer(string layer) {
            switch(layer.First()) {
                case '{': {
                    return GetObjectFromLayer(layer);
                }
                case '[': {
                    return GetArrayFromLayer(layer);
                }
                default: {
                    return GetIntFromLayer(layer);
                }
            }
        }

        private ObjectJSON GetObjectFromLayer(string layer) {
            string[] layers = SplitValuesOfFirstLayer(layer.Substring(1, layer.Length-2)); //Substring to cut away the boundaries of object ({"a":1,"b":2} -> "a":1,"b":2)
            List<EntryJSON> entriesOfObject = new List<EntryJSON>();
            foreach(string currentLayer in layers) {
                if(!currentLayer.Equals("")) {
                    entriesOfObject.Add(GetEntryFromLayer(currentLayer.Split(':', 2)[1])); //Split currentLayer to only get the value (index 1) (example: "a":1 -> [0] = "a" [1] = 1)
                }
            }
            return new ObjectJSON(entriesOfObject);
        }

        private ArrayJSON GetArrayFromLayer(string layer) {
            string[] layers = SplitValuesOfFirstLayer(layer.Substring(1, layer.Length-2)); //Substring to cut away the boundaries of array ([1,2] -> 1,2)
            List<EntryJSON> entriesOfObject = new List<EntryJSON>();
            foreach(string currentLayer in layers) {
                if(!currentLayer.Equals("")) {
                    entriesOfObject.Add(GetEntryFromLayer(currentLayer));
                }
            }
            return new ArrayJSON(entriesOfObject);
        }

        private ValueJSON GetIntFromLayer(string layer) {
            if(Helper.StringHasOnlyDigits(layer)) {
                return new ValueJSON(Int32.Parse(layer));
            }
            return new ValueJSON(layer);
        }

        //A JSON is created through layers. For example in '{aa,ab,[aca,acb]},[ba,bb,{bca,bcb}]' the whole string is the first layer. When you spit this layer you get '{aa,ab,[aca,acb]}' and '[ba,bb,{bca,bcb}]' which is at the same time also the second layer and fields of the first layer. Inside this there also is a third layer (for example 'aa', 'ab' and '[aca,acb]' and they are fields at the same time of the layer above)
        private string[] SplitValuesOfFirstLayer(string layer) {
            int currentLayer = 0;
            List<string> layers = new List<string>();
            string layerCache = "";
            for(int i = 0; i < layer.Length; i++) {
                switch(layer.ElementAt(i)) {
                    case '{': case '[': {
                        currentLayer++;
                        break;
                    }
                    case '}': case ']': {
                        currentLayer--;
                        break;
                    }
                    case ',': {
                        if(currentLayer == 0) {
                            layers.Add(layerCache);
                            layerCache = "";
                            continue;
                        }
                        break;
                    }
                }
                layerCache += layer.ElementAt(i);
            }
            layers.Add(layerCache);
            return layers.ToArray();
        }



    }

}