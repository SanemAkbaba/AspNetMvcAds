using AspNetMvcAds.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcAds.Data.Entity;

public class Category : BaseEntity
{
    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string? Name { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? Description { get; set; }

    public int? ParentId { get; set; }

    public int? Amount { get; set; }

    public string? Logo { get; set; }

    public bool IsPopular { get; set; }

    // Navigation Properties

    public List<Advert> Adverts { get; set; } = new List<Advert>();
}