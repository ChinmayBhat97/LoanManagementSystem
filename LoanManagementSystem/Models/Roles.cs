using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class Roles
    {
        [Key]
        public int rId { get; set; }

        public string roleName { get; set; }
    }
}
