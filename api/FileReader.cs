using System;
using System.IO;

namespace aoc.api {
    public static class FileReader {
 
        public static string[] ReadFile(string path) {
            return File.ReadAllLines(path); 
        }

    }
}