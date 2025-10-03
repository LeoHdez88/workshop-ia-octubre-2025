using System;

namespace backend.DTOs
{
    public class LocationDto
    {
        public long Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string? State { get; set; }
        public string Country { get; set; } = string.Empty;
    }
}
