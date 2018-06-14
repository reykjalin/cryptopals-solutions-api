using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using StringLibrary;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class Base64Controller : Controller
    {
        // POST api/base64/from/hex
        [HttpPost("from/hex")]
        public IActionResult PostFromHex([FromBody] HexItem value)
        {
            if (value == null || !ModelState.IsValid) {
                return BadRequest("empty request");
            }
            HexString hs = new HexString(value.hex);
            if (!hs.isValid()) {
                return BadRequest("invalid hex string");
            }
            return Ok(hs.asBase64());
        }

        [HttpPost("from/binary")]
        public IActionResult PostFromBinary([FromBody] BinaryItem value)
        {
            if (value == null || !ModelState.IsValid) {
                return BadRequest("empty request");
            }
            BitString bs = new BitString(value.binary);
            if (!bs.isValid()) {
                return BadRequest("invalid hex string");
            }
            return Ok(bs.asBase64());
        }
    }
}
