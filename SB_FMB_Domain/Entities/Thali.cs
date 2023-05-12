using SB_FMB_Domain.Commons.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SB_FMB_Domain.Entities
{
    public class Thali : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ThaliId { get; set; }
        public DateTime ThaliDate { get; set; }

        public virtual List<ThaliItem> ThaliItems { get; set; }
        public virtual List<ThaliStopRequest> ThaliStopRequests { get; set; }
    }
}
