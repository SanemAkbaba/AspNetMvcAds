namespace AspNetMvcAds.Data.Entity.Abstract;

public abstract class AuditEntity : BaseEntity
{
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}