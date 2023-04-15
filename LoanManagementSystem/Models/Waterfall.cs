using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LoanManagementSystem.Models
{
    public class Waterfall
    {
        [Key]
        public int Id { get; set; }

        public string wtrflName { get; set; }
    }
}
