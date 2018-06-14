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
            String tmp = hex_string;

            // TODO change to work from last character
            while (tmp.Length > 3) {
                String hex = tmp.Substring(tmp.Length - 3);
                Int32 value = hexToInt(hex);
                String b64 = base64[(value >> 6) & 0x3f].ToString() + base64[value & 0x3f].ToString();
                ret = b64 + ret;
                tmp = tmp.Remove(tmp.Length - 3);
            }

            if (tmp.Length > 0) {
                Int32 value = hexToInt(tmp);
                String b64 = base64[(value >> 6) & 0x3f].ToString() + base64[value & 0x3f].ToString();
                ret = b64 + ret;
            }

            return ret;
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
