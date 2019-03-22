using System;
using System.Security.Cryptography;
using System.Text;

namespace aoc.y2015.day4 {

    public class MD5Calculator {

        public int CalculateMD5WithSmallNumber(string key, string firstPart) {
            string md5 = "";
            int formatNumber = 0;
            while(!md5.StartsWith(firstPart)) {
                formatNumber++;
                md5 = CreateMD5(key + formatNumber);
                //System.Console.WriteLine("md5: " + md5);
                /*if(formatNumber > 20000000) {
                    return -1;
                }*/
            }
            return formatNumber;
        }


        private string CreateMD5(string input) {
            using(MD5 md5 = MD5.Create()) {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return ConvertByteArrayToHexString(hashBytes);
            }
        }

        private string ConvertByteArrayToHexString(byte[] bytes) {
            return BitConverter.ToString(bytes).Replace("-", "");
        }


    }
}