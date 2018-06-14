using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;

using WebApi.Controllers;
using WebApi.Models;

namespace WebApi.tests
{
    public class Base64ControllerTests
    {
        [Theory]
        [InlineData("01b", "Ab")]
        [InlineData("000", "AA")]
        [InlineData("0c", "AM")]
        [InlineData("0c1", "DB")]
        [InlineData("0c10c", "AMEM")]
        [InlineData("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d", "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t")]
        public void FromHexPost_ReturnsOkResult(string hex, string base64)
        {
            // Arrange
            var controller = new Base64Controller();

            // Act
            HexItem hi = new HexItem();
            hi.hex = hex;
            IActionResult actionResult = controller.PostFromHex(hi);

            // Assert
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;
            Assert.NotNull(result);

            string message = result.Value as string;
            Assert.NotNull(message);
            Assert.Equal(base64, message);
        }

        [Theory]
        [InlineData("q", "invalid hex string")]
        [InlineData("00000q", "invalid hex string")]
        [InlineData("q---", "invalid hex string")]
        [InlineData("   ", "invalid hex string")]
        [InlineData("G", "invalid hex string")]
        public void FromHexPost_ReturnsBadResult(string hex, string errorMessage)
        {
            // Arrange
            var controller = new Base64Controller();

            // Act
            HexItem hi = new HexItem();
            hi.hex = hex;
            IActionResult actionResult = controller.PostFromHex(hi);

            // Assert
            Assert.NotNull(actionResult);

            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.NotNull(result);

            string message = result.Value as string;
            Assert.Equal(errorMessage, message);
        }

        [Theory]
        [InlineData("001100", "M")]
        [InlineData("0001100", "AM")]
        [InlineData("010010010010011101101101001000000110101101101001011011000110110001101001011011100110011100100000011110010110111101110101011100100010000001100010011100100110000101101001011011100010000001101100011010010110101101100101001000000110000100100000011100000110111101101001011100110110111101101110011011110111010101110011001000000110110101110101011100110110100001110010011011110110111101101101", "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t")]
        public void FromBinaryPost_ReturnsOkResult(string binary, string base64)
        {
            // Arrange
            var controller = new Base64Controller();

            // Act
            BinaryItem bi = new BinaryItem();
            bi.binary = binary;
            IActionResult actionResult = controller.PostFromBinary(bi);

            // Assert
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;
            Assert.NotNull(result);

            string message = result.Value as string;
            Assert.NotNull(message);
            Assert.Equal(base64, message);
        }

        [Theory]
        [InlineData("A", "invalid bit string")]
        [InlineData("B", "invalid bit string")]
        [InlineData("Olll", "invalid bit string")]
        [InlineData("asdfab1234", "invalid bit string")]
        [InlineData("0000A00", "invalid bit string")]
        [InlineData("0x0101", "invalid bit string")]
        public void FromBinaryPost_ReturnsBadResult(string binary, string errorMessage)
        {
            // Arrange
            var controller = new Base64Controller();

            // Act
            BinaryItem bi = new BinaryItem();
            bi.binary = binary;
            IActionResult actionResult = controller.PostFromBinary(bi);

            // Assert
            Assert.NotNull(actionResult);

            BadRequestObjectResult result = actionResult as BadRequestObjectResult;
            Assert.NotNull(result);

            string message = result.Value as string;
            Assert.Equal(errorMessage, message);
        }
    }
}
