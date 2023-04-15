using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystem.Models
{
    public class WaterfallService
    {
        [Key]
        public int Id { get; set; }

        public virtual int wID { get; set; }
        [ForeignKey("wID")]
        public virtual Waterfall Waterfall { get; set; }

        public virtual int srWID { get; set; }
        [ForeignKey("srWID")]
        public virtual ServicesforWaterfall ServicesforWaterfall { get; set; }

        public bool activeStatus { get; set; }

        public int OrdrPull { get; set; }

    }
}
