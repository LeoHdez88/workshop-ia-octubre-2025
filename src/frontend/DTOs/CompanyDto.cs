using System;

namespace Frontend.DTOs
{
    /// <summary>
    /// DTO para empresa en el frontend.
    /// </summary>
    public class CompanyDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Products { get; set; }
        public long? Arr { get; set; }
        public long? Valuation { get; set; }
        public int? Employees { get; set; }
        public string Industry { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
