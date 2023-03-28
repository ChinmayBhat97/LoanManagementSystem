using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class Account
    {
        [Key]
        public int aid { get; set; }

        public string userName { get; set; }

        public string passWord { get; set; }
    }
}