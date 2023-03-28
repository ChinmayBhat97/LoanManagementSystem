using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class States
    {
        [Key]
        public int sID { get; set; }

        public  string  stateName { get; set; }
    }
}
