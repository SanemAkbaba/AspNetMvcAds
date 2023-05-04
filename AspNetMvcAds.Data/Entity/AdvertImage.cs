using AspNetMvcAds.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcAds.Data.Entity;

public class AdvertImage : BaseEntity
{
    [Required]
    public int AdvertId { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? ImagePath { get; set; }

    public bool IsCoverImage { get; set; }

    // Navigation Properties
    [ForeignKey("AdvertId")]
    public Advert Advert { get; set; }
}