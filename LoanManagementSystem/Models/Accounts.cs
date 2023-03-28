
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class Accounts
    {

        [Key]
        public int aID { get; set; }

        public string account { get; set; }
    }
}
