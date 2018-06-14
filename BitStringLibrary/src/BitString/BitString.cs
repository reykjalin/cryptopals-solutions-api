using System;
using System.Collections.Generic;

namespace StringLibrary
{
    public class BitString
    {
        private static readonly Dictionary<String, String> hex_bits = new Dictionary<String, String> {
            { "0", "0000" }, { "1", "0001" }, { "2", "0010" }, { "3", "0011" },
            { "4", "0100" }, { "5", "0101" }, { "6", "0110" }, { "7", "0111" },
            { "8", "1000" }, { "9", "1001" }, { "a", "1010" }, { "b", "1011" },
            { "c", "1100" }, { "d", "1101" }, { "e", "1110" }, { "f", "1111" },
        };
        private static readonly String base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        public String bit_string { get; set; }

        public BitString() => bit_string = "";
        public BitString(String bit_str) => bit_string = bit_str;

        public void fromHex(String hex_str) {
            bit_string = "";
            hex_str = hex_str.ToLower();
            foreach (Char c in hex_str) {
                bit_string += hex_bits[c.ToString()];
            }
        }

        public String asBase64()
        {
            String ret = "";
            String tmp = bit_string;

            while (tmp.Length > 6) {
                String bits = tmp.Substring(0, 6);
                ret += base64[convertBitsToInt(bits)];
                tmp = tmp.Remove(0, 6);
            }

            if (tmp.Length > 0) {
                ret += base64[convertBitsToInt(tmp)];
            }

            return ret;
        }

        public static Int32 convertBitsToInt(String bits)
        {
            Int32 ret = 0;
            for (int i = 0; i < bits.Length; i++) {
                if (bits[bits.Length - i - 1] == '1') {
                    ret += (Int32) Math.Pow(2, i);
                }
            }
            return ret;
        }

        public bool isValid() {
            return isValidBitString(bit_string);
        }

        public static bool isValidBitString(String str) {
            foreach (Char c in str) {
                if (c != '0' && c != '1') {
                    return false;
                }
            }
            return true;
        }

        public override String ToString()
        {
            return bit_string;
        }
    }
}
