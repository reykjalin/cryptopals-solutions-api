using System;
using Xunit;
using StringLibrary;

namespace StringLibrary.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("123abdef")]
        [InlineData("0")]
        [InlineData("f")]
        public void TestIsValid(String hex)
        {
            HexString hs = new HexString(hex);
            Assert.True(hs.isValid());
        }

        [Theory]
        [InlineData("q")]
        [InlineData("00000q")]
        [InlineData("q---")]
        [InlineData("   ")]
        [InlineData("G")]
        public void TestInvalid(String hex)
        {
            Assert.Throws<InvalidOperationException>(() => { HexString hs = new HexString(hex); });
        }

        [Theory]
        [InlineData("000", "AA")]
        [InlineData("0c", "AM")]
        [InlineData("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d", "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t")]
        public void TestAsBase64(String hex, String base64)
        {
            HexString hs = new HexString(hex);
            Assert.Equal(base64, hs.asBase64());
        }
    }
}
