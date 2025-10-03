using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Location
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string City { get; set; } = string.Empty;
        public string? State { get; set; }
        [Required]
        public string Country { get; set; } = string.Empty;
    }
}
