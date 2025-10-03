using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Company
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    public string? Products { get; set; }
    public long? Arr { get; set; }
    public long? Valuation { get; set; }
    public int? Employees { get; set; }
    [Column("industry_id")]
    public long IndustryId { get; set; }
    [Column("location_id")]
    public long LocationId { get; set; }
    }
}
