using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class HexItem
    {
        [Required]
        public string hex { get; set; }
    }
}