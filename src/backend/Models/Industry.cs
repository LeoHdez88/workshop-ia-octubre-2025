using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Industry
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
