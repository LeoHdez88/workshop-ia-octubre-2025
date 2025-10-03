using backend.Models;

namespace backend.DTOs
{
    public static class Mappings
    {
        public static CompanyDto ToDto(Company company, string industryName, string locationName)
        {
            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Products = company.Products,
                Arr = company.Arr,
                Valuation = company.Valuation,
                Employees = company.Employees,
                Industry = industryName,
                Location = locationName
            };
        }

        public static IndustryDto ToDto(Industry industry)
        {
            return new IndustryDto
            {
                Id = industry.Id,
                Name = industry.Name
            };
        }

        public static LocationDto ToDto(Location location)
        {
            return new LocationDto
            {
                Id = location.Id,
                City = location.City,
                State = location.State,
                Country = location.Country
            };
        }
    }
}
