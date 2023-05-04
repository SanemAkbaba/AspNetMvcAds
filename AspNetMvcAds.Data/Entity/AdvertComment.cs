using AspNetMvcAds.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcAds.Data.Entity;

public class AdvertComment : AuditEntity
{
    [Required]
    public int AdvertId { get; set; }

    public int? UserId { get; set; }

    [Column(TypeName = "text")]
    public string? Comment { get; set; }

    public int CommentStar { get; set; }

    public bool IsActive { get; set; }

    //Navigation

    public Advert Advert { get; set; }

    public User User { get; set; }
}