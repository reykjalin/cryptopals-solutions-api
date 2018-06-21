using System;
using System.Collections.Generic;

namespace StringLibrary
{
    public class HexString
    {
        private static readonly String base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        private static readonly Dictionary<String, Int32> hex_values = new Dictionary<String, Int32> {
            { "0", 0 }, { "1", 1 }, { "2", 2 }, { "3", 3 }, { "4", 4 },
            { "5", 5 }, { "6", 6 }, { "7", 7 }, { "8", 8 }, { "9", 9 },
            { "a", 10 }, { "b", 11 }, { "c", 12 }, { "d", 13 }, { "e", 14 },
            { "f", 15 },
        };

        public String hex_string { get; set; }

        public HexString() => hex_string = "";

        public HexString(String hex) {
            if (!isHexStringValid(hex)) {
                throw new InvalidOperationException("Hex string is invalid");
            }

            hex_string = hex;
        }

        public bool isValid()
        {
            return isHexStringValid(hex_string);
        }

        public String asBase64()
        {
            String ret = "";
            // Strip leading 0
            String tmp = stripLeadingChar(hex_string, '0');

            // Convert to base64 by iterating from back to front
            while (!string.IsNullOrEmpty(tmp)) {
                String hex = tmp.Length > 3 ? tmp.Substring(tmp.Length - 3) : tmp;
                // prepend to base64 string since we're going from the back to front
                ret = intToBase64(hexToInt(hex)) + ret;
                tmp = tmp.Length > 3 ? tmp.Remove(tmp.Length - 3) : "";
            }

            // Cover zero string, since nothing will have been added to ret
            if (string.IsNullOrEmpty(ret)) {
                return base64[0].ToString();
            }

            return ret;
        }

        private String stripLeadingChar(String hex, Char c)
        {
            int index = 0;
            while (index < hex.Length && hex[index] == c) {
                index++;
            }

            if (index > 0 && index < hex.Length) {
                return hex.Remove(0, index);
            }
            return hex;
        }

        private String intToBase64(Int32 num)
        {
            Int32 upper = (num >> 6) & 0x3f;
            Int32 lower = num & 0x3f;

            // Don't want a leading A
            if (upper == 0) {
                return base64[lower].ToString();
            }
            return base64[upper].ToString() + base64[lower].ToString();
        }

        private Int32 hexToInt(String hex)
        {
            Int32 ret = 0;
            for (int i = 0; i < hex.Length; i++) {
                ret += hex_values[hex[i].ToString()] * (Int32) Math.Pow(16, (hex.Length - 1 - i));
            }
            return ret;
        }

        public static bool isHexStringValid(String hex)
        {
            foreach (Char c in hex) {
                if (!isHexChar(c)) {
                    return false;
                }
            }
            return true;
        }

        private static bool isHexChar(Char c)
        {
            c = Char.ToLower(c);
            return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f');
        }

        public override String ToString()
        {
            return hex_string;
        }
    }
}
