using AspNetMvcAds.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcAds.Data.Entity;

public class Setting : BaseEntity
{
    [Required]
    public int UserId { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? Name { get; set; }

    [Column(TypeName = "nvarchar(400)")]
    public string? Value { get; set; }
}