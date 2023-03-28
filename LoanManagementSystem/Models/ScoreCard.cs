
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystem.Models
{
    public class ScoreCard
    {
        [Key]
        public int scID { get; set; }
        [DisplayName("Score Card Name")]
        public string name { get; set; }
        [DisplayName("Age")]
        public int age { get; set; }
        [DisplayName("Minimum Income")]

        public double minIncome { get; set; }
        [DisplayName("Maximum Income")]
        public double maxIncome { get; set; }
        [DisplayName("State")]
        public virtual int stateId { get; set; }
        [ForeignKey("stateId")]
        public virtual States States  { get; set; }
        [DisplayName("Account Type")]
        public virtual int acntId { get; set; }
        [ForeignKey("acntId")]
        public virtual Accounts Accounts { get; set; }
        [DisplayName("Minimum Loan Amount")]
        public double minLoanamt { get; set; }
        [DisplayName("Maximum Loan Amount")]
        public double maxLoanamt { get; set; }
        [DisplayName("Routing Blacklist")]
        public string routingBlcklst { get; set; }
        [DisplayName("Zipcode Blacklist")]
        public string zipcodeBlcklst { get; set; }


    }
}
