using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class CompanyInvestor
    {
        public long CompanyId { get; set; }
        public long InvestorId { get; set; }
    }
}
