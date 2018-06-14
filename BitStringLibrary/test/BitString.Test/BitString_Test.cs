using System;
using Xunit;
using StringLibrary;

namespace StringLibrary.Test
{
    public class BitString_Test
    {
        [Theory]
        [InlineData("1")]
        [InlineData("0")]
        [InlineData("01")]
        [InlineData("01101101")]
        [InlineData("00000000")]
        [InlineData("11111111")]
        public void ValidBitStrings(String value)
        {
            BitString bs = new BitString(value);
            Assert.True(bs.isValid(), "Bit string should be valid");
        }

        [Theory]
        [InlineData("A")]
        [InlineData("B")]
        [InlineData("Olll")]
        [InlineData("asdfab1234")]
        [InlineData("0000A00")]
        [InlineData("0x0101")]
        public void InvalidBitStrings(String value)
        {
            Assert.Throws<InvalidOperationException>(() => { BitString bs = new BitString(value); });
        }

        [Theory]
        [InlineData("a", "1010")]
        [InlineData("abcd", "1010101111001101")]
        [InlineData("123", "000100100011")]
        [InlineData("ff", "11111111")]
        public void FromHex(String value, String result)
        {
            BitString bs = new BitString();
            bs.fromHex(value);
            Assert.Equal(bs.bit_string, result);
        }

        [Theory]
        [InlineData("001100", "M")]
        [InlineData("0001100", "AM")]
        [InlineData("010010010010011101101101001000000110101101101001011011000110110001101001011011100110011100100000011110010110111101110101011100100010000001100010011100100110000101101001011011100010000001101100011010010110101101100101001000000110000100100000011100000110111101101001011100110110111101101110011011110111010101110011001000000110110101110101011100110110100001110010011011110110111101101101", "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t")]
        public void TestAsBase64(String value, String result)
        {
            BitString bs = new BitString(value);
            Assert.Equal(result, bs.asBase64());
        }

        [Theory]
        [InlineData("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d", "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t")]
        public void TestHexToBase64(String hex, String base64)
        {
            BitString bs = new BitString();
            bs.fromHex(hex);
            Assert.Equal(bs.asBase64(), base64);
        }
    }
}
