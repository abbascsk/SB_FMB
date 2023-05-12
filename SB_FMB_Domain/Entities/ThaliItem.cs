using SB_FMB_Domain.Commons.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SB_FMB_Domain.Entities
{
    public class ThaliItem : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public int ThaliId { get; set; }
        public string ItemName { get; set; }

        public virtual Thali Thali { get; set; }
    }
}
