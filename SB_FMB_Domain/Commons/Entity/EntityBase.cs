namespace SB_FMB_Domain.Commons.Entity
{
    public class EntityBase : IEntityBase
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
