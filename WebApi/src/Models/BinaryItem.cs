using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class BinaryItem
    {
        [Required]
        public string binary { get; set; }
    }
}