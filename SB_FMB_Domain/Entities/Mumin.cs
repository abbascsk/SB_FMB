using SB_FMB_Domain.Commons.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SB_FMB_Domain.Entities
{
    public class Mumin : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItsId { get; set; }
        public int SFNumber { get; set; }
        public string FullName { get; set; }
        public string FullNameArabic { get; set; }
        public bool IsHOF { get; set; }
    }
}
