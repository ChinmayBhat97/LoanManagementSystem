using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class LeadPrice
    {
        [Key]
        public int lpId { get; set; }
        [DisplayName("Greater than or Equal to 5000")]
        public double ETAA5000 { get; set; }
        [DisplayName("Greater than or Equal to 4000")]
        public double ETAA4000 { get; set; }
        [DisplayName("Greater than or Equal to 3000")]
        public double ETAA3000 { get; set; }
        [DisplayName("Greater than or Equal to 3000")]
        public double ETAA2000 { get; set; }
        [DisplayName("Lesser than or Equal to 1999")]
        public double ETAB1999 { get; set; }
    }
}
