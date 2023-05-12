using SB_FMB_Domain.Commons.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SB_FMB_Domain.Entities
{
    public class ThaliStopRequest : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        public int ThaliId { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }

        public virtual Thali Thali { get; set; }
    }
}
