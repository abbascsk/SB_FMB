using SB_FMB_Domain.Commons.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SB_FMB_Domain.Entities
{
    public class Feedback : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }
        public int ItsId { get; set; }
        public int DishId { get; set; }
        public int Rating { get; set; }
        public string Remarks { get; set; }

        public virtual Mumin Mumin { get; set; }
        public virtual ThaliItem ThaliItem { get; set; }
    }
}
