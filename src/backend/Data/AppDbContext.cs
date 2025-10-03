using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    public DbSet<backend.Models.Location> Locations { get; set; }
    public DbSet<backend.Models.Industry> Industries { get; set; }
    public DbSet<backend.Models.Company> Companies { get; set; }
    public DbSet<backend.Models.Investor> Investors { get; set; }
    public DbSet<backend.Models.CompanyInvestor> CompanyInvestors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<backend.Models.Location>().ToTable("location");
            modelBuilder.Entity<backend.Models.Industry>().ToTable("industry");
            modelBuilder.Entity<backend.Models.Company>().ToTable("company");
            modelBuilder.Entity<backend.Models.Investor>().ToTable("investor");
            modelBuilder.Entity<backend.Models.CompanyInvestor>().ToTable("company_investor");
            modelBuilder.Entity<backend.Models.CompanyInvestor>().HasKey(ci => new { ci.CompanyId, ci.InvestorId });
        }
    }
}
